using System.Collections.Generic;
using FMIWebsiteAPI.Models.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerUI;

namespace FMIWebsiteAPI.StartupConfigurationTools
{
    public static class SwaggerConfigurationTools
    {
        public static void AddConfiguredSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                var securityScheme = new OpenApiSecurityScheme()
                {
                    Description = "Json Web Token for authorization. Write: 'Bearer {your token}'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                };
                options.AddSecurityDefinition("Bearer", securityScheme);

                var requirement = new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme()
                        {
                            Reference = new OpenApiReference() {Type = ReferenceType.SecurityScheme, Id = "Bearer"},
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                };

                options.AddSecurityRequirement(requirement);
            });
        }

        public static void SetEndpoint(this SwaggerUIOptions options, SwaggerEndpointConfiguration configuration)
        {
            options.SwaggerEndpoint(configuration.Url, configuration.Name);
        }
    }
}