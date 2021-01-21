using System.ComponentModel.DataAnnotations.Schema;

namespace HackathonTotvs.Domain.Models
{
    [Table("tb_tipo_habilidade")]
    public class TipoHabilidade
    {
        public TipoHabilidade() { }

        public TipoHabilidade(int id, string titulo)
        {
            Id = id;
            Titulo = titulo;
        }

        [Column("id")]
        public int Id { get; set; }
        [Column("titulo")]
        public string Titulo { get; set; }
    }
}
