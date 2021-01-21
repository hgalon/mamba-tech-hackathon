using HackathonTotvs.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace HackathonTotvs.Service.Data
{
    public class TotvsContext : DbContext
    {
        public TotvsContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Cargo> Cargo { get; set; }
        public DbSet<Curso> Curso { get; set; }
        public DbSet<CursoHabilidade> CursoHabilidade { get; set; }
        public DbSet<Habilidade> Habilidade { get; set; }
        public DbSet<TipoHabilidade> TipoHabilidade { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<UsuarioHabilidade> UsuarioHabilidade { get; set; }
        public DbSet<Trilha> Trilha { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
