using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace YuanTu.Platform.Common
{
    public abstract class CustomEntity<T> : FullAuditedEntity<T>, IMayHaveTenant
    {
        public virtual int? TenantId
        {
            get;
            set;
        }

        public virtual string Remark
        {
            get;
            set;
        }
    }

    public abstract class CustomCreationEntity<T> : CreationAuditedEntity<T>, IMayHaveTenant
    {
        public virtual int? TenantId
        {
            get;
            set;
        }

        public virtual string Remark
        {
            get;
            set;
        }
    }

    public abstract class CustomEntityWithOrg<T> : CustomEntity<T>
    {
        public virtual long OrgId
        {
            get;
            set;
        }
    }

    public abstract class CustomCreationEntityWithOrg<T> : CustomCreationEntity<T>
    {
        public virtual long OrgId
        {
            get;
            set;
        }
    }
}
