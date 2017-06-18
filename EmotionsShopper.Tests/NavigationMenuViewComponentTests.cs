using EmotionsShopper.Components;
using EmotionsShopper.DataTypes.Interfaces;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using Moq;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace EmotionsShopper.Tests
{
    public class NavigationMenuViewComponentTests
    {
        [Fact]
        public void Can_Select_Categories()
        {
            //Arrange
            Mock<IProductRepository> mock = TestCommon.ArrangeMockProductRepositoryUnorderedCat();
            NavigationMenuViewComponent target = new NavigationMenuViewComponent(mock.Object);

            //Act
            string[] results = ((IEnumerable<string>)(target.Invoke() as ViewViewComponentResult).ViewData.Model).ToArray();

            //Assert
            Assert.True(Enumerable.SequenceEqual(new string[] { "C1", "C2", "C5" }, results)); 
        }
    }
}
