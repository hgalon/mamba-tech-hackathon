using HackathonTotvs.Domain.Interfaces;
using HackathonTotvs.Domain.Models;
using HackathonTotvs.Service.Data;
using System.Data;

namespace HackathonTotvs.Service.Respository
{
    public class CargoHabilidadeRepository : GenericRepository<CargoHabilidade>, ICargoHabilidade
  {
        public CargoHabilidadeRepository(TotvsContext context, IDbConnection conexao) : base(context, conexao)
        {
        }
    }
}
