namespace YuanTu.Platform.Common.Dto
{
    public class ParentCustomEntityDto<TPrimaryKey> : CustomEntityDto<TPrimaryKey>
    {
        public TPrimaryKey ParentId
        {
            get;
            set;
        }
    } 

    public abstract class ParentNullableCustomEditEntityDto<TPrimaryKey> : CustomEntityDto<TPrimaryKey> where TPrimaryKey : struct
    {
        public TPrimaryKey? ParentId
        {
            get;
            set;
        }
    }
    public class ParentCustomEntityWithOrgDto<TPrimaryKey> : CustomEntityWithOrgDto<TPrimaryKey>
    {
        public TPrimaryKey ParentId
        {
            get;
            set;
        }
    }

    public abstract class ParentNullableCustomEditEntityWithOrgDto<TPrimaryKey> : CustomEntityWithOrgDto<TPrimaryKey> where TPrimaryKey : struct
    {
        public TPrimaryKey? ParentId
        {
            get;
            set;
        }
    }
}
