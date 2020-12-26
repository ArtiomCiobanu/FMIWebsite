using System;
using FMIWebsiteAPI.Configuration;
using FMIWebsiteAPI.Models.Swagger;
using FMIWebsiteAuthorizationAPI.API;
using FMIWebsiteAuthorizationAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace FMIWebsiteAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        private IServiceProvider ServiceProvider { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IJwtConfigurator, JwtConfigurator>(s =>
            {
                var jwtConfiguration = Configuration.GetSection("JwtConfiguration").Get<JwtConfiguration>();

                return new JwtConfigurator(jwtConfiguration);
            });
            services.AddSingleton<IJwtManager, JwtManager>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var jwtConfigurator = ServiceProvider.GetService<IJwtConfigurator>();

                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = jwtConfigurator.ValidationParameters;
            });
            services.AddControllers();

            services.AddConfiguredSwagger();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ServiceProvider = app.ApplicationServices;

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                var endpointConfiguration = Configuration.GetSection("SwaggerConfiguration").GetSection("Endpoints")
                    .Get<SwaggerEndpointConfiguration>();

                options.SetEndpoint(endpointConfiguration);
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}