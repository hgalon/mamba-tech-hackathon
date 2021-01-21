using HackathonTotvs.Domain.Interfaces;
using HackathonTotvs.Domain.Models;
using HackathonTotvs.Service.Data;
using System.Data;

namespace HackathonTotvs.Service.Respository
{
    public class CursoRepository : GenericRepository<Curso>, ICurso
    {
        public CursoRepository(TotvsContext context, IDbConnection conexao) : base(context, conexao)
        {
        }
    }
}
