using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HackathonTotvs.Domain.Models
{
    [Table("tb_trilha")]
    public class Trilha
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("titulo")]
        public string Titulo { get; set; }
        [Column("descricao")]
        public string Descricao { get; set; }
    }
}
