using HackathonTotvs.Domain.Interfaces;
using HackathonTotvs.Domain.Models;
using HackathonTotvs.Service.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HackathonTotvs.Service.Respository
{
    public class HabilidadeRepository : GenericRepository<Habilidade>, IHabilidade
    {
        public HabilidadeRepository(TotvsContext context, IDbConnection conexao) : base(context, conexao)
        {
        }

        public override async Task<List<Habilidade>> SelectAll()
        {
            var result  = await _context.Habilidade.Include("Cursos.Curso").ToListAsync();
            return result;
        }
    }
}
