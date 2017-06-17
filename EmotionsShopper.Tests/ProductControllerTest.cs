using System.Linq; 
using Xunit;
using Moq;
using EmotionsShopper.DataTypes.Interfaces;
using EmotionsShopper.Models;
using EmotionsShopper.Controllers;
using System.Collections.Generic;
using EmotionsShopper.Models.ViewModel;

namespace EmotionsShopper.Tests
{
    public class ProductControllerTest
    {
        [Fact]
        public void Can_Paginate()
        {
            //Arrange
            Mock<IProductRepository> prodRepMock = ArrangeProductRepository();

            ProductController controller = new ProductController(prodRepMock.Object);
            controller.ProductsPerPage = 3;
            //Act
            ProductsListViewModel result = controller.List(2).ViewData.Model as ProductsListViewModel;



            //Assert
            Product[] prodArray = result.Products.ToArray();
            Assert.True(prodArray.Length == 2);
            Assert.Equal("P4", prodArray[0].Name);
            Assert.Equal("P5", prodArray[1].Name);

        }

        [Fact]
        public void Can_Sen_Pagination_View_Model()
        {
            //Arrange
            Mock<IProductRepository> prodRepMock = ArrangeProductRepository(); 

            ProductController controller = new ProductController(prodRepMock.Object);
            controller.ProductsPerPage = 3;

            // Act
            ProductsListViewModel result = controller.List(2).ViewData.Model as ProductsListViewModel;

            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.Equal(2, pageInfo.CurrentPage);
            Assert.Equal(3, pageInfo.ItemsPerPage);
            Assert.Equal(5, pageInfo.TotalItems);
            Assert.Equal(2, pageInfo.TotalPages); 
        }

        private static Mock<IProductRepository> ArrangeProductRepository()
        {
            Mock<IProductRepository> prodRepMock = new Mock<IProductRepository>();
            prodRepMock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product{ProductID = 1, Name = "P1"},
                new Product{ProductID = 2, Name = "P2"},
                new Product{ProductID = 3, Name = "P3"},
                new Product{ProductID = 4, Name = "P4"},
                new Product{ProductID = 5, Name = "P5"},
            });
            return prodRepMock;
        }

    }
}
