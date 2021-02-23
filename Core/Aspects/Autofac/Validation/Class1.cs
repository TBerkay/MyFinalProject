using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("Doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType); // çalışma anında bir şeyleri çalıştırma // örn productvalidator instance oluştur
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; // örn productvalidator çalışma tipini bul 
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); // onun parametrelerini bul // Add(Product product) para. örn
            foreach (var entity in entities) // parametreleri gez
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
