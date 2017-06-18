using EmotionsShopper.Controllers;
using EmotionsShopper.DataTypes.Interfaces;
using EmotionsShopper.Models;
using Moq;


namespace EmotionsShopper.Tests
{
    public static class TestCommon
    {
        public static Mock<IProductRepository> ArrangeMockProductRepository()
        {
            Mock<IProductRepository> prodRepMock = new Mock<IProductRepository>();
            prodRepMock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product{ProductID = 1, Name = "P1", Category = "C1"},
                new Product{ProductID = 2, Name = "P2", Category = "C2"},
                new Product{ProductID = 3, Name = "P3", Category = "C3"},
                new Product{ProductID = 4, Name = "P4", Category = "C4"},
                new Product{ProductID = 5, Name = "P5", Category = "C5"},
            });
            return prodRepMock;
        }

        public static Mock<IProductRepository> ArrangeMockProductRepositoryUnorderedCat()
        {
            Mock<IProductRepository> prodRepMock = new Mock<IProductRepository>();
            prodRepMock.Setup(m => m.Products).Returns(new Product[]
            {
                new Product{ProductID = 1, Name = "P1", Category = "C1"},
                new Product{ProductID = 2, Name = "P2", Category = "C2"},
                new Product{ProductID = 3, Name = "P3", Category = "C1"},
                new Product{ProductID = 4, Name = "P4", Category = "C2"},
                new Product{ProductID = 5, Name = "P5", Category = "C5"},
            });
            return prodRepMock;
        }

        public static ProductController CreateProductController(Mock<IProductRepository> prodRepMock, int productsPerPage)
        {
            ProductController controller = new ProductController(prodRepMock.Object);
            controller.ProductsPerPage = productsPerPage;
            return controller;
        }
    }
}
