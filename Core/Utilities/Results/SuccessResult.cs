using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        // gönderilen parametreler base classtaki parametrelere uymalı
        public SuccessResult(string message) : base(true,message) // base class a true değeri ve message gönderiyoruz
        {

        }

        public SuccessResult():base(true) // message olmadan sadece true değer
        {

        }
    }
}
