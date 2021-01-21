using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HackathonTotvs.Domain.Models
{
    [Table("tb_usuario")]
    public class Usuario
    {
        public Usuario() {}

        [Column("id")]
        public int Id { get; set; }
        [Column("nome")]
        public string Nome { get; set; }
        [Column("sobrenome")]
        public string Sobrenome { get; set; }
        [Column("cargo_id")]
        public int CargoId { get; set; }
        [Column("dt_ultimo_cargo")]
        public DateTime DtUltimoCargo { get; set; }
        [Column("dt_admissao")]
        public DateTime DtAdmissao { get; set; }
        [Column("email")]
        public string Email { get; set; }
        [Column("senha")]
        public string Senha { get; set; }

        [ForeignKey("CargoId")]
        public virtual Cargo Cargo { get; set; }

        public virtual List<UsuarioHabilidade> MinhasHabilidades { get; set; }
    }
}
