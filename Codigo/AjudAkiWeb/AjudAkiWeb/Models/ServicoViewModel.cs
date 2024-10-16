using System.ComponentModel.DataAnnotations;

namespace AjudAkiWeb.Models
{
    public enum ServicoStatusEnum
    {
        Recusado,
        Aceito,
        Pendente,
        Finalizado
    }
    public class ServicoViewModel
    {

        [Display(Name ="Código do Serviço")]
        [Required(ErrorMessage = "Código do serviço é obrigatório")]
        [Key]
        public uint Id { get; set; }

        [Display(Name = "Nome")]
        [StringLength(50)]
        public string? Nome { get; set; }

        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime DataHoraSolicitacao { get; set; }

        [Required(ErrorMessage = "Status é obrigatório")]
        [Display(Name = "Status da oferta do serviço")]
        public ServicoStatusEnum Status { get; set; }

        [Display(Name = "Valor da oferta do serviço")]
        public decimal? Valor { get; set; }

        [Display(Name = "Descrição da oferta do serviço")]
        public string? Descricao { get; set; }

        [Display(Name = "Código do cliente")]
        [Required(ErrorMessage = "Código do cliente é obrigatório")]
        [Key]
        public uint IdCliente { get; set; }

        [Display(Name = "Código do profissional")]
        [Required(ErrorMessage = "Código do profissional é obrigatório")]
        [Key]
        public uint IdProfissional { get; set; }

        [Display(Name = "Código do serviço")]
        [Required(ErrorMessage = "Código do serviço é obrigatório")]
        [Key]
        public uint IdTipoServico { get; set; }

        // Método para fazer o mapeamento simples do enum para string
        public string GetStatusAsString()
        {
            if (Status.Equals(ServicoStatusEnum.Recusado))
                return "Recusado";
            else if (Status.Equals(ServicoStatusEnum.Aceito))
                return "Aceito";
            else if (Status.Equals(ServicoStatusEnum.Pendente))
                return "Pendente";
            else if (Status.Equals(ServicoStatusEnum.Finalizado))
                return "Finalizado";
            else
                return "Indefinido";
        }
    }
}
