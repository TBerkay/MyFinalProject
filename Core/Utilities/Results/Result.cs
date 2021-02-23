using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        public Result(bool success, string message) : this(success) // tek parametreli constructor ı çalıştır
        {
            //Success = success; // kapatıyoruz
            Message = message;           
        }

        public Result(bool success) // overloading
        {
            Success = success;
        }

        public bool Success { get; }

        public string Message { get; }
    }
}
