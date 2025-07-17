using Microsoft.AspNetCore.Mvc.Rendering;
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
        [Display(Name = "Código")]
        [Key]
        [Required(ErrorMessage = "Código é obrigatório")]
        public uint Id { get; set; }

        [Display(Name = "Data pagamento")]
        [Required(ErrorMessage = "Data pagamento é obrigatório")]
        public DateTime DataPagamento { get; set; }

        [Required(ErrorMessage = "Status é obrigatório")]
        public PagamentoStatusEnum? Status { get; set; }

        [Required(ErrorMessage = "Código do Profissional é obrigatório")]
        [Display(Name = "Selecione o profissional")]
        public uint IdProfissional { get; set; }
        public ProfissionalViewModel? ProfissionalViewModel { get; set; }

        [Required(ErrorMessage = "Código do Plano é obrigatório")]
        [Display(Name = "Selecione o plano")]
        public uint IdAssinatura { get; set; }
        public AssinaturaViewModel? AssinaturaViewModel { get; set; }
        public SelectList? ListaAssinaturas { get; set; }
        public SelectList? ListaProfissionais { get; set; }
        public SelectList? StatusList { get; set; }
    }
}
