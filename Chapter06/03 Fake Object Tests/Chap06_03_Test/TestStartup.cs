using System;
using Chap06_03;
using Chap06_03.Core.Interfaces;
using Chap06_03.Core.Model;
using Chap06_03.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chap06_03_Test
{
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration) : base(configuration)
        {
        }

        public static IConfiguration InitConfiguration()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            return config;
        }

        public override void ConfigureServices(IServiceCollection services)
        {
            //for tests use InMemory db
            services.AddDbContext<ProductContext>(
                o => o.UseInMemoryDatabase(InitConfiguration().GetConnectionString("ProductConnection")));
            services.AddMvc();
            services.AddScoped<IProductRepository, ProductRepository>();
        }

        public override void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var context = app.ApplicationServices.GetService<ProductContext>();
            FakeData(context);
            app.UseStaticFiles();
            app.UseMvc();
        }

        private static void FakeData(DbContext context)
        {
            var category = new Category
            {
                Id = ToGuid("A5DBF00D-2E29-4993-A0CA-7E861272C6DC"),
                Description = "Technical Videos",
                Name = "Videos"
            };
            context.Add(category);
            var product = new Product
            {
                Id = ToGuid("02341321-C20B-48B1-A2BE-47E67F548F0F"),
                CategoryId = category.Id,
                Description = "Microservices for .NET Core",
                Image = "microservices.jpeg",
                Name = "Microservices for .NET",
                Price = 651,
                InStock = 5
            };
            context.Add(product);
            context.SaveChanges();
        }

        private static Guid ToGuid(string strGuid)
        {
            if (strGuid == string.Empty)
                throw new Exception($"Invalid paramerter:{nameof(strGuid)} ");
            return new Guid(strGuid);
        }
    }
}