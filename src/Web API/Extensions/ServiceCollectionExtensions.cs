using Microsoft.OpenApi.Models;

namespace Web_API.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo()
                {
                    Description = "#Merchandise API",
                    Title = "Merchandise API",
                    Version = "v1",
                    Contact = new OpenApiContact()
                    {
                        Name = "Dev Mappouras",
                        Url = new Uri("https://github.com/devmappouras")
                    }
                });
            });

            return services;
        }
    }
}
