using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace HackathonTotvs.Domain.Models
{
    [Table("tb_curso")]
    public class Curso
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("titulo")]
        public string Titulo { get; set; }
        [Column("url")]
        public string Url { get; set; }
    }
}
