using HackathonTotvs.Domain.Interfaces;
using HackathonTotvs.Service.Data;
using HackathonTotvs.Service.Respository;
using Iris8.GeneralShopping.Respository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;

namespace HackathonTotvs.Service.Injections

{
    public static class DependencyInjection
    {
        public static IServiceCollection Resolve(this IServiceCollection services, IConfiguration configuration)
        {


            services.AddTransient<IDbConnection>(db => new SqlConnection(
                   configuration.GetConnectionString("TotvsDb")));

            services.AddDbContext<TotvsContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("TotvsDb")));

            services.AddScoped<ICargo, CargoRepository>();
            services.AddScoped<ICursoHabilidade, CursoHabilidadeRepository>();
            services.AddScoped<ICurso, CursoRepository>();
            services.AddScoped<IHabilidade, HabilidadeRepository>();
            services.AddScoped<ITipoHabilidade, TipoHabilidadeRepository>();
            services.AddScoped<IUsuarioHabilidade, UsuarioHabilidadeRepository>();
            services.AddScoped<IUsuario, UsuarioRepository>();
            services.AddScoped<ITrilha, TrilhaRepository>();
            services.AddScoped<IAuth, AuthRepository>();
            //services.AddScoped<IRecoveryPassword, RecoveryPasswordRepository>();
            //services.AddScoped<IEmailSender,AuthMessageSender>();
            return services;

        }

    }
}
