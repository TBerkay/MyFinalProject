﻿using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductManager productManager = new ProductManager(new EfProductDal()); // veya InMemoryProductDal()

            foreach (var product in productManager.GetAll())
            {
                Console.WriteLine(product.ProductName);
            }

            Console.WriteLine("--------");

            foreach (var product in productManager.GetAllByCategoryId(3))
            {
                Console.WriteLine(product.ProductName);
            }
        }
    }
}
