using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Abp;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Dependency;
using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using YuanTu.Platform.Common.Dto;
using YuanTu.Platform.Users.Dto;

namespace YuanTu.Platform
{
    public interface IAsynPermissionAppService<TEntity, TEntityDto, TPrimaryKey, in TGetAllInput, in TCreateInput, in TUpdateInput, in TGetInput, in TDeleteInput>
       : IAsyncCrudAppService<TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput>, IAsynAppService<TEntityDto, TPrimaryKey>, IApplicationService, ITransientDependency
       where TEntity : class, IEntity<TPrimaryKey>
       where TEntityDto : IEntityDto<TPrimaryKey>
       where TUpdateInput : IEntityDto<TPrimaryKey>
       where TGetInput : IEntityDto<TPrimaryKey>
       where TDeleteInput : IEntityDto<TPrimaryKey>
    {
        //Task<TEntityDto> CreateWithNoPermission(TCreateInput input);
        //Task DeleteWithNoPermission(TDeleteInput input);
        //Task<TEntityDto> GetWithNoPermission(TGetInput input);
        //Task<PagedResultDto<TEntityDto>> GetAllWithNoPermission(TGetAllInput input);
        //Task<TEntityDto> UpdateWithNoPermission(TUpdateInput input);   
    }

    public abstract class AsynPermissionAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput>
        : AsyncCrudAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput>,
        IAsynPermissionAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, TDeleteInput>, IApplicationService, ITransientDependency
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>
        where TCreateInput : IEntityDto<TPrimaryKey>
        where TGetInput : IEntityDto<TPrimaryKey>
        where TDeleteInput : IEntityDto<TPrimaryKey>
    {
        protected AsynPermissionAppService(IRepository<TEntity, TPrimaryKey> repository)
            : base(repository)
        {
        }

        protected virtual string CreateSequentialGuid()
        {
            return SequentialGuidGenerator.Instance.Create(SequentialGuidGenerator.SequentialGuidDatabaseType.MySql).ToString("N");
        }

        public override Task<TEntityDto> CreateAsync(TCreateInput input)
        {
            CheckCreatePermission();

            return CreateWithNoPermission(input);
        }

        protected virtual Task<TEntityDto> CreateWithNoPermission(TCreateInput input)
        {
            if (typeof(TPrimaryKey) == typeof(string) && string.IsNullOrEmpty($"{input.Id}".Trim()))
            {
                dynamic id = CreateSequentialGuid();
                input.Id = id;
            }
            return base.CreateAsync(input);
        }

        public override Task DeleteAsync(TDeleteInput input)
        {
            CheckDeletePermission();

            return DeleteWithNoPermission(input);
        }

        protected virtual Task DeleteWithNoPermission(TDeleteInput input)
        {
            return base.DeleteAsync(input);
        }

        [ActionName("GetPage")]
        public override Task<PagedResultDto<TEntityDto>> GetAllAsync(TGetAllInput input)
        {
            CheckGetAllPermission();

            return GetAllWithNoPermission(input);
        }

        protected virtual Task<PagedResultDto<TEntityDto>> GetAllWithNoPermission(TGetAllInput input)
        {
            return base.GetAllAsync(input);
        }

        public override Task<TEntityDto> GetAsync(TGetInput input)
        {
            CheckGetPermission();

            return GetWithNoPermission(input);
        }

        protected virtual Task<TEntityDto> GetWithNoPermission(TGetInput input)
        {
            return base.GetAsync(input);
        }

        public override Task<TEntityDto> UpdateAsync(TUpdateInput input)
        {
            //throw new AbpAuthorizationException("You are not authorized to create user!");

            CheckUpdatePermission();

            return UpdateWithNoPermission(input);
        }

        protected virtual Task<TEntityDto> UpdateWithNoPermission(TUpdateInput input)
        {
            return base.UpdateAsync(input);
        }

        protected override bool IsGranted(string permissionName)
        {
            return base.IsGranted(permissionName);
        }

        protected override Task<bool> IsGrantedAsync(string permissionName)
        {
            return new Task<bool>(() => { return base.IsGranted(permissionName); });
        }

        [ActionName("GetAll")]
        public virtual async Task<ListResultDto<TEntityDto>> GetAllListAsync()
        {
            var list = await Repository.GetAllListAsync();
            return new ListResultDto<TEntityDto>(ObjectMapper.Map<List<TEntityDto>>(list));
        }

        public virtual Task<ListResultDto<TEntityDto>> GetAllByKey(string key, long orgId = 0)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public virtual Task DeleteByIds(dynamic data)
        {
            throw new NotImplementedException();
        }
    }

