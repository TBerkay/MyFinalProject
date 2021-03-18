using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.IoC
{
    //framework katmanı
    public interface ICoreModule // tüm projelerimizde kullanabilceğimiz kodları içeren yapıdır
    {
        void Load(IServiceCollection serviceCollection); // yükleme işini servicecollection yapacak
    }
}
