using HackathonTotvs.Domain.Interfaces;
using HackathonTotvs.Domain.Models;
using HackathonTotvs.Service.Data;
using System.Data;

namespace HackathonTotvs.Service.Respository
{
    public class TipoHabilidadeRepository : GenericRepository<TipoHabilidade>, ITipoHabilidade
    {
        public TipoHabilidadeRepository(TotvsContext context, IDbConnection conexao) : base(context, conexao)
        {
        }
    }
}
