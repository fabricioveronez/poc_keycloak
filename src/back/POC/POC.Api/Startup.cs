using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
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

        public string GetConfiguration(string key)
        {
            string value = Environment.GetEnvironmentVariable(key.Replace(":", "_").ToUpper());
            if (string.IsNullOrEmpty(value))
            {
                value = this.Configuration[key];
            }
            return value;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped(service =>
            {
                return new MongoClient(this.GetConfiguration("MongoDB:ConnectionString")).GetDatabase(this.GetConfiguration("MongoDB:DataBase"));
            });

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer(jwtOptions =>
            {
                jwtOptions.Authority = this.GetConfiguration("Identity:Authority");
                jwtOptions.Audience = this.GetConfiguration("Identity:Audience");
                jwtOptions.SaveToken = true;
                jwtOptions.RequireHttpsMetadata = false;
                jwtOptions.IncludeErrorDetails = true;
                jwtOptions.MetadataAddress = this.GetConfiguration("Identity:MetadataAddress");

                jwtOptions.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = false,
                    ValidateIssuer = true,
                    ValidIssuer = this.GetConfiguration("Identity:Authority"),
                    ValidateLifetime = true,
                    SaveSigninToken = false
                };

                jwtOptions.Events = new JwtBearerEvents()
                {
                    OnAuthenticationFailed = context =>
                    {
                        context.NoResult();
                        context.Response.StatusCode = 500;
                        context.Response.ContentType = "text/plain";
                        return context.Response.WriteAsync(context.Exception.ToString());
                    },
                };
            });

            //services.AddAuthorization(authorizationOptions =>
            //{
            //    authorizationOptions.AddPolicy("editar_produto", new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
            //        .RequireAuthenticatedUser()
            //        .Build());
            //});

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
            app.UseAuthentication();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