    public interface IAsynPermissionAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput>
        : IAsynPermissionAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, EntityDto<TPrimaryKey>>, IApplicationService, ITransientDependency
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>
        where TCreateInput : IEntityDto<TPrimaryKey>
        where TGetInput : IEntityDto<TPrimaryKey>
    {
    }

    public abstract class AsynPermissionAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput> : AsynPermissionAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, TGetInput, EntityDto<TPrimaryKey>>
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>
        where TCreateInput : IEntityDto<TPrimaryKey>
        where TGetInput : IEntityDto<TPrimaryKey>
    {
        protected AsynPermissionAppService(IRepository<TEntity, TPrimaryKey> repository)
            : base(repository)
        {
        }
    }

    public interface IAsynPermissionAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput>
        : IAsynPermissionAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, EntityDto<TPrimaryKey>>, IApplicationService, ITransientDependency
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>
        where TCreateInput : IEntityDto<TPrimaryKey>
    {
    }

    public abstract class AsynPermissionAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput> : AsynPermissionAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, EntityDto<TPrimaryKey>>
        where TEntity : class, IEntity<TPrimaryKey>
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>
        where TCreateInput : IEntityDto<TPrimaryKey>
    {
        protected AsynPermissionAppService(IRepository<TEntity, TPrimaryKey> repository)
            : base(repository)
        {
        }
    }

    public interface IAsynPermissionAppService<TEntityDto, TPrimaryKey, in TGetAllInput, in TCreateInput, in TUpdateInput>
        : IAsyncCrudAppService<TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, EntityDto<TPrimaryKey>>
        , IAsyncCrudAppService<TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, EntityDto<TPrimaryKey>, EntityDto<TPrimaryKey>>, IApplicationService, ITransientDependency
        where TEntityDto : IEntityDto<TPrimaryKey>
        where TUpdateInput : IEntityDto<TPrimaryKey>
        where TCreateInput : IEntityDto<TPrimaryKey>
    {
    }

    //public abstract class AsynPermissionAppService<TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput> : AsynPermissionAppService<TEntity, TEntityDto, TPrimaryKey, TGetAllInput, TCreateInput, TUpdateInput, EntityDto<TPrimaryKey>>
    //    where TEntityDto : IEntityDto<TPrimaryKey>
    //    where TUpdateInput : IEntityDto<TPrimaryKey>
    //{
    //    protected AsynPermissionAppService(IRepository<TEntity, TPrimaryKey> repository)
    //        : base(repository)
    //    {
    //    }
    //}

    public interface IAsynPermissionAppService<TEntityDto, TPrimaryKey> : IAsynPermissionAppService<TEntityDto, TPrimaryKey, CustomPagedAndSortedDto, TEntityDto, TEntityDto>, IApplicationService, ITransientDependency
         where TEntityDto : IEntityDto<TPrimaryKey>
    {

    }

    public abstract class AsynPermissionAppService<TEntityDto, TPrimaryKey>
        : AsynPermissionAppService<TEntityDto, TEntityDto, TPrimaryKey, CustomPagedAndSortedDto, TEntityDto, TEntityDto, EntityDto<TPrimaryKey>>
        , IAsynPermissionAppService<TEntityDto, TPrimaryKey>
        where TEntityDto : class, IEntityDto<TPrimaryKey>, IEntity<TPrimaryKey>
    {
        protected AsynPermissionAppService(IRepository<TEntityDto, TPrimaryKey> repository)
            : base(repository)
        {
        }
    }
}

