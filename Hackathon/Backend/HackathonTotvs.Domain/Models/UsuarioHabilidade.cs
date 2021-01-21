using System.ComponentModel.DataAnnotations.Schema;

namespace HackathonTotvs.Domain.Models
{
  [Table("tb_usuario_habilidade")]
  public class UsuarioHabilidade
  {
    [Column("id")]
    public int Id { get; set; }

    [Column("id_habilidade")]
    public int IdHabilidade { get; set; }

    [Column("id_usuario")]
    public int IdUsuario { get; set; }

    [Column("url_certificado")]
    public string UrlCertificado { get; set; }

    [Column("nivel")]
    public int Nivel { get; set; }

    [ForeignKey("IdHabilidade")]
    public Habilidade Habilidade { get; set; }

    [ForeignKey("IdUsuario")]
    public Usuario Usuario { get; set; }
  }
}
