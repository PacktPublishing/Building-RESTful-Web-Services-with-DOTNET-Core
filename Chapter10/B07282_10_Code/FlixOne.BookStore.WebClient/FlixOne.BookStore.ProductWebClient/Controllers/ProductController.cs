using System;
using FlixOne.BookStore.ProductWebClient.Client;
using FlixOne.BookStore.ProductWebClient.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlixOne.BookStore.ProductWebClient.Controllers
{
    public class ProductController : Controller
    {
        public ActionResult Index()
        {
            var webClient = new RestSharpWebClient();
            var products = webClient.GetProducts();
            return View("ProductList", products);
        }

        public ActionResult Details(string id)
        {
            var webClient = new RestSharpWebClient();
            var products = webClient.GetProductDetails(id);
            return View(products);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(IFormCollection collection)
        {
            try
            {
                var product = new ProductViewModel
                {
                    ProductId = Guid.NewGuid(),
                    ProductName = collection["ProductName"],
                    ProductDescription = collection["ProductDescription"],
                    ProductImage = collection["ProductImage"],
                    ProductPrice = Convert.ToDecimal(collection["ProductPrice"]),
                    CategoryId = new Guid("77DD5B53-8439-49D5-9CBC-DC5314D6F190"),
                    CategoryName = collection["CategoryName"],
                    CategoryDescription = collection["CategoryDescription"]
                };

                var webClient = new RestSharpWebClient();
                var producresponse = webClient.AddProduct(product);
                if (producresponse)
                    return RedirectToAction(nameof(Index));
                throw new Exception();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Edit(string id)
        {
            var webClient = new RestSharpWebClient();
            var product = webClient.GetProductDetails(id);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(string id, IFormCollection collection)
        {
            try
            {
                var product = new ProductViewModel
                {
                    ProductId = new Guid(collection["ProductId"]),
                    ProductName = collection["ProductName"],
                    ProductDescription = collection["ProductDescription"],
                    ProductImage = collection["ProductImage"],
                    ProductPrice = Convert.ToDecimal(collection["ProductPrice"]),
                    CategoryId = new Guid(collection["CategoryId"]),
                    CategoryName = collection["CategoryName"],
                    CategoryDescription = collection["CategoryDescription"]
                };

                var webClient = new RestSharpWebClient();
                var producresponse = webClient.UpdateProduct(id, product);
                if (producresponse)
                    return RedirectToAction(nameof(Index));
                throw new Exception();
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Delete(string id)
        {
            var webClient = new RestSharpWebClient();
            var product = webClient.GetProductDetails(id);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(string id, IFormCollection collection)
        {
            try
            {
                var product = new ProductViewModel
                {
                    ProductId = new Guid(collection["ProductId"]),
                    ProductName = collection["ProductName"],
                    ProductDescription = collection["ProductDescription"],
                    ProductImage = collection["ProductImage"],
                    ProductPrice = Convert.ToDecimal(collection["ProductPrice"]),
                    CategoryId = new Guid(collection["CategoryId"]),
                    CategoryName = collection["CategoryName"],
                    CategoryDescription = collection["CategoryDescription"]
                };

                var webClient = new RestSharpWebClient();
                var producresponse = webClient.DeleteProduct(id, product);
                if (producresponse)
                    return RedirectToAction(nameof(Index));
                throw new Exception();
            }
            catch
            {
                return View();
            }
        }
    }
    
}