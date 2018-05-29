using System.Linq;
using Chap08_04.Filters;
using Chap08_04.Models;
using Chap08_04.Persistence;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Chap08_04.Controllers
{
    [Route("api/product")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        [Route("productlist")]
        public IActionResult GetList()
        {
            var productvm = _productRepository.GetAll().Select(ToProductvm).ToList();

            return new OkObjectResult(productvm);
        }

        [HttpGet]
        [Route("{productid}")]
        public IActionResult GetProduct(string productid)
        {
            var productModel = _productRepository.GetByProduct(productid);

            return new OkObjectResult(productModel.Select(ToProductvm).ToList());
        }

        [HttpGet]
        [Route("{productname}")]
        public IActionResult Get(string productname)
        {
            var productModel = _productRepository.GetBy(productname);

            return new OkObjectResult(productModel.Select(ToProductvm).ToList());
        }

        [HttpPost]
        [Route("addproduct")]
        [ValidateInput]
        [Authorize]
        public IActionResult Post([FromBody] ProductViewModel productvm)
        {
            if (productvm == null)
                return BadRequest();
            var productModel = ToProductModel(productvm);

            _productRepository.Add(productModel);

            return StatusCode(201, Json(true));
        }


        private Product ToProductModel(ProductViewModel productvm)
        {
            return new Product
            {
                CategoryId = productvm.CategoryId,
                Description = productvm.ProductDescription,
                Id = productvm.ProductId,
                Name = productvm.ProductName,
                Price = productvm.ProductPrice,
                Image = productvm.ProductImage,
                InStock = 1, //Calculate it
                Category = _productRepository.GetBy(productvm.CategoryId).FirstOrDefault()
            };
        }

        private ProductViewModel ToProductvm(Product productModel)
        {
            return new ProductViewModel
            {
                CategoryId = productModel.CategoryId,
                CategoryDescription = productModel.Category?.Description,
                CategoryName = productModel.Category?.Name,
                ProductDescription = productModel.Description,
                ProductId = productModel.Id,
                ProductImage = productModel.Image,
                ProductName = productModel.Name,
                ProductPrice = productModel.Price
               
            };
        }
    }
}