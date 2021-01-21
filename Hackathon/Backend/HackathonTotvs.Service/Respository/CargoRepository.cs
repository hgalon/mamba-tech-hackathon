using HackathonTotvs.Domain.Interfaces;
using HackathonTotvs.Domain.Models;
using HackathonTotvs.Service.Data;
using System.Data;

namespace HackathonTotvs.Service.Respository
{
    public class CargoRepository : GenericRepository<Cargo>, ICargo
    {
        public CargoRepository(TotvsContext context, IDbConnection conexao) : base(context, conexao)
        {
        }
    }
}
