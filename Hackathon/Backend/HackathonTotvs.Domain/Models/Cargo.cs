﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HackathonTotvs.Domain.Models
{
  [Table("tb_cargo")]
  public class Cargo
  {
    public Cargo() { }

    [Column("id")]
    public int Id { get; set; }

    [Column("titulo")]
    public string Titulo { get; set; }

    [Column("descricao")]
    public string Descricao { get; set; }

    [Column("meses_experiencia")]
    public int MesesExperiencia { get; set; }

    [Column("id_area")]
    public int IdArea { get; set; }

    [Column("id_nivel")]
    public int? IdNivel { get; set; }

    [ForeignKey("IdArea")]
    public virtual Area Area { get; set; }
  }
}
