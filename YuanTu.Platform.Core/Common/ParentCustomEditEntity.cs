namespace YuanTu.Platform.Common
{
    public abstract class ParentCustomEditEntity<T> : CustomEntity<T>
    {
        public virtual T ParentId
        {
            get;
            set;
        }

        /// <summary>
        /// 层级码
        /// </summary>
        //public virtual string LevelCode
        //{
        //    get;
        //    set;
        //}
    }

    public abstract class ParentCustomEditEntityNullable<T> : CustomEntity<T> where T : struct
    {
        public virtual T? ParentId
        {
            get;
            set;
        }

        /// <summary>
        /// 层级码
        /// </summary>
        //public virtual string LevelCode
        //{
        //    get;
        //    set;
        //}
    }

    public abstract class ParentCustomEditEntityWithOrg<T> : CustomEntityWithOrg<T>
    {
        public virtual T ParentId
        {
            get;
            set;
        }

        /// <summary>
        /// 层级码
        /// </summary>
        //public virtual string LevelCode
        //{
        //    get;
        //    set;
        //}
    }

    public abstract class ParentCustomEditEntityNullableWithOrg<T> : CustomEntityWithOrg<T> where T : struct
    {
        public virtual T? ParentId
        {
            get;
            set;
        }

        /// <summary>
        /// 层级码
        /// </summary>
        //public virtual string LevelCode
        //{
        //    get;
        //    set;
        //}
    }

    public abstract class ParentCustomCreationEntity<T> : CustomCreationEntity<T>
    {
        public virtual T ParentId
        {
            get;
            set;
        } 
    }

    public abstract class ParentCustomCreationEntityNullable<T> : CustomCreationEntity<T> where T : struct
    {
        public virtual T? ParentId
        {
            get;
            set;
        } 
    }

    public abstract class ParentCustomCreationEntityWithOrg<T> : CustomCreationEntityWithOrg<T>
    {
        public virtual T ParentId
        {
            get;
            set;
        } 
    }

    public abstract class ParentCustomCreationEntityNullableWithOrg<T> : CustomCreationEntityWithOrg<T> where T : struct
    {
        public virtual T? ParentId
        {
            get;
            set;
        } 
    }
}
