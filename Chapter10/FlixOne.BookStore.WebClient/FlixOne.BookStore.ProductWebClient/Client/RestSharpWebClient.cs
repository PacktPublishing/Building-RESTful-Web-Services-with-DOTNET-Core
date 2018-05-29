using System.Collections.Generic;
using System.Net;
using FlixOne.BookStore.ProductWebClient.Models;
using RestSharp;

namespace FlixOne.BookStore.ProductWebClient.Client
{
    public class RestSharpWebClient
    {
        private readonly RestClient _client = new RestClient("http://localhost:10065/api/");

        public List<ProductViewModel> GetProducts()
        {
            var request = new RestRequest("product/productlist", Method.GET);
            var response = _client.Execute<List<ProductViewModel>>(request);
            //To avoid any exception lets return an empty view model
            //On production environment return exact exception or your custom code
            return response.Data ?? new List<ProductViewModel> {new ProductViewModel()};
        }

        public ProductViewModel GetProductDetails(string productId)
        {
            var request = new RestRequest("product/{productid}", Method.GET);
            request.AddParameter("productid", productId);
            var response = _client.Execute<ProductViewModel>(request);
            //To avoid any exception lets return an empty view model
            //On production environment return exact exception or your custom code
            return response.Data ?? new ProductViewModel();
        }

        public bool AddProduct(ProductViewModel product)
        {
            var request = new RestRequest("product/addproduct", Method.POST);
            request.AddBody(product);
            var response = _client.Execute(request);

            return response.StatusCode == HttpStatusCode.OK;
        }

        public bool UpdateProduct(string id, ProductViewModel product)
        {
            var request = new RestRequest("updateproduct", Method.PUT);
            request.AddQueryParameter("productid", id);
            request.AddBody(product);
            var response = _client.Execute(request);

            return response.StatusCode == HttpStatusCode.NoContent;
        }

        public bool DeleteProduct(string id, ProductViewModel product)
        {
            var request = new RestRequest("deleteproduct", Method.DELETE);
            request.AddQueryParameter("productid", id);
            request.AddBody(product);
            var response = _client.Execute(request);

            return response.StatusCode == HttpStatusCode.NoContent;
        }
    }
}