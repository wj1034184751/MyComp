using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YuanTu.Platform.Authorization.Menus.Dto;
using YuanTu.Platform.Sys.AbpColumns.Dto;

namespace YuanTu.Platform.Sys.AbpColumns
{
    public class AbpColumnAppService : AsynPermissionAppService<AbpColumn, AbpColumnDto, String, PagedAbpColumnRequestDto, AbpColumnDto, AbpColumnDto>, IAbpColumnAppService
    {
        protected IHttpContextAccessor httpContext;
        private readonly IRepository<AbpTable, string> m_repAbpTable;
        public AbpColumnAppService(IRepository<AbpColumn, string> repository, IRepository<AbpTable, string> repositoryTable, IHttpContextAccessor httpContextAccessor)
            : base(repository)
        {
            httpContext = httpContextAccessor;
            m_repAbpTable = repositoryTable;
        }

        public override Task<AbpColumnDto> CreateAsync(AbpColumnDto input)
        {
            //if (string.IsNullOrEmpty(input.TraceId))
            //{
            //    input.TraceId = Guid.NewGuid().ToString("N");
            //}

            return base.CreateAsync(input);
        }

        public override Task<ListResultDto<AbpColumnDto>> GetAllByKey(string key, long orgId = 0)
        {
            var list = Repository.GetAll().Join(m_repAbpTable.GetAll().Where(t => t.Code.Equals(key)),
                c => c.AbpTableId, t => t.Id,
                ((column, table) => column)).Where(s => s.OrgId == orgId).OrderBy(s => s.Sort).ToList();
            return Task.FromResult(new ListResultDto<AbpColumnDto>(ObjectMapper.Map<List<AbpColumnDto>>(list)));
        }

        protected override IQueryable<AbpColumn> CreateFilteredQuery(PagedAbpColumnRequestDto input)
        {
            return Repository.GetAll()
                .Where(v => input.Mid == v.AbpTableId);
        }

        [ActionName("GetPage")]
        public override Task<PagedResultDto<AbpColumnDto>> GetAllAsync(PagedAbpColumnRequestDto input)
        {
            input.Sorting = "Sort";
            return base.GetAllAsync(input);
        }

        [ActionName("GetAll")]
        public override async Task<ListResultDto<AbpColumnDto>> GetAllListAsync()
        {
            var list = await base.GetAllListAsync();
            return new ListResultDto<AbpColumnDto>(list.Items.OrderBy(s => s.Sort).ToList());
        }

        public void GetDownload(string tableId, string tableName)
        {
            httpContext.HttpContext.Response.Headers.Add("Content-Disposition", "attachment;filename=Tet.rar");
            httpContext.HttpContext.Response.ContentType = "application/octet-stream";
            httpContext.HttpContext.Response.SendFileAsync("Tet.rar");
        }

        [HttpGet, AbpAllowAnonymous]
        public async Task<IActionResult> Excute(DownloadInput input)
        {
            var table = m_repAbpTable.GetAll().FirstOrDefault(v => v.Code == input.TableName);
            var columns = this.Repository.GetAll().Where(v => v.AbpTableId == table.Id).ToList();

            //var text = CreateEntity(table, columns);
            //m_httpContext.HttpContext
            var root = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "CodeDom");
            string folder = Path.Combine(root, table.Code);

            if (Directory.Exists(folder))
            {
                Directory.Delete(folder, true);
            }


            Directory.CreateDirectory(folder);
            // 后端数据类
            CreateFile(folder, 0, table, columns);
            // 接口类
            CreateFile(folder, 1, table, columns);
            // 入参类
            CreateFile(folder, 2, table, columns);
            // 出参类
            CreateFile(folder, 3, table, columns);
            // 服务类
            CreateFile(folder, 4, table, columns);
            // 前端实体类
            CreateFile(folder, 5, table, columns);
            // 前端服务类
            CreateFile(folder, 6, table, columns);
            //// 前端主页
            //CreateFile(folder, 7, table, columns);
            //// 前端编辑页
            //CreateFile(folder, 8, table, columns);
            var filename = $"{table.Code.ToLower()}.zip";
            var path = Path.Combine(root, filename);

