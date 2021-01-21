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
    public DbSet<Habilidade> Habilidade { get; set; }
    public DbSet<TipoHabilidade> TipoHabilidade { get; set; }
    public DbSet<Usuario> Usuario { get; set; }
    public DbSet<UsuarioHabilidade> UsuarioHabilidade { get; set; }
    public DbSet<CargoHabilidade> CargoHabilidade { get; set; }
    public DbSet<Trilha> Trilha { get; set; }
    public DbSet<Carreira> Carreira { get; set; }
    public DbSet<Area> Area { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
    }
  }
}
