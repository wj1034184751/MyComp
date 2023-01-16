using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YuanTu.Platform.Print
{
    public class Result
    {
        /// <summary>
        /// 默认调用成功函数
        /// </summary>
        public Result()
            : this(0)
        {
        }

        public Result(int code, string msg = "")
        {
            this.Code = code;
            this.Msg = msg;
        }

        public virtual int Code { get; set; }

        public virtual string Msg { get; set; }

        public static Result Fail(string msg)
        {
            return new Result(-1, msg);
        }

        public static Result Fail(int code, string msg)
        {
            return new Result(code, msg);
        }

        public static Result Success()
        {
            return new Result(0, "");
        }

        public static implicit operator bool(Result result)
        {
            return result.Code == 0;
        }

        [JsonProperty("success")]
        public virtual bool IsSuccess
        {
            get
            {
                return Code == 0;
            }
            set
            {
            }
        }

        public string TraceId { get; set; }
    }

    public class Result<T> : Result
    {
        public Result()
        {
            this.Code = 0;
            this.Msg = "";
            this.Data = default(T);
        }

        public Result(int code, string msg, T data = default(T))
        {
            this.Code = code;
            this.Msg = msg;
            this.Data = data;
        }

        public T Data
        {
            get; set;
        }

        public new static Result<T> Fail(string msg)
        {
            return new Result<T>() { Code = -1, Msg = msg };
        }

        public new static Result<T> Fail(int code, string msg)
        {
            return new Result<T>() { Code = code, Msg = msg };
        }

        public static Result<T> Success(T data)
        {
            return new Result<T>() { Code = 0, Msg = "", Data = data };
        }
    }

    public class Result<T, T1> : Result<T>
    {
        public T1 Data1 { get; set; }

        public new static Result<T, T1> Fail(string msg)
        {
            return new Result<T, T1>() { Code = -1, Msg = msg };
        }

        public new static Result<T, T1> Fail(int code, string msg)
        {
            return new Result<T, T1>() { Code = code, Msg = msg };
        }

        public static Result<T, T1> Success(T data, T1 data1)
        {
            return new Result<T, T1>() { Code = 0, Msg = "", Data = data, Data1 = data1 };
        }
    }
    public class Result<T, T1, T2> : Result<T, T1>
    {
        public T2 Data2 { get; set; }

        public new static Result<T, T1, T2> Fail(string msg)
        {
            return new Result<T, T1, T2>() { Code = -1, Msg = msg };
        }

        public new static Result<T, T1, T2> Fail(int code, string msg)
        {
            return new Result<T, T1, T2>() { Code = code, Msg = msg };
        }

        public static Result<T, T1, T2> Success(T data, T1 data1, T2 data2)
        {
            return new Result<T, T1, T2>() { Code = 0, Msg = "", Data = data, Data1 = data1, Data2 = data2 };
        }
    }
}