            ZipUtil.ZipDir(folder, path);


            var ms = new MemoryStream();
            var buffer = File.ReadAllBytes(path);
            await ms.WriteAsync(buffer, 0, buffer.Length);
            ms.Seek(0, SeekOrigin.Begin);

            return new FileStreamResult(ms, $"application/octet-stream") { FileDownloadName = filename };
        }

        private void CreateFile(string folder, int fileType, AbpTable table, List<AbpColumn> columns)
        {
            string subfolder = "";
            string filename = "";
            var text = string.Empty;

            switch (fileType)
            {
                case 0:
                    text = CreateEntity(table, columns);
                    filename = $"{table.Code}.cs";
                    subfolder = Path.Combine("Abp", "Core", GetSubfolder(table));
                    break;
                case 1:
                    text = CreateInterface(table, columns);
                    filename = $"I{table.Code}AppService.cs";
                    subfolder = Path.Combine("Abp", "Application", GetSubfolder(table), table.Code);
                    break;
                case 2:
                    text = CreateDto(table, columns);
                    filename = $"{table.Code}Dto.cs";
                    subfolder = Path.Combine("Abp", "Application", GetSubfolder(table), table.Code, "Dto");
                    break;
                case 3:
                    text = CreateRto(table, columns);
                    filename = $"{table.Code}Rto.cs";
                    subfolder = Path.Combine("Abp", "Application", GetSubfolder(table), table.Code, "Rto");
                    break;
                case 4:
                    text = CreateService(table, columns);
                    filename = $"{table.Code}AppService.cs";
                    subfolder = Path.Combine("Abp", "Application", GetSubfolder(table), table.Code);
                    break;
                case 5:
                    text = CreateEntityTs(table, columns);
                    filename = $"{table.Code.ToLower()}.ts";
                    subfolder = Path.Combine("Vue", "store", "entities", GetSubfolder(table, true));
                    break;
                case 6:
                    text = CreateModule(table, columns);
                    filename = $"{table.Code.ToLower()}.ts";
                    subfolder = Path.Combine("Vue", "store", "modules", GetSubfolder(table, true));
                    break;
            }
            string dir = Path.Combine(folder, subfolder);
            if (!Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }

            File.WriteAllText(Path.Combine(dir, filename), text);
        }

