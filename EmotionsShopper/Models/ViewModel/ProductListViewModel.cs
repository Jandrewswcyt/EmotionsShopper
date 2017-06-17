using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmotionsShopper.Models.ViewModel
{
    public class ProductListViewModel
    {

        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfor { get; set;  }
    }
}
