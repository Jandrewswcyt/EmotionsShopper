using System;
using System.Collections.Generic;
using System.Linq;

namespace EmotionsShopper.Models
{
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();

        public virtual void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection.FirstOrDefault(p => p.Prooduct.ProductID == product.ProductID);

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Prooduct = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public virtual void RemoveItem(Product product)
        {
            lineCollection.RemoveAll(l => l.Prooduct.ProductID == product.ProductID);
        }

        public virtual decimal GetTotalValue() => lineCollection.Sum(e => e.Prooduct.Price * e.Quantity);

        public virtual void Clear() => lineCollection.Clear();
        public virtual IEnumerable<CartLine> Lines => lineCollection;
        public class CartLine
        {
            public int CartLineID { get; set; }
            public Product Prooduct { get; set; }
            public int Quantity { get; set; }
        }


    }
}
