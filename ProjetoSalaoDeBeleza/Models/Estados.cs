using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSalaoDeBeleza.Models
{
    public class Estados
    {
        [Key]
        [MaxLength(5)]
        public int CodEstado { get; set; }
        [MaxLength(25)]
        public string Estado { get; set; }
        [MaxLength(3)]
        public string UF { get; set; }

        public int CodPais { get; set; }
        [ForeignKey("CodPais")]
        public Paises oPais { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
        public DateTime? DataUltimaAlteracao { get; set; }
        public string? UsuarioUltimaAlteracao { get; set; }
    }
}