using System;
using System.Reflection;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NewsWebsiteAPI.Configuration;
using NewsWebsiteAPI.DataAccess.Commands;
using NewsWebsiteAPI.Extensions;
using NewsWebsiteAPI.Infrastructure.Configurators;

namespace NewsWebsiteAPI
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
            services.AddAndConfigureDbContexts(Configuration);
            services.AddGenerators(Configuration);
            services.AddJwt();
            services.AddRepositories();
            services.AddServices();
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var jwtConfigurator = ServiceProvider.GetService<IJwtConfigurator>();

                options.RequireHttpsMetadata = true;
                options.TokenValidationParameters = jwtConfigurator?.ValidationParameters;
            });

            services.AddAuthorization(
                options => { options.AddRequireAdministratorRolePolicy(); });

            services
                .AddControllers()
                .AddFluentValidation(c =>
                    c.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));

            services.AddConfiguredSwagger();

            services.AddMediatR(GetType(), typeof(AddPost));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            ServiceProvider = app.ApplicationServices;

            app.UseSwagger();
            app.AddConfiguredSwaggerUI(Configuration);

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