using HackathonTotvs.Domain.Interfaces;
using HackathonTotvs.Domain.Models;
using HackathonTotvs.Service.Data;
using System.Data;

namespace HackathonTotvs.Service.Respository
{
    public class CursoHabilidadeRepository : GenericRepository<CursoHabilidade>, ICursoHabilidade
    {
        public CursoHabilidadeRepository(TotvsContext context, IDbConnection conexao) : base(context, conexao)
        { 
        }
    }
}
