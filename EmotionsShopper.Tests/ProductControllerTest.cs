using System.Linq; 
using Xunit;
using Moq;
using EmotionsShopper.DataTypes.Interfaces;
using EmotionsShopper.Models;
using EmotionsShopper.Controllers;
using System.Collections.Generic;

namespace EmotionsShopper.Tests
{
    public class ProductControllerTest
    {
        [Fact]
        public void Can_Paginate()
        {
            //Arrange
            Mock<IProductRepository> prodRepMock = new Mock<IProductRepository>();
            prodRepMock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product{ProductID = 1, Name = "P1"},
                new Product{ProductID = 2, Name = "P2"},
                new Product{ProductID = 3, Name = "P3"},
                new Product{ProductID = 4, Name = "P4"},
                new Product{ProductID = 5, Name = "P5"},
            });

            ProductController controller = new ProductController(prodRepMock.Object);
            controller.ProductsPerPage = 3;
            //Act
            IEnumerable<Product> result = controller.List(2).ViewData.Model as IEnumerable<Product>;


            //Assert
            Product[] prodArray = result.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("P4", prodArray[0].Name);
            Assert.Equal("P5", prodArray[1].Name); 

        }
    }
}
