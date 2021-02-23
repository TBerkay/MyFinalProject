using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    // temel void işlemleri için
    public interface IResult
    {
        bool Success { get; } // başarılı başarısız için
        string Message { get; } // bilgilendirme için

    }
}
