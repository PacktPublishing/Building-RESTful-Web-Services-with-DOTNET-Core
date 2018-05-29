using System.Collections.Generic;
using FlixOne.BookStore.WebClient.Models;
using RestSharp;

namespace FlixOne.BookStore.WebClient.Client
{
    public class RestSharpWebClient
    {
        private readonly RestClient _client = new RestClient("http://localhost:10065/api/");

        public List<Product> GetProducts()
        {
            var request = new RestRequest("productlist", Method.GET);
            var response = _client.Execute<List<Product>>(request);
            return response.Data;
        }
    }
}