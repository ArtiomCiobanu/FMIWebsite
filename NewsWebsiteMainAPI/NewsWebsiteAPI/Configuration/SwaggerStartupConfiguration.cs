using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using NewsWebsiteAPI.Infrastructure.Models.Swagger;
using Swashbuckle.AspNetCore.SwaggerUI;
using HeaderNames = NewsWebsiteAPI.Consts.HeaderNames;
using Schemes = NewsWebsiteAPI.Consts.Schemes;
using SettingsSections = NewsWebsiteAPI.Consts.SettingsSections;

namespace NewsWebsiteAPI.Configuration
{
    public static class SwaggerStartupConfiguration
    {
        public static void AddConfiguredSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var securityScheme = new OpenApiSecurityScheme
                {
                    Description = "Json Web Token for authorization. Write: 'Bearer {your token}'",
                    Name = HeaderNames.Authorization,
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = Schemes.Bearer
                };
                options.AddSecurityDefinition(securityScheme.Scheme, securityScheme);

                var requirement = new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = securityScheme.Scheme
                            },
                            Scheme = Schemes.OAuth,
                            Name = securityScheme.Scheme,
                            In = securityScheme.In
                        },
                        new List<string>()
                    }
                };

                options.AddSecurityRequirement(requirement);
            });
        }

        public static void AddConfiguredSwaggerUI(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwaggerUI(options =>
            {
                var endpointConfiguration = configuration
                    .GetSection(SettingsSections.SwaggerConfiguration)
                    .GetSection(SettingsSections.SwaggerConfigurationEndpoints)
                    .Get<SwaggerEndpointConfiguration>();

                options.SetEndpoint(endpointConfiguration);
            });
        }

        public static void SetEndpoint(this SwaggerUIOptions options, SwaggerEndpointConfiguration configuration)
        {
            options.SwaggerEndpoint(configuration.Url, configuration.Name);
        }
    }
}