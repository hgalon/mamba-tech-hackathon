using HackathonTotvs.Domain.Interfaces;
using HackathonTotvs.Domain.Models;
using HackathonTotvs.Service.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace HackathonTotvs.Service.Respository
{
    public class TrilhaRepository : GenericRepository<Trilha>, ITrilha
    {
        public TrilhaRepository(TotvsContext context, IDbConnection conexao) : base(context, conexao)
        {
        }

        public override Task<List<Trilha>> SelectAll()
        {
           return _context.Trilha.Include("Carreiras.Areas.Cargos").ToListAsync();
        }
    }
}
