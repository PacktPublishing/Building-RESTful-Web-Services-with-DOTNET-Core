using Chap06_02;
using Chap06_02.Core.Interfaces;
using Chap06_02.Infrastructure;
using Chap07_02;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Chap06_02_Test
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
            //mock context
            services.AddDbContext<ProductContext>(
                o => o.UseSqlServer(InitConfiguration().GetConnectionString("ProductConnection")));
            services.AddMvc();
            services.AddScoped<IProductRepository, ProductRepository>();
        }

        public override void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}