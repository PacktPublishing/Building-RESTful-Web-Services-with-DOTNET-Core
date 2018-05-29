using FlixOne.BookStore.WebClient.Client;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlixOne.BookStore.WebClient
{
    public class ProductClientController : Controller
    {
        // GET: /<controller>/
        public IActionResult Add()
        {
            return View();
        }

        public IActionResult ProductList()
        {
            var webClient = new RestSharpWebClient();
            var model = webClient.GetProducts();
            return View(model);
        }
    }
}