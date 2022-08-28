#region Imports

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web.Http.Description;
using API.Helpers;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.Swagger;

#endregion

namespace API.Configurations
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddCORS(this IServiceCollection services)
        {
            services.AddCors(o => o.AddPolicy("EnableCorsForntendProject", builder =>
            {
                builder.WithOrigins("https://localhost:3000" , "http://localhost:3000")
                    .AllowAnyMethod()
                    .AllowAnyHeader().AllowCredentials();
            }));

            return services;
        }

        public static IServiceCollection AddSwagger(this IServiceCollection services, SwaggerOptions options)
        {
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc(options.Version, new OpenApiInfo
                {
                    Version = options.Version,
                    Title = options.APIName,
                    Description = options.Description
                });
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); //This line

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Authorization header using the Bearer scheme (Example: 'Bearer qwertyuiop')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });
            return services;
        }
    }

    /// <summary>
    ///     Used to set required field for parameters.
    /// </summary>
    /// <seealso cref="Swashbuckle.Swagger.IOperationFilter" />
    public class AddRequiredHeaderParameter : IOperationFilter
    {
        /// <summary>
        ///     Applies the specified operation.
        /// </summary>
        /// <param name="operation">The operation.</param>
        /// <param name="schemaRegistry">The schema registry.</param>
        /// <param name="apiDescription">The API description.</param>
        public void Apply(Operation operation, SchemaRegistry schemaRegistry, ApiDescription apiDescription)
        {
            if (operation.parameters == null)
                operation.parameters = new List<Parameter>();

            var it = operation.parameters.Where(x => x.name == "request").FirstOrDefault();
            operation.parameters.Remove(it);

            operation.parameters.Add(new Parameter
            {
                name = "Authorization",
                @in = "header",
                type = "string",
                //@default = "Basic dGVzdEBtYWlsLmNvbToxMjM=",
                description = "Basic Auth key",
                required = true
            });
        }
    }
}