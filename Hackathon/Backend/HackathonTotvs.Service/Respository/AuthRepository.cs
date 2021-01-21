using HackathonTotvs.Domain.Interfaces;
using HackathonTotvs.Domain.Models;
using HackathonTotvs.Service.Data;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace Iris8.GeneralShopping.Respository
{
    public class AuthRepository : IAuth
    {
        protected TotvsContext context;
        protected IDbConnection conexao;

        public AuthRepository(TotvsContext context = null, IDbConnection conexao = null)
        {
            this.context = context;
            this.conexao = conexao;
        }

        public async Task<Usuario> ValidateUser(string email, string password)
        {
            try
            {
                return await context.Usuario.Where(c => c.Email == email && c.Senha == password).SingleOrDefaultAsync();
            }
            catch (System.Exception)
            {

                throw;
            }
        }
    }

}