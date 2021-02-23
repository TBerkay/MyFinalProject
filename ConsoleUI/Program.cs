using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProductTest();

            //CategoryTest();

            ProductManager productManager = new ProductManager(new EfProductDal());

            var result = productManager.GetAll();

            if(result.Success)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + "/" + product.CategoryId.ToString()); ;
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
            

        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            foreach (var category in categoryManager.GetAll())
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void ProductTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal()); // veya InMemoryProductDal()

            foreach (var product in productManager.GetAll().Data)
            {
                Console.WriteLine(product.ProductName);
            }

            Console.WriteLine("--------");

            foreach (var product in productManager.GetAllByCategoryId(3).Data)
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
