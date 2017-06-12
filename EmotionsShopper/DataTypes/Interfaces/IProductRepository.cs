using System;
using System.Collections.Generic;
using EmotionsShopper.Models;

namespace EmotionsShopper.DataTypes.Interfaces
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
    }
}
