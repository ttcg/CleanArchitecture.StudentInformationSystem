using Microsoft.OpenApi.Models;

namespace StudentInformationSystem.WebApi.Configurations;

public static class SwaggerConfiguration
{
    public static IServiceCollection AddSwaggerGenWithSecurity(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            // Define the OAuth2.0 scheme
            c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Type = SecuritySchemeType.OAuth2,
                Name = "Authorization",
                Scheme = "bearer",
                BearerFormat = "JWT",

                Flows = new OpenApiOAuthFlows
                {
                    Password = new OpenApiOAuthFlow
                    {
                        TokenUrl = new Uri("/connect/token", UriKind.Relative),
                        Scopes = new Dictionary<string, string>
                    {
                        {"openid", "Open Id" },
                        {"StudentInformationSystem.WebApiAPI", "Api" }
                    },

                    }
                },
                In = ParameterLocation.Header

            });

            c.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference { Type = ReferenceType.SecurityScheme, Id = "Bearer" }
                    },
                    new string[] {}
                }
            });
        });

        return services;
    }
}
