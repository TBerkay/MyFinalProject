using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    // veri döndüren fonk lar için
    public interface IDataResult<T> : IResult
    {
        T Data { get; }
    }
}
