using Chap05_02.Core.Interfaces;
using Chap05_02.Core.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using Chap05_02.Core.Logging;
using Microsoft.Extensions.Logging;

namespace Chap05_02.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        //private readonly IProductRepository _productRepository;
        //private readonly ILogger<ProductController> _logger;

        //public ProductController(IProductRepository productRepository, ILogger<ProductController> logger)
        //{
        //    _productRepository = productRepository;
        //    _logger = logger;
        //}

        private readonly IProductRepository _productRepository;
        private readonly ILogger _logger;

        public ProductController(IProductRepository productRepository, ILoggerFactory logger)
        {
            _productRepository = productRepository;
            _logger = logger.CreateLogger("Product logger");
        }

        [HttpGet]
        [Route("productlist")]
        public IActionResult GetList()
        {
            _logger.LogInformation(LogActions.ListProducts, "Getting all products.");
            return new OkObjectResult(_productRepository.GetAll().Select(ToProductvm).ToList());
        }

        [HttpGet]
        [Route("product/{productid}")]
        public IActionResult Get(string productId)
        {
            var productModel = _productRepository.GetBy(new Guid(productId));

            return new OkObjectResult(ToProductvm(productModel));
        }

        [HttpPost]
        [Route("addproduct")]
        public IActionResult Post([FromBody] ProductViewModel productvm)
        {
            if (productvm == null)
                return BadRequest();
            var productModel = ToProductModel(productvm);

            _productRepository.Add(productModel);

            return StatusCode(201, Json(true));
        }

        [HttpPut]
        [Route("updateproduct/{productid}")]
        public IActionResult Update(string productid, [FromBody] ProductViewModel productvm)
        {
            var productId = new Guid(productid);
            if (productvm == null || productvm.ProductId != productId)
                return BadRequest();

            var product = _productRepository.GetBy(productId);
            if (product == null)
                return NotFound();

            product.Name = productvm.ProductName;
            product.Description = productvm.ProductDescription;
            _productRepository.Update(product);
            return new NoContentResult();
        }

        [HttpDelete]
        [Route("deleteproduct/{productid}")]
        public IActionResult Delete(string productid)
        {
            var productId = new Guid(productid);
            var product = _productRepository.GetBy(productId);
            if (product == null)
                return NotFound();

            _productRepository.Remove(productId);
            return new NoContentResult();
        }

        private Product ToProductModel(ProductViewModel productvm)
        {
            return new Product
            {
                CategoryId = productvm.CategoryId,
                Description = productvm.ProductDescription,
                Id = productvm.ProductId,
                Name = productvm.ProductName,
                Price = productvm.ProductPrice
            };
        }

        private ProductViewModel ToProductvm(Product productModel)
        {
            return new ProductViewModel
            {
                CategoryId = productModel.CategoryId,
                CategoryDescription = productModel.Category.Description,
                CategoryName = productModel.Category.Name,
                ProductDescription = productModel.Description,
                ProductId = productModel.Id,
                ProductImage = productModel.Image,
                ProductName = productModel.Name,
                ProductPrice = productModel.Price
            };
        }
    }
}