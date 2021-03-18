using System;
using System.Collections.Generic;
using System.Text;

namespace Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T>(string key); // key e karşılık gelen datayı ver
        object Get(string key);
        void Add(string key, object value, int duration); // data ekleme
        bool IsAdd(string key); // bellekte var mı
        void Remove(string key);
        void RemovePattern(string pattern);
    
    }
}
