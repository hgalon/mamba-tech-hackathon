using System.Collections.Generic;
using System.Threading.Tasks;

namespace HackathonTotvs.Domain.Interfaces
{
    public interface IRepository<T> 
    {
        Task<T> Insert(T obj);

        Task Update (T obj);

        Task Delete (int id);

        Task<T> Select(int id);

        Task<List<T>> SelectAll();

    }
}
