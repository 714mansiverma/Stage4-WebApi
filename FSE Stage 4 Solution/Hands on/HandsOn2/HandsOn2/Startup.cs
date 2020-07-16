using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;

namespace HandsOn2
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title="Swagger Demo",
                    Version="v1",
                    Description="TBD",
                    TermsOfServices="None",
                    Contact=new Contact() { Name = "Mansi", Email="mansi@123",UrlHelperExtensions="www.example.com"},
                    License = new License() { Name = "License Terms", Url = "www.example.com"}
                });

            });
            
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SwaggerDemo");
            });
            app.UseMvc();
        }
    }

    internal class License
    {
        public License()
        {
        }

        public string Name { get; set; }
        public string Url { get; set; }
    }

    internal class Contact
    {
        public Contact()
        {
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public string UrlHelperExtensions { get; set; }
    }

    internal class Info : OpenApiInfo
    {
        public  string Title { get; set; }
        public string Version { get; set; }
        public  string Description { get; set; }
        public string TermsOfServices { get; set; }
        public  Contact Contact { get; set; }
        public License License { get; set; }
    }
}
