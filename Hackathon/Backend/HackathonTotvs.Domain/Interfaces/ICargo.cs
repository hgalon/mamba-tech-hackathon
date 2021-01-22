using HackathonTotvs.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HackathonTotvs.Domain.Interfaces
{
    public interface ICargo : IRepository<Cargo>
    {
        Task<IEnumerable<dynamic>> GetForId(int id);
        Task<dynamic> GetDetailForId(int id);
    }
}
