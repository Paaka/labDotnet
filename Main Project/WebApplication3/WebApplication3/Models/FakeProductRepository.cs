﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>
        {
            new Product {ProductID = 1, Name = "Gran Tourismo Sport", Description = "PS4 exclusive, one of the best racing games on the market.", Price= 80, Category="Games"},
            new Product {ProductID = 2, Name = "Vampyr", Description = "Single player, Action RPG, from game studio Florent Guillaume", Price = 100, Category="Games"},
            new Product {ProductID = 3, Name = "PS5", Description="New Console from sony, brand new.", Price=1839, Category="Consoles" }
        }.AsQueryable<Product>();

        public Product DeleteProduct(int productId)
        {
            throw new NotImplementedException();
        }

        public void SaveProduct(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
