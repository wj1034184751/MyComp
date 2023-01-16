using Abp.Application.Services.Dto;

namespace YuanTu.Platform.Common.Dto
{
    public interface IWithParent<T>
    {
        T Mid { get; set; }
    }
    public interface IWithOrg
    {
        long? OrgId { get; set; }
    } 

    public class CustomPagedAndSortedDto : PagedAndSortedResultRequestDto
    {
        public string Keyword { get; set; }
    }

    public class CustomPagedAndSortedtDto<T> : CustomPagedAndSortedDto
    {
        public T Input { get; set; }
    }

    public class ParentCustomPagedAndSortedWithOrgDto : CustomPagedAndSortedWithOrgDto
    {
        public string Mid { get; set; }
    }

    public class CustomPagedAndSortedWithOrgDto : CustomPagedAndSortedDto, IWithOrg
    {
        public long? OrgId { get; set; }
    }

    public class CustomPagedAndSortedWithOrgDto<T> : CustomPagedAndSortedtDto<T>, IWithOrg
    {
        public long? OrgId { get; set; }
    }

    public class ParentCustomPagedAndSortedDto<TP> : PagedAndSortedResultRequestDto, IWithParent<TP>
    {
        public TP Mid { get; set; }
        public string Keyword { get; set; }
    }

    public class ParentCustomPagedAndSortedtDto<T, TP> : CustomPagedAndSortedDto, IWithParent<TP>
    {
        public TP Mid { get; set; }

        public T Input { get; set; }
    }

    public class ParentCustomPagedAndSortedWithOrgDto<TP> : CustomPagedAndSortedDto, IWithOrg, IWithParent<TP>
    {
        public TP Mid { get; set; }

        public long? OrgId { get; set; }
    }

    public class ParentCustomPagedAndSortedWithOrgDto<T, TP> : CustomPagedAndSortedtDto<T>, IWithOrg, IWithParent<TP>
    {
        /// <summary>
        /// 父节点Id
        /// </summary>
        public TP Mid { get; set; }

        /// <summary>
        /// 机构ID
        /// </summary>
        public long? OrgId { get; set; }
    }
}
