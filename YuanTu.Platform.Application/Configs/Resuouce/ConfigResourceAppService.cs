using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Linq.Extensions;
using System.Threading.Tasks;
using YuanTu.Platform.AdOrder;
using Abp.Authorization;
using Abp.Application.Services.Dto;
using Abp.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Abp.Collections.Extensions;
using YuanTu.Platform.Parts.Dto;
using YuanTu.Platform.Parts;
using Abp.UI;
using YuanTu.Platform.Configs;
using YuanTu.Platform.Configs.Resource.Dto;
using System.Linq.Dynamic.Core;
using YuanTu.Platform.Jc;
using YuanTu.Platform.Sys;
using Abp.Events.Bus.Entities;
using OfficeOpenXml.Drawing.Chart;
using System.IO;
using System.Collections.Immutable;

namespace YuanTu.Platform.Resource
{
    [AbpAuthorize]
    public class ConfigResourceAppService : AsynPermissionAppService<ConfigResource, ConfigResourceDto, string, PageConfigResourceRequestDto, ConfigResourceDto, ConfigResourceDto>,
        IConfigResourceAppService
    {
        private readonly IRepository<Jc_UserEnum, string> _jcUserEnumRepository;
        private readonly IRepository<AbpAttachment, string> _repositoryAttachment;
        private readonly IRepository<AbpCustomEnum, string> _abpCustomEnumReposiotry;

        public ConfigResourceAppService(
            IRepository<ConfigResource, string> repository,
            IRepository<Jc_UserEnum, string> jcUserEnumRepository,
            IRepository<AbpAttachment, string> repositoryAttachment,
            IRepository<AbpCustomEnum, string> abpCustomEnumReposiotry) : base(repository)
        {
            _repositoryAttachment = repositoryAttachment;
            _jcUserEnumRepository = jcUserEnumRepository;
            _abpCustomEnumReposiotry = abpCustomEnumReposiotry;
        }

        [ActionName("GetPage")]
        public override async Task<PagedResultDto<ConfigResourceDto>> GetAllAsync(PageConfigResourceRequestDto input)
        {
            try
            {
                var query = this.Repository.GetAll().Where(d=>d.IsDeleted==false)
                    .WhereIf(!input.ResouceCode.IsNullOrWhiteSpace(), x => x.ResourceCode.Contains(input.ResouceCode))
                    .WhereIf(!input.TerminalTypeId.IsNullOrWhiteSpace(), x => x.TerminalTypeId.Equals(input.TerminalTypeId))
                    .WhereIf(!input.TypeName.IsNullOrWhiteSpace(), x => x.TypeName.Contains(input.TypeName))
                    .OrderBy(c => c.CteateTime);
                var result = new List<ConfigResourceDto>();

                var totalCount = await query.CountAsync();
                var pagedList = query.Skip(input.SkipCount).Take(input.MaxResultCount).ToList();

                var jcEnumList = _jcUserEnumRepository.GetAll().Where(d => (d.PrefixCode == "SY.003") && d.IsDeleted == false).ToList();
                var enumList = _abpCustomEnumReposiotry.GetAll().Where(d => (d.ParentCode == "TerminalType") && d.IsDeleted == false).ToList();

                var ids = pagedList.Select(d => d.Id).ToList();
                var abpAttachmentList = _repositoryAttachment.GetAllList(d => ids.Contains(d.ExtendId));
                foreach (var info in pagedList)
                {
                    var m = MapToEntityDto(info);
                    m.ResourceCodeStr = jcEnumList.Where(d => d.Code == info.ResourceCode).FirstOrDefault()?.Name;
                    m.abpAttachment = abpAttachmentList.Where(d => d.ExtendId == info.Id.ToString()).FirstOrDefault();
                    var TerminalCodes = m.TerminalTypeId.Split(",").ToList();
                    if (TerminalCodes != null && TerminalCodes.Any())
                    {
                        foreach (var item in TerminalCodes)
                        {
                            m.TerminalCodeStr += $" {enumList.Where(d => d.ParentCode == "TerminalType" && d.Code == item).FirstOrDefault()?.Name}";
                        }

                        m.TerminalCodesStr = m.TerminalCodeStr;

                        if (m.TerminalCodeStr.Length >= 18)
                        {
                            m.TerminalCodesStr = m.TerminalCodeStr.Substring(0, 18) + "...";
                        }

                        m.TerminalCodesStr = info.TerminalTypeId.Contains("ALL") ? "全部" : m.TerminalCodesStr;
                        m.TerminalCodes = TerminalCodes;
                    }

                    result.Add(m);
                }

                var dto = new PagedResultDto<ConfigResourceDto>(totalCount, ObjectMapper.Map<List<ConfigResourceDto>>(result));

                return dto;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public override async Task<ConfigResourceDto> CreateAsync(ConfigResourceDto input)
        {
            try
            {
                #region 判断
                await CheckAsync(input);
                #endregion

                var result = await Repository.GetAll().Where(d => d.Id == input.Id).FirstOrDefaultAsync();

                var model = ObjectMapper.Map<ConfigResource>(input);
                model.Id = input.Id = CreateSequentialGuid();
                model.CteateTime = DateTime.Now;
                var insertResult = await Repository.InsertAsync(model);
                if (insertResult != null)
                {
                    input.abpAttachment.Id = CreateSequentialGuid();
                    input.abpAttachment.ExtendId = insertResult.Id.ToString();
                    await _repositoryAttachment.InsertAsync(input.abpAttachment);
                }

                return input;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString);
                throw;
            }
        }

        public override async Task<ConfigResourceDto> UpdateAsync(ConfigResourceDto input)
        {
            try
            {
                #region 判断
                await CheckAsync(input);
                #endregion

                var result = await Repository.GetAll().Where(d => d.Id.Equals(input.Id)).FirstOrDefaultAsync();

                //编辑
                if (result == null)
                    throw new UserFriendlyException($"没有查到该资源!");

                if (result != null)
                {
                    if (result.Status == 2)
                        throw new UserFriendlyException($"当前资源使用中,不可更改!");
                }

                result.TerminalTypeId = input.TerminalTypeId;
                result.ResourceCode = input.ResourceCode;
                result.TypeCode = input.TypeCode;
                result.HashCode = input.HashCode;
                result.TypeName = input.TypeName;
                result.ResourceUrl = input.ResourceUrl;
                result.ModifyTime = DateTime.Now;
                var updateResult = await Repository.UpdateAsync(result);

                if (updateResult != null)
                {
                    var attachmentResult = await _repositoryAttachment.FirstOrDefaultAsync(d => d.ExtendId.Equals(input.Id));
                    if (attachmentResult != null)
                    {
                        await _repositoryAttachment.DeleteAsync(d => d.ExtendId.Equals(input.Id));

                        input.abpAttachment.Id = CreateSequentialGuid();
                        await _repositoryAttachment.InsertAsync(input.abpAttachment);
                    }
                }

                return input;
            }
            catch (Exception ex)
            {
                Logger.Error(ex.ToString);
                throw;
            }
        }

        public override async Task DeleteAsync(EntityDto<string> input)
        {
            var result = await Repository.GetAll().Where(d => d.Id.Equals(input.Id)).FirstOrDefaultAsync();
            if(result.Status==2)
            {
                throw new UserFriendlyException($"该资源正在使用中,不可删除!");
            }
            result.IsDeleted = true;
            var updateResult = await Repository.UpdateAsync(result);
            if (updateResult != null)
            {
                await _repositoryAttachment.DeleteAsync(d => d.ExtendId.Equals(input.Id));
            }
        }

        /// <summary>
        /// 获取资源中心
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        [AbpAllowAnonymous]
        public async Task<List<ConfigResourceDto>> GetResourceListAsync(ConfigResourceRequestDto input)
        {
            //如果传入资源类型是以下几种，那机型传入参数默认重置为ALL
            //List<string> sourceCodeList = new List<string>() { "SY.003.001", "SY.003.002", "SY.003.003", "SY.003.007" };
            var isAll = this.Repository.GetAll().Where(d => d.ResourceCode == input.ResourceCode && d.IsDeleted == false).Any(d => d.TerminalTypeId.Equals("ALL"));
            if(isAll)
            {
                input.TerminalTypeId = "ALL";
            }

            var query = this.Repository.GetAll().Where(d => d.IsDeleted == false)
                .WhereIf(!input.ResourceCode.IsNullOrWhiteSpace(), x => x.ResourceCode.Contains(input.ResourceCode))
                .WhereIf(!input.TerminalTypeId.IsNullOrWhiteSpace(), x => x.TerminalTypeId.Contains(input.TerminalTypeId))
                .WhereIf(!input.TypeCode.IsNullOrWhiteSpace(), x => x.TypeCode.Equals(input.TypeCode))
                .WhereIf(!input.TypeName.IsNullOrWhiteSpace(), x => x.TypeName == input.TypeName).OrderBy(c => c.CteateTime);

            var result = new List<ConfigResourceDto>();

            var jcEnumList = _jcUserEnumRepository.GetAll().Where(d => (d.PrefixCode == "SY.003") && d.IsDeleted == false).ToList();
            var enumList = _abpCustomEnumReposiotry.GetAll().Where(d => (d.ParentCode == "TerminalType") && d.IsDeleted == false).ToList();

            foreach (var item in query.ToList())
            {
                var m = MapToEntityDto(item);
                m.ResourceCodeStr = jcEnumList.Where(d => d.Code == item.ResourceCode).FirstOrDefault()?.Name;
                var TerminalCodes = m.TerminalTypeId.Split(",").ToList();
                if (TerminalCodes != null && TerminalCodes.Any())
                {
                    foreach (var code in TerminalCodes)
                    {
                        m.TerminalCodeStr += $" {enumList.Where(d => d.ParentCode == "TerminalType" && d.Code == code).FirstOrDefault()?.Name}";
                    }

                    m.TerminalCodes = TerminalCodes;
                }

                result.Add(m);
            }

            return result;
        }

        #region 判断
        public async Task CheckAsync(ConfigResourceDto input)
        {
            if (input.TerminalCodes != null && input.TerminalCodes.Any())
                input.TerminalTypeId = string.Join(",", input.TerminalCodes);
            else
                throw new UserFriendlyException($"资源机型不可为空!");

            if (input.ResourceCode.IsNullOrWhiteSpace())
                throw new UserFriendlyException($"资源类型不可为空!");

            if (input.ResourceUrl.IsNullOrWhiteSpace())
            {
                throw new UserFriendlyException($"资源上传不可为空!");
            }
            else
            {
                Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>();
                dic.Add("SY.003.001", new List<string>() { ".jpg", ".mp4", ".png", ".gif" });
                dic.Add("SY.003.002", new List<string>() { ".jpg", ".png" });
                dic.Add("SY.003.003", new List<string>() { ".jpg", ".png" });
                dic.Add("SY.003.004", new List<string>() { ".gif" });
                dic.Add("SY.003.005", new List<string>() { ".gif" });
                dic.Add("SY.003.006", new List<string>() { ".gif" });
                dic.Add("SY.003.007", new List<string>() { ".jpg", ".png" });

                var fileExt = Path.GetExtension(input.ResourceUrl);
                if (!dic[input.ResourceCode].Contains(fileExt))
                {
                    throw new UserFriendlyException($"当前不可上传{fileExt} 格式文件!");
                }
            }

            //判断TypeName是否为空
            List<string> isTypeNameNull = new List<string>() { "SY.003.001", "SY.003.002", "SY.003.007" };

            //判断TypeCode是否为空
            List<string> isTypeCodeNull = new List<string>() { "SY.003.003", "SY.003.004", "SY.003.005", "SY.003.006" };

            if (isTypeNameNull.Contains(input.ResourceCode))
            {
                if (input.TypeName.IsNullOrWhiteSpace())
                    throw new UserFriendlyException($"资源名称不可为空!");

                var configResourceInfo = await Repository.GetAll().Where(d =>d.ResourceCode==input.ResourceCode && d.Id != input.Id && d.TypeName == input.TypeName && d.IsDeleted == false).FirstOrDefaultAsync();
                if (configResourceInfo != null)
                    throw new UserFriendlyException($"该名称已添加!");
            }
            else if (isTypeCodeNull.Contains(input.ResourceCode))
            {
                if (string.IsNullOrWhiteSpace(input.TypeCode))
                {
                    throw new UserFriendlyException($"资源名称不可为空!");
                }
                else
                {
                    var result = await _jcUserEnumRepository.GetAll().Where(d => d.PrefixCode == input.prefixCode && d.Code == input.code).FirstOrDefaultAsync();
                    input.TypeName = result?.Name;

                    //判断图片类型是否重复添加
                    var configResourceInfo = await Repository.GetAll().Where(d => d.Id != input.Id && d.TypeCode == input.TypeCode && d.IsDeleted == false).FirstOrDefaultAsync();
                    if (configResourceInfo != null)
                        throw new UserFriendlyException($"该资源类型或名称已添加!");
                }
            }

            #region 判断机型是否重复
            //var exist = await Repository.GetAll().Where(d => d.Id != input.Id && d.ResourceCode == input.ResourceCode && d.TerminalCode == input.TerminalCode).FirstOrDefaultAsync();
            //if (exist != null)
            //    throw new UserFriendlyException($"当前机型已经存在，不可重复添加!");
            #endregion
        }
        #endregion
    }
}
