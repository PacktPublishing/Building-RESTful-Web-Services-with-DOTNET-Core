using System.Collections.Generic;
using System.Linq;
using FlixOneProductServices.Controllers;
using FlixOneProductServices.Core.Interfaces;
using FlixOneProductServices.Core.Model;
using FlixOneProductServices_Test.Fake;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace FlixOneProductServices_Test.Services
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