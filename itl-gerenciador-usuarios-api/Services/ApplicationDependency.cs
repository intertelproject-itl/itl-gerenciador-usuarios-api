using itl_gerenciador_usuarios_api.Domain.Interface.Services.v1;
using itl_gerenciador_usuarios_api.Services.v1;
using Microsoft.Extensions.DependencyInjection;
using itl_gerenciador_usuarios_api.Infraestructure.NoSql;
using MongoDB.Driver;
using Microsoft.Extensions.Configuration;

namespace itl_gerenciador_usuarios_api.Services
{
    public static class ApplicationDependency
    {
        public static void AddApplictionModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<ILoginService, LoginService>();
            services.AddScoped<ISessaoJogatinaService, SessaoJogatinaService>();
            services.AddScoped<IPersonagemService, PersonagemService>();
            services.AddScoped<IInventarioService, InventarioService>();

            // Discord integration
            // configured in Program.cs

            // MongoDB
            var mongoSection = configuration.GetSection("ConnectionString");
            services.Configure<MongoDbSettings>(mongoSection);
            var mongoConn = mongoSection["MongoDB"] ?? "mongodb://localhost:27017/";
            services.AddSingleton<IMongoClient>(sp => new MongoClient(mongoConn));
            services.AddScoped(typeof(IMongoInventarioRepository<>), typeof(MongoInventarioRepository<>));
        }
    }
}
