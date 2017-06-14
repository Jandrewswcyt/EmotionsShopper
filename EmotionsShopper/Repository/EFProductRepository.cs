using System;
using System.Collections.Generic;
using EmotionsShopper.DataTypes.Interfaces;
using EmotionsShopper.Models;

namespace EmotionsShopper.Repository
{
    public class EFProductRepository : IProductRepository
    {
        private ApplicationDbContext context;

        public EFProductRepository(ApplicationDbContext ctx)
        {
            context = ctx; 
        }

        public IEnumerable<Product> Products => context.Products; 
    }
}
