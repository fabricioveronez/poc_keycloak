using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using POC.Api.Service;

namespace POC.Api
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
            services.AddScoped(service =>
            {
                return new MongoClient("mongodb://mongouser:GPX4WOwpcvOc9Wm70gAG8It7tKA0Cy090ZVO82cEJsExogsMDY@localhost:27017/admin").GetDatabase("admin");
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(o =>
            {
                o.Authority = "http://localhost:8080/auth/realms/ecardapio";
                o.Audience = "account";
                o.SaveToken = true;                
                o.RequireHttpsMetadata = false;
                o.IncludeErrorDetails = true;
                o.MetadataAddress = "http://localhost:8080/auth/realms/ecardapio/.well-known/openid-configuration";
            });

            services.AddControllers().AddNewtonsoftJson();
            services.AddTransient<ProdutoService>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder =>
            {
                builder.WithOrigins("http://localhost:4200")
                    .AllowAnyHeader()
                    .WithMethods("*")
                    .AllowCredentials();
            });

            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
