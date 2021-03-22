using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using DataAccess;
using Business.Account;
//using Microsoft.EntityFrameworkCore;

namespace EMS
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
            //string connection = Configuration.GetConnectionString("DefaultConnection");
            //services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
            services.AddSingleton<ApplicationContext>();
            services.AddSingleton<IAccountManager, AccountManager>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options =>
                    {
                        options.RequireHttpsMetadata = false;
                        options.TokenValidationParameters = new TokenValidationParameters
                        {
                            // indicates whether the publisher will be validated when validating the token
                            ValidateIssuer = true,
                            // a string representing the publisher
                            ValidIssuer = AuthOptions.ISSUER,

                            // whether the consumer of the token will be validated
                            ValidateAudience = true,
                            // token consumer setting
                            ValidAudience = AuthOptions.AUDIENCE,
                            // whether the lifetime will be validated
                            ValidateLifetime = true,

                            // security key installation
                            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                            // security key validation
                            ValidateIssuerSigningKey = true,
                        };
                    });


            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "EMS", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EMS v1"));
            }

            app.UseHttpsRedirection();

            app.UseDefaultFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
