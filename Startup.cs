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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
// using Newtonsoft.Json.Serialization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace uaaloo
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
            //Activo CORS
            services.AddCors(c =>{
                c.AddPolicy("AllowOrigin", options=>options.AllowAnyOrigin().AllowAnyHeader());
            });

            //JSON Serializer
            // services.AddControllersWithViews()
            //     .AddNewtonsoftJson(options =>
            //     options.SerializerSetings.ReferenceLoopHandling = Newtonsoft
            //     .Json.ReferenceLoopHandling.Ignore )
            //     .AddNewtonsoftJson(OptionsServiceCollectionExtensions => OptionsSeializerSettings.ContractResolver
            //     = new DefaultContractResolver());
             services.AddControllers()
            .AddJsonOptions(options =>
            {
            options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
            options.JsonSerializerOptions.PropertyNamingPolicy = null;
            options.JsonSerializerOptions.Converters.Add (new JsonStringEnumConverter ());
            });  


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "uaaloo", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "uaaloo v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
