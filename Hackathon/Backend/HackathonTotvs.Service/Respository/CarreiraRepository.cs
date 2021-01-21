using HackathonTotvs.Domain.Interfaces;
using HackathonTotvs.Domain.Models;
using HackathonTotvs.Service.Data;
using System.Data;

namespace HackathonTotvs.Service.Respository
{
    public class CarreiraRepository : GenericRepository<Carreira>, ICarreira
    {
        public CarreiraRepository(TotvsContext context, IDbConnection conexao) : base(context, conexao)
        {
        }
    }
}
