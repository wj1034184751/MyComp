using System.Collections.Generic;

namespace YuanTu.Platform
{
    public class ExtranetResultEx<T>
    {
        private ExtranetResultEx()
        {
        }

        public int ResultCode { get; set; }

        public string ErrorMsg { get; set; } = "";

        public T ResultData { get; set; }


        public static ExtranetResultEx<T> Fail(int code, string msg)
        {
            return new ExtranetResultEx<T>() { ResultCode = code, ErrorMsg = msg };
        }

        public static ExtranetResultEx<T> Success(T item)
        {
            return new ExtranetResultEx<T>() { ResultData = item };
        }
    }

    public class ResultList<T>
    {
        public List<T> RecordList { get; set; }
    }

    public class PageResultList<T>
    {
        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public int TotalItem { get; set; }

        public List<T> RecordList { get; set; }
    }
}
