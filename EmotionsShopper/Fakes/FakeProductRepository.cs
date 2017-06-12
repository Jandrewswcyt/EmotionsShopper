using System;
using System.Collections.Generic;
using EmotionsShopper.DataTypes.Interfaces;
using EmotionsShopper.Models;

namespace EmotionsShopper.Fakes
{
    public class FakeProductRepository : IProductRepository
    {
        public IEnumerable<Product> Products => new List<Product>
        {
            new Product {Name = "Happiness", Price = 25},
            new Product {Name = "Sadness", Price = 10},
            new Product {Name = "Contempt", Price = 15},
            new Product {Name = "Endless Joy", Price = 30}
        }; 
    }
}