        /// <summary>
        /// 创建实体类
        /// </summary>
        /// <param name="table">表</param>
        /// <param name="columns">列</param>
        /// <returns>脚本</returns>
        private string CreateEntity(AbpTable table, List<AbpColumn> columns)
        {
            CodeCompileUnit unit = new CodeCompileUnit();
            CodeNamespace ns = new CodeNamespace(table.Namespace);
            unit.Namespaces.Add(ns);
            ns.Imports.Add(new CodeNamespaceImport("System.ComponentModel.DataAnnotations"));
            ns.Imports.Add(new CodeNamespaceImport("System.ComponentModel.DataAnnotations.Schema"));
            ns.Imports.Add(new CodeNamespaceImport("YuanTu.Platform.Common"));
            CodeTypeDeclaration cls = new CodeTypeDeclaration(table.Code);
            ns.Types.Add(cls);

            cls.Comments.AddRange(AddComments(table.Name, true).ToArray());

            if (table.IsParent)
            {
                if (table.IsDistinatOrg)
                {
                    cls.BaseTypes.Add(new CodeTypeReference($"ParentCustomCreationEntityWithOrg<string>"));
                }
                else
                {
                    cls.BaseTypes.Add(new CodeTypeReference($"CustomCreationEntityWithOrg<string>"));
                }
            }
            else
            {
                if (table.IsDistinatOrg)
                {
                    cls.BaseTypes.Add(new CodeTypeReference($"CustomEntityWithOrg<string>"));
                }
                else
                {
                    cls.BaseTypes.Add(new CodeTypeReference($"CustomEntity<string>"));
                }
            }

            foreach (var col in columns)
            {
                CodeMemberField field = new CodeMemberField(GetType(col.DataType), $"_{col.Code}");
                field.Attributes = MemberAttributes.Private;
                //field.InitExpression = new CodeArrayCreateExpression("System.Int32", 10);
                cls.Members.Add(field);

                // 属性
                CodeMemberProperty prop = new CodeMemberProperty();
                prop.Name = col.Code;
                // 属性值的类型
                prop.Type = new CodeTypeReference(GetType(col.DataType));
                // 公共属性
                prop.Attributes = MemberAttributes.Public | MemberAttributes.Final;

                if (!col.CanbeNull)
                {
                    //var attr = new CodeAttributeDeclaration(
                    //    "Required",
                    //    new CodeAttributeArgument(new CodePrimitiveExpression(true)));


                    var attr = new CodeAttributeDeclaration("Required");

                    prop.CustomAttributes.Add(attr);
                }

                if (col.DataType.ToLower() == "string" && col.MaxLen > 0)
                {
                    var attr = new CodeAttributeDeclaration(
                        "StringLength",
                        new CodeAttributeArgument(new CodePrimitiveExpression(col.MaxLen)));

                    prop.CustomAttributes.Add(attr);
                }

                if (col.DataType.ToLower() == "decimal")
                {
                    var attr = new CodeAttributeDeclaration(
                        "Column",
                        new CodeAttributeArgument(new CodePrimitiveExpression(col.Code)),
                        //new CodeAttributeArgument(new CodePrimitiveExpression($"decimal({col.MaxLen}, {col.MinLen})"))
                        new CodeAttributeArgument(new CodeSnippetExpression($"TypeName = \"decimal({col.MaxLen}, {col.MinLen})\"")));
                    
                    prop.CustomAttributes.Add(attr);
                }

                prop.Comments.AddRange(AddComments(col.Name).ToArray());

                prop.GetStatements.Add(new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), field.Name)));

                //set
                prop.SetStatements.Add(new CodeAssignStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), field.Name), new CodePropertySetValueReferenceExpression()));


                cls.Members.Add(prop);
            }

            var provider = CodeDomProvider.CreateProvider("CSharp");

            CodeGeneratorOptions options = new CodeGeneratorOptions();

            options.BracingStyle = "C";

            options.BlankLinesBetweenMembers = true;

            using (MemoryStream memory = new MemoryStream(1024 * 32))
            {
                using (StreamWriter sw = new StreamWriter(memory))
                {
                    provider.GenerateCodeFromCompileUnit(unit, sw, options);
                    sw.Flush();
                    memory.Position = 0;
                    string text = string.Empty;
                    var p = 0;
                    while (true)
                    {
                        byte[] buffer = new byte[1024];
                        var len = memory.Read(buffer, 0, 1024);
                        p += len;
                        text += Encoding.UTF8.GetString(buffer, 0, len);
                        if (len < 1024)
                        {
                            break;
                        }
                    }

                    return string.Join(Environment.NewLine, text.Split(Environment.NewLine).ToList().Skip(9).ToArray());
                }
            }
        }

        /// <summary>
        /// 创建接口
        /// </summary>
        /// <param name="table">表</param>
        /// <param name="columns">列</param>
        /// <returns>脚本</returns>
        private string CreateInterface(AbpTable table, List<AbpColumn> columns)
        {
            CodeCompileUnit unit = new CodeCompileUnit();
            CodeNamespace ns = new CodeNamespace(table.Namespace);
            ns.Imports.Add(new CodeNamespaceImport("System"));
            ns.Imports.Add(new CodeNamespaceImport("YuanTu.Platform.Common.Dto"));
            unit.Namespaces.Add(ns);
            CodeTypeDeclaration cls = new CodeTypeDeclaration($"I{table.Code}AppService");
            cls.IsInterface = true;
            ns.Types.Add(cls);

            cls.Comments.AddRange(AddComments(table.Name, true).ToArray());

            cls.BaseTypes.Add(new CodeTypeReference($"IAsynPermissionAppService"
                , new CodeTypeReference(table.Code)
                , new CodeTypeReference($"{table.Code}Dto")
                , new CodeTypeReference(typeof(string))
                , new CodeTypeReference(GetFilter(table))
                , new CodeTypeReference($"{table.Code}Dto")
                , new CodeTypeReference($"{table.Code}Dto")));

            var provider = CodeDomProvider.CreateProvider("CSharp");

            CodeGeneratorOptions options = new CodeGeneratorOptions();

            options.BracingStyle = "C";

            options.BlankLinesBetweenMembers = true;

            using (MemoryStream memory = new MemoryStream(1024 * 32))
            {
                using (StreamWriter sw = new StreamWriter(memory))
                {
                    provider.GenerateCodeFromCompileUnit(unit, sw, options);
                    sw.Flush();
                    memory.Position = 0;
                    string text = string.Empty;
                    var p = 0;
                    while (true)
                    {
                        byte[] buffer = new byte[1024];
                        var len = memory.Read(buffer, 0, 1024);
                        p += len;
                        text += Encoding.UTF8.GetString(buffer, 0, len);
                        if (len < 1024)
                        {
                            break;
                        }
                    }

                    return string.Join(Environment.NewLine, text.Split(Environment.NewLine).ToList().Skip(9).ToArray());
                }
            }
        }

        /// <summary>
        /// 创建服务
        /// </summary>
        /// <param name="table">表</param>
        /// <param name="columns">列</param>
        /// <returns>脚本</returns>
        private string CreateService(AbpTable table, List<AbpColumn> columns)
        {
            CodeCompileUnit unit = new CodeCompileUnit();
            CodeNamespace ns = new CodeNamespace(table.Namespace);
            ns.Imports.Add(new CodeNamespaceImport("System")); 
            ns.Imports.Add(new CodeNamespaceImport("Abp.Domain.Repositories")); 
            ns.Imports.Add(new CodeNamespaceImport("YuanTu.Platform.Common.Dto"));
            unit.Namespaces.Add(ns);
            CodeTypeDeclaration cls = new CodeTypeDeclaration($"{table.Code}AppService");
            ns.Types.Add(cls);

            cls.Comments.AddRange(AddComments(table.Name, true).ToArray());

            cls.BaseTypes.Add(new CodeTypeReference($"AsynPermissionAppService"
                , new CodeTypeReference(table.Code)
                , new CodeTypeReference($"{table.Code}Dto")
                , new CodeTypeReference(typeof(string))
                , new CodeTypeReference(GetFilter(table))
                , new CodeTypeReference($"{table.Code}Dto")
                , new CodeTypeReference($"{table.Code}Dto")));
            cls.BaseTypes.Add(new CodeTypeReference($"I{table.Code}AppService"));
            
            // 准备用于构造函数的参数
            CodeParameterDeclarationExpression constructorParamter = new CodeParameterDeclarationExpression(
                new CodeTypeReference($"IRepository",new CodeTypeReference($"{table.Code}"), new CodeTypeReference(typeof(string)))
                , "repository");

            // 构造函数
            CodeConstructor constructor = new CodeConstructor();
            constructor.Attributes = MemberAttributes.Public;
            constructor.Parameters.Add(constructorParamter);
            constructor.BaseConstructorArgs.Add(new CodeTypeReferenceExpression(constructorParamter.Name));
            cls.Members.Add(constructor);

            var provider = CodeDomProvider.CreateProvider("CSharp");

            CodeGeneratorOptions options = new CodeGeneratorOptions();

            options.BracingStyle = "C";

            options.BlankLinesBetweenMembers = true;

            using (MemoryStream memory = new MemoryStream(1024 * 32))
            {
                using (StreamWriter sw = new StreamWriter(memory))
                {
                    provider.GenerateCodeFromCompileUnit(unit, sw, options);
                    sw.Flush();
                    memory.Position = 0;
                    string text = string.Empty;
                    var p = 0;
                    while (true)
                    {
                        byte[] buffer = new byte[1024];
                        var len = memory.Read(buffer, 0, 1024);
                        p += len;
                        text += Encoding.UTF8.GetString(buffer, 0, len);
                        if (len < 1024)
                        {
                            break;
                        }
                    }

                    return string.Join(Environment.NewLine, text.Split(Environment.NewLine).ToList().Skip(9).ToArray());
                }
            }
        }

        /// <summary>
        /// 创建入参类
        /// </summary>
        /// <param name="table">表</param>
        /// <param name="columns">列</param>
        /// <returns>脚本</returns>
        private string CreateDto(AbpTable table, List<AbpColumn> columns)
        {
            CodeCompileUnit unit = new CodeCompileUnit();
            CodeNamespace ns = new CodeNamespace(table.Namespace);
            ns.Imports.Add(new CodeNamespaceImport("System"));
            ns.Imports.Add(new CodeNamespaceImport("YuanTu.Platform.Common.Dto"));
            unit.Namespaces.Add(ns);
            CodeTypeDeclaration cls = new CodeTypeDeclaration($"{table.Code}Dto");
            cls.CustomAttributes.Add(new CodeAttributeDeclaration(
                "Abp.AutoMapper.AutoMap",
                new CodeAttributeArgument(new CodeTypeOfExpression(table.Code))));
            ns.Types.Add(cls);

            cls.Comments.AddRange(AddComments(table.Name, true).ToArray());

            if (table.IsParent)
            {
                if (table.IsDistinatOrg)
                {
                    cls.BaseTypes.Add(new CodeTypeReference($"ParentCustomEntityWithOrgDto<string>"));
                }
                else
                {
                    cls.BaseTypes.Add(new CodeTypeReference($"ParentCustomEntityDto<string>"));
                }
            }
            else
            {
                if (table.IsDistinatOrg)
                {
                    cls.BaseTypes.Add(new CodeTypeReference($"CustomEntityWithOrgDto<string>"));
                }
                else
                {
                    cls.BaseTypes.Add(new CodeTypeReference($"CustomEntityDto<string>"));
                }
            }

            foreach (var col in columns)
            {
                CodeMemberField field = new CodeMemberField(GetType(col.DataType), $"_{col.Code}");
                field.Attributes = MemberAttributes.Private;
                //field.InitExpression = new CodeArrayCreateExpression("System.Int32", 10);
                cls.Members.Add(field);

                // 属性
                CodeMemberProperty prop = new CodeMemberProperty();
                prop.Name = col.Code;
                // 属性值的类型
                prop.Type = new CodeTypeReference(GetType(col.DataType));
                // 公共属性
                prop.Attributes = MemberAttributes.Public | MemberAttributes.Final;

                prop.Comments.AddRange(AddComments(col.Name).ToArray());

                prop.GetStatements.Add(new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), field.Name)));

                //set
                prop.SetStatements.Add(new CodeAssignStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), field.Name), new CodePropertySetValueReferenceExpression()));


                cls.Members.Add(prop);
            }

            var provider = CodeDomProvider.CreateProvider("CSharp");

            CodeGeneratorOptions options = new CodeGeneratorOptions();

            options.BracingStyle = "C";

            options.BlankLinesBetweenMembers = true;

            using (MemoryStream memory = new MemoryStream(1024 * 32))
            {
                using (StreamWriter sw = new StreamWriter(memory))
                {
                    provider.GenerateCodeFromCompileUnit(unit, sw, options);
                    sw.Flush();
                    memory.Position = 0;
                    string text = string.Empty;
                    var p = 0;
                    while (true)
                    {
                        byte[] buffer = new byte[1024];
                        var len = memory.Read(buffer, 0, 1024);
                        p += len;
                        text += Encoding.UTF8.GetString(buffer, 0, len);
                        if (len < 1024)
                        {
                            break;
                        }
                    }

                    return string.Join(Environment.NewLine, text.Split(Environment.NewLine).ToList().Skip(9).ToArray());
                }
            }
        }

        /// <summary>
        /// 创建出参类
        /// </summary>
        /// <param name="table">表</param>
        /// <param name="columns">列</param>
        /// <returns>脚本</returns>
        private string CreateRto(AbpTable table, List<AbpColumn> columns)
        {
            CodeCompileUnit unit = new CodeCompileUnit();
            CodeNamespace ns = new CodeNamespace(table.Namespace);
            ns.Imports.Add(new CodeNamespaceImport("System"));
            ns.Imports.Add(new CodeNamespaceImport("YuanTu.Platform.Common.Dto"));
            unit.Namespaces.Add(ns);
            CodeTypeDeclaration cls = new CodeTypeDeclaration($"{table.Code}Rto");
            ns.Types.Add(cls);

            cls.Comments.AddRange(AddComments(table.Name, true).ToArray());

            if (table.IsParent)
            {
                if (table.IsDistinatOrg)
                {
                    cls.BaseTypes.Add(new CodeTypeReference($"ParentCustomEntityWithOrgDto<string>"));
                }
                else
                {
                    cls.BaseTypes.Add(new CodeTypeReference($"ParentCustomEntityDto<string>"));
                }
            }
            else
            {
                if (table.IsDistinatOrg)
                {
                    cls.BaseTypes.Add(new CodeTypeReference($"CustomEntityWithOrgDto<string>"));
                }
                else
                {
                    cls.BaseTypes.Add(new CodeTypeReference($"CustomEntityDto<string>"));
                }
            }

            foreach (var col in columns)
            {
                CodeMemberField field = new CodeMemberField(GetType(col.DataType), $"_{col.Code}");
                field.Attributes = MemberAttributes.Private;
                //field.InitExpression = new CodeArrayCreateExpression("System.Int32", 10);
                cls.Members.Add(field);

                // 属性
                CodeMemberProperty prop = new CodeMemberProperty();
                prop.Name = col.Code;
                // 属性值的类型
                prop.Type = new CodeTypeReference(GetType(col.DataType));
                // 公共属性
                prop.Attributes = MemberAttributes.Public | MemberAttributes.Final;

                prop.Comments.AddRange(AddComments(col.Name).ToArray());

                prop.GetStatements.Add(new CodeMethodReturnStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), field.Name)));

                //set
                prop.SetStatements.Add(new CodeAssignStatement(new CodeFieldReferenceExpression(new CodeThisReferenceExpression(), field.Name), new CodePropertySetValueReferenceExpression()));


                cls.Members.Add(prop);
            }

            var provider = CodeDomProvider.CreateProvider("CSharp");

            CodeGeneratorOptions options = new CodeGeneratorOptions();

            options.BracingStyle = "C";

            options.BlankLinesBetweenMembers = true;

            using (MemoryStream memory = new MemoryStream(1024 * 32))
            {
                using (StreamWriter sw = new StreamWriter(memory))
                {
                    provider.GenerateCodeFromCompileUnit(unit, sw, options);
                    sw.Flush();
                    memory.Position = 0;
                    string text = string.Empty;
                    var p = 0;
                    while (true)
                    {
                        byte[] buffer = new byte[1024];
                        var len = memory.Read(buffer, 0, 1024);
                        p += len;
                        text += Encoding.UTF8.GetString(buffer, 0, len);
                        if (len < 1024)
                        {
                            break;
                        }
                    }

                    return string.Join(Environment.NewLine, text.Split(Environment.NewLine).ToList().Skip(9).ToArray());
                }
            }
        }

        /// <summary>
        /// 生成前端实体类
        /// </summary>
        /// <param name="table">表</param>
        /// <param name="columns">列</param>
        /// <returns>脚本</returns>
        private string CreateEntityTs(AbpTable table, List<AbpColumn> columns)
        {
            StringBuilder stbCode = new StringBuilder();

            stbCode.AppendLine("import Entity from '@/store/entities/entity'");

            stbCode.AppendLine();
            stbCode.AppendLine("/*");
            stbCode.AppendLine($"* {table.Name}");
            AddAbpComments(stbCode);
            stbCode.AppendLine("*/");
            stbCode.AppendLine($"export default class {table.Code} extends Entity<string>{{");
            foreach (var col in columns)
            {
                stbCode.AppendLine($"    {col.Code.ToSplitCamelCase()}:{GetTsType(col.DataType)}".PadRight(72, ' ') + $"// {col.Name}");
            }
            stbCode.Append("}");

            return stbCode.ToString();
        }

        /// <summary>
        /// 生成前端服务类
        /// </summary>
        /// <param name="table">表</param>
        /// <param name="columns">列</param>
        /// <returns>脚本</returns>
        private string CreateModule(AbpTable table, List<AbpColumn> columns)
        {
            StringBuilder stbCode = new StringBuilder();

            stbCode.AppendLine("import AbpModule from '@/store/base/module/abplist'");
            stbCode.AppendLine($"import {table.Code} from '@/store/entities/{GetSubfolder(table, true)}/{table.Code.ToLower()}'");

            stbCode.AppendLine();
            stbCode.AppendLine("/*");
            stbCode.AppendLine($"* {table.Name}服务");
            AddAbpComments(stbCode);
            stbCode.AppendLine("*/");

            stbCode.AppendLine($"class {table.Code}Module extends AbpModule<{table.Code}> {{");
            stbCode.AppendLine("    constructor(){");
            stbCode.AppendLine($"        super(\"{table.Code.ToLower()}\");");
            stbCode.AppendLine("    }");
            stbCode.AppendLine("}");
            stbCode.AppendLine($"const {table.Code.ToLower()}module = new {table.Code}Module()");
            stbCode.AppendLine($"export default {table.Code.ToLower()}module;");

            return stbCode.ToString();
        }

        /// <summary>
        /// 生成主页
        /// </summary>
        /// <param name="table">表</param>
        /// <param name="columns">列</param>
        /// <param name="pageType">页面类型</param>
        /// <returns>脚本</returns>
        private string CreateMainVue(AbpTable table, List<AbpColumn> columns, int pageType = 0)
        {
            StringBuilder stbCode = new StringBuilder();

            stbCode.AppendLine("import AbpModule from '@/store/base/module/abplist'");
            stbCode.AppendLine($"import {table.Code} from '@/store/entities/{GetSubfolder(table, true)}/{table.Code.ToLower()}'");

            stbCode.AppendLine();
            stbCode.AppendLine("/*");
            stbCode.AppendLine($"* {table.Name}服务");
            AddAbpComments(stbCode);
            stbCode.AppendLine("*/");

            stbCode.AppendLine($"export default class {table.Code}Module extends AbpModule<{table.Code}> {{");
            stbCode.AppendLine("    constructor(){");
            stbCode.AppendLine($"        super(\"{table.Code.ToLower()}\");");
            stbCode.AppendLine("    }");
            stbCode.AppendLine("}");

            return stbCode.ToString();
        }

        /// <summary>
        /// 生成编辑页
        /// </summary>
        /// <param name="table">表</param>
        /// <param name="columns">列</param>
        /// <returns>脚本</returns>
        private string CreateEditVue(AbpTable table, List<AbpColumn> columns)
        {
            StringBuilder stbCode = new StringBuilder();

            stbCode.AppendLine("import AbpModule from '@/store/base/module/abplist'");
            stbCode.AppendLine($"import {table.Code} from '@/store/entities/{GetSubfolder(table, true)}/{table.Code.ToLower()}'");

            stbCode.AppendLine();
            stbCode.AppendLine("/*");
            stbCode.AppendLine($"* {table.Name}服务");
            AddAbpComments(stbCode);
            stbCode.AppendLine("*/");

            stbCode.AppendLine($"export default class {table.Code}Module extends AbpModule<{table.Code}> {{");
            stbCode.AppendLine("    constructor(){");
            stbCode.AppendLine($"        super(\"{table.Code.ToLower()}\");");
            stbCode.AppendLine("    }");
            stbCode.AppendLine("}");

            return stbCode.ToString();
        }

        /// <summary>
        /// 获取TypeScript数据类型
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        private string GetTsType(string dataType)
        {
            var type = "string";

            switch (dataType.ToLower())
            {
                case "long":
                case "decimal":
                case "int":
                    type = "number";
                    break;
                case "bool":
                case "boolean":
                    type = "boolean";
                    break;
                case "datetime":
                    type = "Date";
                    break;
                default:
                    type = "string";
                    break;
            }

            return type;
        }

        /// <summary>
        /// 获取数据类型
        /// </summary>
        /// <param name="dataType"></param>
        /// <returns></returns>
        private Type GetType(string dataType)
        {
            Type type = typeof(string);

            switch (dataType.ToLower())
            {
                case "long":
                    type = typeof(long);
                    break;
                case "bool":
                    type = typeof(bool);
                    break;
                case "decimal":
                    type = typeof(decimal);
                    break;
                case "text":
                    type = typeof(string);
                    break;
                case "int":
                    type = typeof(int);
                    break;
                case "datetime":
                    type = typeof(DateTime);
                    break;
            }

            return type;
        }

        private void AddAbpComments(StringBuilder stbCode)
        {
            if (AbpSession.UserId == null)
            {
                stbCode.AppendLine($"* 作者: 系统用户");
            }
            else
            {

            }
            stbCode.AppendLine($"* 生成时间: {DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss")}");
        }

        /// <summary>
        /// 添加多行注释
        /// </summary>
        /// <param name="comment"></param>
        /// <returns></returns>
        private List<CodeCommentStatement> AddComments(string comment, bool author = false)
        {
            var list = new List<CodeCommentStatement>();

            list.Add(new CodeCommentStatement(new CodeComment("<summary>", true)));
            list.Add(new CodeCommentStatement(new CodeComment(comment, true)));
            if (author)
            {
                if (AbpSession.UserId == null)
                {
                    list.Add(new CodeCommentStatement(new CodeComment($"作者: 系统用户", true)));
                }
                else
                {

                }
                list.Add(new CodeCommentStatement(new CodeComment($"生成时间: {DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss")}", true)));
            }
            list.Add(new CodeCommentStatement(new CodeComment("</summary>", true)));

            return list;
        }

        /// <summary>
        /// 获取分页入参
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private string GetFilter(AbpTable table)
        {
            string filter = "ParentCustomPagedAndSortedWithOrgDto";
            if (table.IsParent)
            {
                if (table.IsDistinatOrg)
                {
                    filter = "CustomPagedAndSortedWithOrgDto";
                }
                else
                {
                    filter = "CustomPagedAndSortedDto";
                }
            }
            else if (table.IsDetail)
            {
                if (table.IsDistinatOrg)
                {
                    filter = "ParentCustomPagedAndSortedWithOrgDto<string>";
                }
                else
                {
                    filter = "ParentCustomPagedAndSortedDto<string>";
                }
            }
            else
            {
                if (table.IsDistinatOrg)
                {
                    filter = "CustomPagedAndSortedWithOrgDto";
                }
                else
                {
                    filter = "CustomPagedAndSortedDto";
                }
            }

            return filter;
        }

        /// <summary>
        /// 获取子文件夹名
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        private string GetSubfolder(AbpTable table, bool isVue = false)
        {
            var splits = table.Code.Split("_");
            var folder = string.Empty;
            if (splits.Length > 0)
            {
                folder = splits[0];
            }
            else if (!string.IsNullOrEmpty(table.Namespace))
            {
                splits = table.Name.Split(".");

                folder = splits.Last();
            }
            else
            {
                folder = "Sys";
            }

            if (isVue)
            {
                folder = folder.ToLower();
            }

            return folder;
        }
    }
}