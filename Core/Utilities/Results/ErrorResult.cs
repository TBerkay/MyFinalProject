﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    {
        // gönderilen parametreler base classtaki parametrelere uymalı
        public ErrorResult(string message) : base(false, message) // base class a false değeri ve message gönderiyoruz
        {

        }

        public ErrorResult() : base(false) // message olmadan sadece false değer
        {

        }
    }
}
