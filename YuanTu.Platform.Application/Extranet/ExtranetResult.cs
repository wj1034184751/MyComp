namespace YuanTu.Platform
{
    public class ExtranetResult<T>
    {
        private ExtranetResult()
        {
        }

        public bool success { get; set; }
        public string msg { get; set; }
        public long code { get; set; }

        public T data { get; set; }

        public static ExtranetResult<T> Fail(long code, string msg)
        {
            return new ExtranetResult<T>() { code = code, msg = msg, success = false };
        }

        public static ExtranetResult<T> Success(T item, string msg = "成功")
        {
            return new ExtranetResult<T>() { data = item, success = true, code = 0, msg = msg };
        }
    }
}
