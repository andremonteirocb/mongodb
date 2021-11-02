using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Fundamentos.NoSQL.Middlewares
{
    public static class SwaggerMiddlerware
    {
        public static void AddSwaggerService(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "MongoDb CosmosDb Api", Version = "v1" });
            });
        }

        public static void UseSwaggerApp(this IApplicationBuilder app, string routePrefix)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MongoDb CosmosDb Api");
                c.RoutePrefix = routePrefix;
            });
        }
    }
}