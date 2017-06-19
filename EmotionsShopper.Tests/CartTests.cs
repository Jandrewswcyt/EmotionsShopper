using System;
using System.Linq;
using EmotionsShopper.Models;
using Xunit; 
namespace EmotionsShopper.Tests
{
    public class CartTests
    {
        [Fact]
        public void Can_Add_Cart_Lines()
        {
            //Arrange 
            Product p1 = new Product { ProductID = 1, Name = "P1" }; 
            Product p2 = new Product { ProductID = 2, Name = "P2" };

            Cart target = new Cart();

            //Act 
            target.AddItem(p1,1); 
            target.AddItem(p2,2);

            Cart.CartLine[] results = target.Lines.ToArray();

            //Asset 
            Assert.Equal(2,results.Length); 
            Assert.Equal(p1,results[0].Prooduct);
			Assert.Equal(p2, results[1].Prooduct);

		}
    }
}
