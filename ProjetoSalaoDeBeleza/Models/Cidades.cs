using ProjetoSalaoDeBeleza.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoSalaoDeBeleza.Models
{
    public class Cidades
    {
        [Key]
        public int CodCidade { get; set; }
        public string Cidade { get; set; }

        public int CodEstado { get; set; }
        [ForeignKey("CodEstado")]
        public Estados oEstado { get; set; }
    }
}
