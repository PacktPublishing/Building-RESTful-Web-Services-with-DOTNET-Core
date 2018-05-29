using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Chap05_01
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
        }

        //public void Configure(IApplicationBuilder app)
        //{
        //    async Task Middleware(HttpContext context, Func<Task> next)
        //    {
        //        //other stuff

        //        await next.Invoke();

        //        //other stuff
        //    }

        //    app.Use(Middleware);
        //    app.UseMvc();
        //}

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        //public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        //{
        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    }
        //   app.UseMvc();
        //}

        //public void Configure(IApplicationBuilder app, ILoggerFactory logger)
        //{
        //    logger.AddConsole();
        //    //add more stuff that does not responses client
        //    app.UseMvc();
        //    async Task RequestDelegate(HttpContext context)
        //    {
        //        await context.Response.WriteAsync("This ends the request or short circuit request.");
        //    }

        //    app.Run(RequestDelegate);
        //}

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
            app.Map("/testroute", TestRouteHandler);
            async Task RequestDelegate(HttpContext context)
            {
                await context.Response.WriteAsync("This ends the request or short circuit request.");
            }

            app.Run(RequestDelegate);
        }

        private static void  TestRouteHandler(IApplicationBuilder app)
        {
            async Task Handler(HttpContext context)
            {
                await context.Response.WriteAsync("This is called from testroute. " + 
                    "This ends the request or short circuit request.");
            }

            app.Run(Handler);
        }
    }
}

