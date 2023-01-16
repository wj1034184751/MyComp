using Abp.Application.Services.Dto;

namespace YuanTu.Platform.Common.Dto
{
    public class CustomEntityDto<TPrimaryKey> : FullAuditedEntityDto<TPrimaryKey>
    {
        public long? TenantId
        {
            get;
            set;
        }

        public string Remark
        {
            get;
            set;
        }
    }

    public class CustomCreationEntityDto<TPrimaryKey> : CreationAuditedEntityDto<TPrimaryKey>
    {
        public long? TenantId
        {
            get;
            set;
        }

        public string Remark
        {
            get;
            set;
        }
    }

    public class CustomEntityWithOrgDto<TPrimaryKey> : CustomEntityDto<TPrimaryKey>
    {
        public long OrgId
        {
            get;
            set;
        }
    }

    public class CustomCreationEntityWithOrgDto<TPrimaryKey> : CustomCreationEntityDto<TPrimaryKey>
    {
        public long OrgId
        {
            get;
            set;
        }
    }
}