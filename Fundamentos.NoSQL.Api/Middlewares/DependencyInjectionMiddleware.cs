using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Fundamentos.NoSQL.Domain.Settings;
using Fundamentos.NoSQL.Services;
using Fundamentos.NoSQL.Data;
using Fundamentos.NoSQL.Domain.Interfaces;
using Microsoft.Extensions.Options;

namespace Fundamentos.NoSQL.Middlewares
{
    public static class DependencyInjectionMiddleware
    {
        public static void AddDependencyInjection(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MongoDBConfig>(
                configuration.GetSection(nameof(MongoDBConfig)));

            services.AddSingleton<IMongoDBConfig>(sp =>
                sp.GetRequiredService<IOptions<MongoDBConfig>>().Value);

            services.AddScoped<IProdutoRepository, ProductRepository>();
            services.AddScoped<IProdutoServices, ProdutoServices>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserServices, UserServices>();

            services.AddScoped<ITarefaRepository, TarefaRepository>();
            services.AddScoped<ITarefaServices, TarefaServices>();

            services.AddScoped<IPublicacaoRepository, PublicacaoRepository>();
            services.AddScoped<IPublicacaoServices, PublicacaoServices>();
        }
    }
}