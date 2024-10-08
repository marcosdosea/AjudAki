using System.ComponentModel.DataAnnotations;

namespace AjudAkiWeb.Models
{
    public class PagarAssinaturaViewModel
    {
        [Display(Name = "Código")]
        [Key]
        [Required(ErrorMessage = "Código é obrigatório")]
        public uint Id { get; set; }

        [Display(Name = "Data pagamento")]
        [Required(ErrorMessage = "Data pagamento é obrigatório")]
        public DateTime DataPagamento { get; set; }

        [Display(Name = "Plano")]
        [Required(ErrorMessage = "Plano é obrigatório")]
        public string NomePlano { get; set; } = null!;
    }
}
