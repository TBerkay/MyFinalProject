using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        // gönderilen parametreler base classtaki parametrelere uymalı
        public ErrorResult(string message) : base(true, message) // base class a false değeri ve message gönderiyoruz
        {

        }

        public ErrorResult() : base(true) // message olmadan sadece false değer
        {

        }
    }
}
