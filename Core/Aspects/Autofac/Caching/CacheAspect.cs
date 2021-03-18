using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Interceptors;
using Core.Utilities.IoC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Extensions.DependencyInjection;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        public CacheAspect(int duration = 60) // 60 dk da bir silinmesi için duration
        {
            _duration = duration;
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
        }

        public override void Intercept(IInvocation invocation)
        {
            // key için metod adı
            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            var arguments = invocation.Arguments.ToList();

            // parametre yoksa null, sadece metod adı kalır
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            
            // breakpoint koyabilirsin 
            if (_cacheManager.IsAdd(key)) // cache te varsa if içindekiler çalışır
            {
                // returnvalue, metodun return değeri şu olsun demek
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }

            // cache de yoksa bu kısım çalışır
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
