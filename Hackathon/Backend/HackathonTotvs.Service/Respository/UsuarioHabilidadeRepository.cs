using HackathonTotvs.Domain.Interfaces;
using HackathonTotvs.Domain.Models;
using HackathonTotvs.Service.Data;
using System.Data;

namespace HackathonTotvs.Service.Respository
{
    public class UsuarioHabilidadeRepository : GenericRepository<UsuarioHabilidade>, IUsuarioHabilidade
    {
        public UsuarioHabilidadeRepository(TotvsContext context, IDbConnection conexao) : base(context, conexao)
        {
        }
    }
}
