using HackathonTotvs.Domain.Interfaces;
using HackathonTotvs.Domain.Models;
using HackathonTotvs.Service.Data;
using System.Data;

namespace HackathonTotvs.Service.Respository
{
    public class TrilhaRepository : GenericRepository<Trilha>, ITrilha
    {
        public TrilhaRepository(TotvsContext context, IDbConnection conexao) : base(context, conexao)
        {
        }
    }
}
