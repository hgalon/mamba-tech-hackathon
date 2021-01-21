using HackathonTotvs.Domain.Interfaces;
using HackathonTotvs.Domain.Models;
using HackathonTotvs.Service.Data;
using System.Data;

namespace HackathonTotvs.Service.Respository
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuario
    {
        public UsuarioRepository(TotvsContext context, IDbConnection conexao) : base(context, conexao)
        {
        }
    }
}
