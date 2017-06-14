using System;
using System.Collections.Generic;
using EmotionsShopper.DataTypes.Interfaces;
using EmotionsShopper.Models;

namespace EmotionsShopper.Repository
{
    public class EFProductRepository : IProductRepository
    {
        private ApplicationDbContext context;

        public IEnumerable<Product> Products => context.Products; 
    }
}
