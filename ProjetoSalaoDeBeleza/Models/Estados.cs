using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; // Adicione esta linha!

namespace ProjetoSalaoDeBeleza.Models
{
    public class Estados
    {
        [Key]
        public int CodEstado { get; set; }
        public string Estado { get; set; }
        public string UF { get; set; }

        public int CodPais { get; set; }
        [ForeignKey("CodPais")]
        public Paises oPais { get; set; }
    }
}