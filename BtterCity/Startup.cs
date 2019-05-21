using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BtterCity.Models;
using BtterCity.Repository;
using BtterCity.Interfaces;
using Swashbuckle.AspNetCore.Swagger;

namespace BtterCity
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
            services.AddCors();

            var conn = Configuration["Data:DefaultConnection:ConnectionString"];

            services.AddDbContext<DatabaseContext>(options =>
                options.UseMySql(conn));
            services.AddScoped<IIssueRepository, IssueRepository>();
            services.AddScoped<IIssueTypeRepository, IssueTypeRepository>();

            // Registering Swagger Generator
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = "Better City Swagger",
                    Version = "v1",
                    Description = "Better City is an application that consists on helping citizens to reporting issues in their city all over the world.",
                    TermsOfService = "None"
                    //Contact = new Contact() { Name = "John Doe", Email = "john@xyzmail.com", Url = "www.example.com" },
                    //License = new License() { Name = "License Terms", Url = "www.example.com" }
                });
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // Serves generated swagger document as JSON endpoint. 
            app.UseSwagger();

            // Serves the Swagger UI
            app.UseSwaggerUI(c =>
            {
                // specifying the Swagger JSON endpoint.
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Better City Swagger");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
