using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace HackathonTotvs.Domain.Models
{
  [Table("tb_cargo_habilidade")]
  public class CargoHabilidade
  {
    public CargoHabilidade() { }

    public CargoHabilidade(int id, int idCargo, int idHabilidade, bool desejavel, string urlCurso, string descricaoCurso)
    {
      Id = id;
      IdCargo = idCargo;
      IdHabilidade = idHabilidade;
      Desejavel = desejavel;
      UrlCurso = urlCurso;
      DescricaoCurso = descricaoCurso;
    }

    [Column("id")]
    public int Id { get; set; }

    [Column("id_cargo")]
    public int IdCargo { get; set; }

    [Column("id_habilidade")]
    public int IdHabilidade { get; set; }

    [Column("desejavel")]
    public bool Desejavel { get; set; }

    [Column("url_curso")]
    public string UrlCurso { get; set; }

    [Column("descricao_curso")]
    public string DescricaoCurso { get; set; }
  }
}
