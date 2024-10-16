using System.ComponentModel.DataAnnotations;

namespace AjudAkiWeb.Models
{
    public enum StatusSolicitacaoEnum
    {
        RECUSADO, ACEITO, PENDENTE, FINALIZADO
    }

    public class SolicitacaoServicoViewModel
    {
        [Display(Name = "Código da solicitação de serviço")]
        [Required(ErrorMessage = "Código da solicitação de serviço é obrigatório")]
        [Key]
        public uint Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(50)]
        public string Nome { get; set; } = null!;

        [Display(Name = "Data da Solicitação")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true)]
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime DataHoraSolicitacao { get; set; }

        [Display(Name = "Status:  RECUSADO, ACEITO, PENDENTE, FINALIZADO")]
        public StatusSolicitacaoEnum? Status { get; set; } = null;

        [Range(0.0, Double.MaxValue, ErrorMessage = "O valor deve ser positivo.")]
        public decimal? Valor { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(300)]
        public string? Descricao { get; set; }

        [Display(Name = "Código do cliente")]
        [Required(ErrorMessage = "Código do cliente é obrigatório")]
        [Key]
        public uint IdCliente { get; set; }

        [Display(Name = "Código do profisisonal")]
        [Required(ErrorMessage = "Código do profisisonal é obrigatório")]
        [Key]
        public uint IdProfissional { get; set; }

        [Display(Name = "Código do tipo de serviço")]
        [Required(ErrorMessage = "Código do tipo de serviço é obrigatório")]
        [Key]
        public uint IdTipoServico { get; set; }
    }
}
