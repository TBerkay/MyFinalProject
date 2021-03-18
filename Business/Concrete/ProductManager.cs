using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.CCS;
using Business.Constans;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        // Servis dememizin nedeni, bir kere yaz ona ait kuralları oraya koy başkaları kullanmak isterse direkt service çağırsın

        IProductDal _productDal;
        
        ICategoryService _categoryService; // ICategoryDal yazılamaz, CATEGORY tablosunu ilgilendirdiği için service
        // kategori ile ilgili iş kuralları için fonk oluştur ve categoryservice. ile çağır

        //BİR MANAGER İÇİNDE KENDİ DALI HARİÇ BAŞKA DAL İSTENEMEZ
        public ProductManager(IProductDal productDal, ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }

        //Attribute larda tipler typeof ile alınır sadece tip gönderiyoruz, instance göndermiyoruz
        [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))] // bu metodu productvalidator kullanarak doğrula
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Add(Product product)
        {
            // validation // aspect te yaptık
            //ValidationTool.Validate(new ProductValidator(), product);

            IResult result = BusinessRules.Run(CheckCategoryCount(product.CategoryId),CheckProductName(product.ProductName),CheckCategoryLimit());

            if(result != null)
            {
                return result;
            }

            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded); // Constans message ekliyoruz

            //if (CheckCategoryCount(product.CategoryId).Success && CheckProductName(product.ProductName).Success)
            //{            
            //}
            //return new ErrorResult();

        }

        [CacheAspect]
        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 00)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductListed);
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(c => c.CategoryId == id));
        }

        [CacheAspect]
        [PerformanceAspect(5)] // 5 sn yi geçerse uyar, buraya koyarsan sadece burda çalışır, core daki interceptor a koy her yerde çalışır
        public IDataResult<Product> GetById(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(c => c.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            if (CheckCategoryCount(product.CategoryId).Success)
            {
                return new SuccessResult(Messages.ProductAdded); // Constans message ekliyoruz
            }

            return new ErrorResult();
        }

        // iş kuralı parçacığı o yüzden private, public olursa servis olur
        private IResult CheckCategoryCount(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId ==categoryId).Count;

            if (result >= 15)
            {
                return new ErrorResult(Messages.ProductCountOfCategoryError);
            }

            return new SuccessResult();
        }

        private IResult CheckProductName(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();

            if(result)
            {
                return new ErrorResult(Messages.ProductNameError);
            }

            return new SuccessResult();
        }

        private IResult CheckCategoryLimit()
        {
            var result = _categoryService.GetAll();
            if(result.Data.Count>15)
            {
                return new ErrorResult(Messages.CategoryLimitError);
            }

            return new SuccessResult();
        }

        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            Add(product);
            if(product.UnitPrice>10)
            {
                throw new Exception("");
            }
            Add(product);

            return null;
        }
    }
}
