using Microsoft.EntityFrameworkCore;
using ProjetoSalaoDeBeleza.Components.Account.Pages.Manage;
using System.ComponentModel.DataAnnotations;

namespace ProjetoSalaoDeBeleza.Models
{
    public class Paises
    {
        [Key]
        [MaxLength(5)]
        public int CodPais { get; set; }
        [MaxLength(25)]
        public string Pais { get; set; }
        [MaxLength(3)]
        public string Sigla { get; set; }
        [MaxLength(5)]
        public string DDI { get; set; }
        [MaxLength(25)]
        public string Moeda { get; set; }
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
        public DateTime? DataUltimaAlteracao { get; set; }
        public string? UsuarioUltimaAlteracao { get; set; }
    }
}
