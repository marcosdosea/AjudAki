using Core;
using System.ComponentModel.DataAnnotations;

namespace AjudAkiWeb.Models
{
    public enum ContratacaoStatusEnum
    {
        Recusado,
        Aceito,
        Pendente,
        Finalizado
    }
    public class ContratacaoViewModel
    {
        [Display(Name = "Código da contratação")]
        [Required(ErrorMessage = "Código da contratação é obrigatório")]
        [Key]
        public uint Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(50, MinimumLength = 4, ErrorMessage = "O nome da contratação deve ter entre 5 e 45 caracteres")]
        public string Nome { get; set; } = null!;

        [Display(Name = "Data da Contratação")]
        [DataType(DataType.Date, ErrorMessage = "Data válida requerida")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "CEP é obrigatório")]
        [StringLength(8, ErrorMessage = "CEP deve ter até 8 caracteres")]
        [Display(Name = "CEP")]
        public string Cep { get; set; } = null!;

        [Required(ErrorMessage = "Bairro é obrigatório")]
        [StringLength(50, ErrorMessage = "O nome do bairro deve ter até 50 caracteres")]
        public string Bairro { get; set; } = null!;

        [Required(ErrorMessage = "Rua é obrigatória")]
        [StringLength(40, ErrorMessage = "O nome da rua deve ter até 40 caracteres")]
        public string Rua { get; set; } = null!;

        [Required(ErrorMessage = "Número da residência é obrigatório")]
        [Display(Name = "Número da Residência")]
        [StringLength(10)]
        public string NumResidencia { get; set; } = null!;

        [Display(Name = "Ponto de Referência")]
        [StringLength(40, ErrorMessage = "O ponto de referência deve ter até 40 caracteres")]
        public string? PontoReferencia { get; set; }

        [Required(ErrorMessage = "Status é obrigatório")]
        [Display(Name = "Status da Contratação")]
        public ContratacaoStatusEnum Status { get; set; }

        [Required(ErrorMessage = "Código do Serviço é obrigatório")]
        [Display(Name = "Código do serviço")]
        public uint IdServico { get; set; }

        [Required(ErrorMessage = "Código do Cliente é obrigatório")]
        [Display(Name = "Código do cliente")]
        public uint IdCliente { get; set; }

        // Método para fazer o mapeamento simples do enum para string
        public string GetStatusAsString()
        {
            if (Status.Equals(ContratacaoStatusEnum.Recusado))
                return "Recusado";
            else if (Status.Equals(ContratacaoStatusEnum.Aceito))
                return "Aceito";
            else if (Status.Equals(ContratacaoStatusEnum.Pendente))
                return "Pendente";
            else if (Status.Equals(ContratacaoStatusEnum.Finalizado))
                return "Finalizado";
            else
                return "Indefinido";
        }
    }

}
