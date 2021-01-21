using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HackathonTotvs.Domain.Models
{
    [Table("tb_habilidade")]
    public class Habilidade
    {
        public Habilidade() { }

        public Habilidade(int id, int idTipoHabilidade, string titulo, string descricao)
        {
            Id = id;
            IdTipoHabilidade = idTipoHabilidade;
            Titulo = titulo;
            Descricao = descricao;
        }

        [Column("id")]
        public int Id { get; set; }

        [Column("id_tipo_habilidade")]
        public int IdTipoHabilidade { get; set; }

        [Column("titulo")]
        public string Titulo { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [ForeignKey("IdTipoHabilidade")]
        public virtual TipoHabilidade TipoHabilidade { get; set; }
    }
}
