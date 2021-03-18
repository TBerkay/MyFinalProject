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
            if (!typeof(IValidator).IsAssignableFrom(validatorType)) // validator olup olmadğını kontrol ediyoruz
            {
                throw new System.Exception("Doğrulama sınıfı değil");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            // çalışma anında instance oluşturma
            // product validator new lendi
            var validator = (IValidator)Activator.CreateInstance(_validatorType); // çalışma anında bir şeyleri çalıştırma // örn productvalidator instance oluştur
            
            // Productvalidator base ine git (abstractvalidator), onun generic parametrelerinden 0. indeksinin tipini yakala (Product)
            var entityType = _validatorType.BaseType.GetGenericArguments()[0]; // örn productvalidator çalışma tipini bul 
            
            // metodun argumanlarını gez(Add), ordaki tip entitytype(product) eşitse onları validate et
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType); // onun parametrelerini bul // Add(Product product) para. örn        
            foreach (var entity in entities) // parametreleri gez
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
