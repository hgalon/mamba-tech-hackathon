using System.ComponentModel.DataAnnotations.Schema;

namespace HackathonTotvs.Domain.Models
{
    [Table("tb_curso_habilidade")]
    public class CursoHabilidade
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("id_habilidade")]
        public int IdHabilidade { get; set; }
        [Column("id_curso")]
        public int IdCurso { get; set; }


        [ForeignKey("IdHabilidade")]
        public Habilidade Habilidade { get; set; }

        [ForeignKey("IdCurso")]
        public Curso Curso { get; set; }
    }
}
