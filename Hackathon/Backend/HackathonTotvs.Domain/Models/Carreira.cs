using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HackathonTotvs.Domain.Models
{
    [Table("tb_carreira")]
    public class Carreira
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("titulo")]
        public string Titulo { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("id_trilha")]
        public int IdTrilha { get; set; }
    }
}
