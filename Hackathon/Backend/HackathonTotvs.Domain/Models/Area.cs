using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HackathonTotvs.Domain.Models
{
    [Table("tb_area")]
    public class Area
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("titulo")]
        public string Titulo { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("id_carreira")]
        public int IdCarreira { get; set; }
    }
}
