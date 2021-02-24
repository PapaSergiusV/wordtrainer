using System;

namespace Vocabulary.AppExceptions
{
    public class RequestArgumentException : Exception
    {
        public readonly int Code;
        public RequestArgumentException(string message, int code) : base(message)
        {
            Code = code;
        }
    }
}