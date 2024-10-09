using System.ComponentModel.DataAnnotations;

namespace AjudAkiWeb.Models
{
    public enum PagamentoStatusEnum
    {
        ATIVO, 
        ATRASADO, 
        PAGO, 
        CANCELADO
    }

    public class PagarAssinaturaViewModel
    {
        [Display(Name = "Código do pagamento da assinatura")]
        [Key]
        [Required(ErrorMessage = "Código é obrigatório")]
        public uint Id { get; set; }

        [Display(Name = "Data de pagamento")]
        [Required(ErrorMessage = "Data pagamento é obrigatório")]
        public DateTime DataPagamento { get; set; }

        [Required(ErrorMessage = "Status é obrigatório")]
        public PagamentoStatusEnum? Status { get; set; }

        [Display(Name = "Plano de assinatura")]
        [Required(ErrorMessage = "Plano é obrigatório")]
        public string NomePlano { get; set; } = null!;
        public uint IdProfissional { get; set; }
        public ProfissionalViewModel? ProfissionalViewModel { get; set; }
        public uint IdAssinatura { get; set; }
        public AssinaturaViewModel? AssinaturaViewModel { get; set; }
    }
}
