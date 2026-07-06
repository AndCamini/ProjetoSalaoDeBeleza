using System.ComponentModel.DataAnnotations;

namespace ProjetoSalaoDeBeleza.Models
{
    public class MarcasVeiculos
    {
        [Key]
        public int CodMarca { get; set; }

        [Required(ErrorMessage = "Nome é obrigatório.")]
        [MaxLength(50)]
        public string MarcaVeiculo { get; set; } = string.Empty;

        public bool Ativo { get; set; } = true;
        public DateTime DataCadastro { get; set; } = DateTime.UtcNow;
        public DateTime? DataUltimaAlteracao { get; set; }
        public string? UsuarioUltimaAlteracao { get; set; }
    }
}