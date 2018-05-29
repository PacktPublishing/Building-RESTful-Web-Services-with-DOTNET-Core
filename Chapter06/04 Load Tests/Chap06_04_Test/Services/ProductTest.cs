using System;
using System.Net.Http;
using Xunit;
using Xunit.Abstractions;

namespace Chap06_04_Test.Services
{
    public class ProductTest
    {
        public ProductTest(ITestOutputHelper output)
        {
            _output = output;
        }

        private const double ExpectedRequestTime = 115000;
        private const int ApiLoad = 100;
        private const string RequestUri = "http://localhost:60431/api/product/productlist";
        private readonly ITestOutputHelper _output;

        private static double RequestCallTime()
        {
            DateTime start;
            DateTime end;
            using (var client = new HttpClient())
            {
                start = DateTime.Now;
                var response = client.GetAsync(RequestUri).Result;
                end = DateTime.Now;
            }

            var actual = (end - start).TotalMilliseconds;
            return actual;
        }
        [Fact]
        public void SingleCallRequestTime()
        {
            var actual = RequestCallTime();
            _output.WriteLine($"Actual time: {actual} millisecond. Expected time: {ExpectedRequestTime} millisecond.");
            Assert.True(actual <= ExpectedRequestTime);
        }
        [Fact]
        public void MultipleCallRequestTime()
        {
            double actual = 0;
            for (var apiLoadCounter = 0; apiLoadCounter < ApiLoad; apiLoadCounter++)
                //_output.WriteLine($"Requesting call: {apiLoadCounter}");
                actual += RequestCallTime();

            _output.WriteLine($"Actual time: {actual} millisecond. Expected time: {ExpectedRequestTime} millisecond.");
            Assert.True(actual <= ExpectedRequestTime);
        }

        
    }
}