using HackathonTotvs.Domain.Interfaces;
using HackathonTotvs.Domain.Models;
using HackathonTotvs.Service.Data;
using System.Data;

namespace HackathonTotvs.Service.Respository
{
    public class AreaRepository : GenericRepository<Area>, IArea
    {
        public AreaRepository(TotvsContext context, IDbConnection conexao) : base(context, conexao)
        {
        }
    }
}
