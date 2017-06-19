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
            target.AddItem(p1, 1);
            target.AddItem(p2, 2);

            Cart.CartLine[] results = target.Lines.ToArray();

            //Asset 
            Assert.Equal(2, results.Length);
            Assert.Equal(p1, results[0].Prooduct);
            Assert.Equal(p2, results[1].Prooduct);

        }

        [Fact]
        public void Can_Add_To_Existing_Lines()
        {
            //Arrange
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };

            Cart target = new Cart();

            //Act
            target.AddItem(p1, 1);
            target.AddItem(p2, 1);
            target.AddItem(p1, 10);

            Cart.CartLine[] results = target.Lines.ToArray();

            //Assert

            Assert.Equal(2, results.Length);
            Assert.Equal(11, results[0].Quantity);
            Assert.Equal(1, results[1].Quantity);

        }

        [Fact]
        public void Can_Remove_Line()
        {
            //Arrange
            Product p1 = new Product { ProductID = 1, Name = "P1" };
            Product p2 = new Product { ProductID = 2, Name = "P2" };
            Product p3 = new Product { ProductID = 3, Name = "P3" };

            Cart target = new Cart();

            target.AddItem(p1, 1);
            target.AddItem(p2, 3);
            target.AddItem(p3, 6);
            target.AddItem(p1, 1);

            //Act
            target.RemoveItem(p2);

            //Assert
            Assert.Equal(2, target.Lines.Count());
            Assert.Equal(0, target.Lines.Where(c => c.Prooduct == p2).Count());

        }

        [Fact]
        public void Can_Calculate_Total()
        {
            //Arrange
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 20.50m };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 10 };

            Cart target = new Cart();

            //Act
            target.AddItem(p1, 1);
            target.AddItem(p2, 3);
            target.AddItem(p1, 4);
            decimal resut = target.GetTotalValue();

            //Assert
            Assert.Equal(132.5m, resut);
        }

        [Fact]
        public void Can_Remove_All_Items()
        {
            //Arrange 
            Product p1 = new Product { ProductID = 1, Name = "P1", Price = 20.50m };
            Product p2 = new Product { ProductID = 2, Name = "P2", Price = 10 };

            Cart target = new Cart();
            target.AddItem(p1, 3);
            target.AddItem(p2, 1);

            //Act

            target.Clear();

            //Assert

            Assert.Equal(0, target.Lines.Count());

        }
    }
}
