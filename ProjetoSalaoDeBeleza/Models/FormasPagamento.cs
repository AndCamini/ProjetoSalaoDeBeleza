using System.ComponentModel.DataAnnotations;

namespace ProjetoSalaoDeBeleza.Models
{
    public class FormasPagamento
    {
        [Key]
        public int CodFormaPagamento { get; set; }

        [Required(ErrorMessage = "Descrição é obrigatória.")]
        [MaxLength(50, ErrorMessage = "Descrição pode ter no máximo 50 caracteres.")]
        public string FormaPagamento { get; set; } = string.Empty;

        public bool Ativo { get; set; } = true;
    }
}