using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AjudAkiWeb.Models
{
    public enum StatusSolicitacaoEnum
    {
        RECUSADO, ACEITO, PENDENTE, FINALIZADO
    }

    public class SolicitacaoServicoViewModel
    {
        [Display(Name = "Código")]
        [Key]
        public uint Id { get; set; }

        [Display(Name = "Título/Nome")]
        [Required(ErrorMessage = "O nome é obrigatório")]
        [StringLength(50)]
        public string Nome { get; set; } = null!;

        [Display(Name = "Data da Solicitação")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "A data é obrigatória")]
        public DateTime DataHoraSolicitacao { get; set; } = DateTime.Now;

        [Display(Name = "Status")]
        public StatusSolicitacaoEnum? Status { get; set; } = StatusSolicitacaoEnum.PENDENTE;

        [Display(Name = "Valor (R$)")]
        [Range(0.0, Double.MaxValue, ErrorMessage = "O valor deve ser positivo.")]
        public decimal? Valor { get; set; }

        [Display(Name = "Descrição Detalhada")]
        [Required(ErrorMessage = "A descrição é obrigatória")]
        [StringLength(300)]
        public string? Descricao { get; set; }

        [Display(Name = "Cliente")]
        [Required(ErrorMessage = "O cliente é obrigatório")]
        public uint IdCliente { get; set; }

        [Display(Name = "Profissional")]
        [Required(ErrorMessage = "O profissional é obrigatório")]
        public uint IdProfissional { get; set; }

        [Display(Name = "Tipo de Serviço")]
        [Required(ErrorMessage = "O tipo de serviço é obrigatório")]
        public uint IdTipoServico { get; set; }

        public SelectList? ListaClientes { get; set; }
        public SelectList? ListaProfissionais { get; set; }
        public SelectList? ListaTiposServico { get; set; }
    }
}
