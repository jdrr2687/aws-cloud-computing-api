using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Amazon.Integration.Configuration;
using Amazon.Integration.Interfaces;
using Amazon.Integration.Services;
using AWSCloudComputing.Helpers;
using AWSCloudComputing.Repository;
using AWSCloudComputing.Services;
using AWSCloudComputing.Services.Interfaces;
using AWSCloudComputing.Services.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Saber.BusinessServices.External.Amazon.S3;
using SaberApi.Servicios.Generales.Services;
using SaberApi.Servicios.Generales.Services.Interfaces;

namespace AWSCloudComputing
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


          

            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader();
                    });
            });

            services.AddControllers();

            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IEmailConfiguration, EmailConfiguration>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<ICustomerService, CustomerService>();
            services.AddTransient<ICustomerMapper, CustomerMapper>();

            services.AddTransient<IUploadFileService, UploadFileService>();
            services.AddTransient<IS3Configuration, S3Configuration>();
            services.AddTransient<IStorageService, StorageService>();
           


            services.AddSwagger();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
          

            app.UseHttpsRedirection();
            app.ConfigureCustomSwagger();
            app.UseRouting();
           
          //  app.UseAuthorization();
            app.UseCors();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

           
        }
    }
}
