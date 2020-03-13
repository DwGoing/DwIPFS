using System;

namespace DwIPFS
{
    public class ResultCode
    {
        public const int Ok = 200;
        public const int CommonError = 400;
    }

    public class IpfsResult<T>
    {
        public readonly int Code;
        public readonly string Message;
        public T Data { get; set; }

        public IpfsResult(int code = ResultCode.Ok, string message = null, T data = default)
        {
            Code = code;
            Message = message;
            Data = data;
        }
    }
}
