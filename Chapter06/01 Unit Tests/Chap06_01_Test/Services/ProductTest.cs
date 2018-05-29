using System.Collections.Generic;
using System.Linq;
using Chap06_01.Controllers;
using Chap06_01.Core.Interfaces;
using Chap06_01.Core.Model;
using Chap06_01_Test.Fake;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace Chap06_01_Test.Services
{
    public class ProductTests
    {
        [Fact]
        public void Get_Returns_ActionResults()
        {
            // Arrange
            var mockRepo = new Mock<IProductRepository>();
            mockRepo.Setup(repo => repo.GetAll()).Returns(new ProductData().GetProductList());
            var controller = new ProductController(mockRepo.Object);

            // Act
            var result = controller.GetList();

            // Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<ProductViewModel>>(viewResult.Value);
            Assert.NotNull(model);
            Assert.Equal(2, model.Count());
        }
    }
}