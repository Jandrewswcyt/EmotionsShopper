using System.Linq; 
using Xunit;
using Moq;
using EmotionsShopper.DataTypes.Interfaces;
using EmotionsShopper.Models;
using EmotionsShopper.Controllers;
using EmotionsShopper.Models.ViewModel;

namespace EmotionsShopper.Tests
{
    public class ProductControllerTest
    {
        [Fact]
        public void Can_Paginate()
        {
            //Arrange
            Mock<IProductRepository> prodRepMock = TestCommon.ArrangeMockProductRepository();

            ProductController controller = TestCommon.CreateProductController(prodRepMock,3);
            //Act
            ProductsListViewModel result = controller.List(null, 2).ViewData.Model as ProductsListViewModel;



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
            Mock<IProductRepository> prodRepMock = TestCommon.ArrangeMockProductRepository();

            ProductController controller = TestCommon.CreateProductController(prodRepMock, 3); 

            // Act
            ProductsListViewModel result = controller.List(null,2).ViewData.Model as ProductsListViewModel;

            // Assert
            PagingInfo pageInfo = result.PagingInfo;
            Assert.Equal(2, pageInfo.CurrentPage);
            Assert.Equal(3, pageInfo.ItemsPerPage);
            Assert.Equal(5, pageInfo.TotalItems);
            Assert.Equal(2, pageInfo.TotalPages); 
        }

        [Fact]
        public void Can_Filter_Products()
        {
            //Arrange
            Mock<IProductRepository> prodRepMock = TestCommon.ArrangeMockProductRepositoryUnorderedCat();

            ProductController controller = TestCommon.CreateProductController(prodRepMock, 3); 

            //Act

            Product[] result = (controller.List("C2",1).ViewData.Model as ProductsListViewModel).Products.ToArray();

            //Assert
            Assert.Equal(2, result.Length);
            Assert.True(result[0].Name == "P2" && result[0].Category == "C2");
            Assert.True(result[1].Name == "P4" && result[1].Category == "C2"); 
          

        }




    }
}
