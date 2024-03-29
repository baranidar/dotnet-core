﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chiligarlic.Data;
using Chiligarlic.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace Chiligarlic
{
     public class Startup
    {
        private IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IGreeter, Greeter>();
            //services.AddScoped<IRecipeData, InMemoryRecipeData>();
            services.AddDbContext<ChiliGarlicDbContext>(options => options.UseSqlServer(_configuration.GetConnectionString("ChiliGarlic")));
            services.AddScoped<IRecipeData, SqlRecipeData>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IGreeter greeter, ILogger <Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseDefaultFiles();
            app.UseStaticFiles();
            //app.UseFileServer();
            app.UseMvc(configureRoutes);
            //app.Use(next =>
            //{
            //    return async context =>
            //    {
            //        logger.LogInformation("Request Incoming");
            //        if (context.Request.Path.StartsWithSegments("/mym"))
            //        {
            //            await context.Response.WriteAsync("Hit!!");
            //            logger.LogInformation("Request Handled");
            //        }
            //        else
            //        {
            //            await next(context);
            //            logger.LogInformation("Response Outgoing");
            //        }
            //    };
            //}


            //);

            //app.UseWelcomePage(new WelcomePageOptions
            //{
            //    Path = "/wp"
            //});


            app.Run(async (context) =>
            {
                //throw new Exception("err");
                var greeting = greeter.GetMessageofTheDay();
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync($"Not Found");
            });
        }

        private void configureRoutes(IRouteBuilder routeBuilder)
        {
            //home/index/4
            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
