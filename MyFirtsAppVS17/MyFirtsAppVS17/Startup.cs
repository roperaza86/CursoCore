using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace MyFirtsAppVS17
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

            private IConfigurationRoot Configuration { get; set; }
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json");
            Configuration = builder.Build();

            var title = Configuration["title"];//My App
            var stringOption = Configuration["options:stringOption"];///hello
               
            
           
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IAdder, BasicCalculator>();
            services.AddTransient<IOperationFormatter, OperationFormatter>();
            services.AddSingleton<IConfigurationRoot>(Configuration);
            services.AddOptions();
            services.Configure<MyAppSettings>(Configuration);

            
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory, IAdder adder)
        {

            app.Run(async ctx =>
            {
                var options = ctx.RequestServices.GetService<IOptions<MyAppSettings>>();
                MyAppSettings settings = options.Value;
                var title = settings.Title;
                var stringOption = settings.Options.StringOption;
                await ctx.Response.WriteAsync($"Title: {title}, Options>StringOption: {stringOption}");
            });

            //app.Run(async ctx=>
            //{
            //    var config = ctx.RequestServices.GetService<IConfigurationRoot>();
            //    var title = config["title"];
            //    await ctx.Response.WriteAsync($"title:{title}");
            //}
            //);

            //app.UseStaticFiles(new StaticFileOptions()
            //{
            //    OnPrepareResponse = ctx => 
            //    {
            //        ctx.Context.Response.Headers.Add("X-CopyRight", "Copyright (C) JMA");
            //    }
            // });

            //app.UseStatusCodePages();
            //app.UseWelcomePage("/ test");


            //app.UseWelcomePage("/test");
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hola Mundo");
            //});

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}


            //app.Run(async (context)=>
            //{
            //    if (context.Request.Path == "/boom")
            //    {
            //        throw new InvalidOperationException("Invalid Operation");
            //    }

            //    await context.Response.WriteAsync("Hello World");


            //    });



            //app.Run(async(context)=>
            //{
            //    if (context.Request.Path == "/add")
            //    {
            //        int a = 0, b = 0;
            //        int.TryParse(context.Request.Query["a"],out a);
            //        int.TryParse(context.Request.Query["b"], out b);

            //       // var adder = app.ApplicationServices.GetService<IAdder>();
            //        await context.Response.WriteAsync($"Result sum: {adder.Add(a,b)}");
            //    }

            //    else
            //    {
            //        await context.Response.WriteAsync($"Try again!!");
            //    }
            //}
            //);



            //// Hello world middleware
            //app.Use(async (ctx, next) =>
            //{
            //    if (ctx.Request.Path == "/hello-world")
            //    {
            //        // Procesa la petición y no permite la ejecución de middlewares posteriores
            //        await ctx.Response.WriteAsync("Hello, world!");
            //    }
            //    else
            //    {
            //        // Pasa el control al siguiente middleware
            //        await next();
            //    }
            //});


            //app.Use(async (ctx, next) =>
            //{
            //    if (ctx.Request.Path.ToString().StartsWith("/hello"))
            //    {
            //        // Procesa la petición y no permite la ejecución de otros middlewares
            //        await ctx.Response.WriteAsync("Hello, user!");
            //    }
            //    else
            //    {
            //        // Pasa la petición al siguiente middleware
            //        await next();
            //    }
            //});


            //// Request Info middleware
            //app.Run(async ctx =>
            //{
            //    await ctx.Response.WriteAsync($"Path requested: {ctx.Request.Path}");
            //});

            //loggerFactory.AddConsole();

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            //app.Run(async (context) =>
            //{
            //  var name = context.Request.Query["name"];
            //    if (string.IsNullOrWhiteSpace(name))
            //    {

            //        await context.Response.WriteAsync($"hello, unknow");
            //    }
            //    else {
            //        await context.Response.WriteAsync($"hello, {name}");
            //    }





        }
    }
}
