using HackathonTotvs.Domain.Models;
using System.Threading.Tasks;

namespace HackathonTotvs.Domain.Interfaces
{
    public interface IAuth
    {
        public Task<Usuario> ValidateUser(string Email, string Password);
    }
}
