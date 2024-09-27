using Core;
using System.ComponentModel.DataAnnotations;

namespace AjudAkiWeb.Models
{
    public class ClienteViewModel
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Código do cliente é obrigatório")]
        [Key]
        public uint Id{ get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(50)]
        public string Nome { get; set; } = null!;

        [Display(Name = "CPF")]
        [StringLength(11)]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter apenas números e ter 11 dígitos.")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Cpf { get; set; } = null!;

        [StringLength(11)]
        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "O celular deve conter apenas números e ter entre 10 e 11 dígitos.")]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Celular { get; set; } = null!;

        [StringLength(11)]
        [RegularExpression(@"^\d{0,11}$", ErrorMessage = "O telefone deve conter apenas números e ter entre 0 e 11 dígitos.")]
        public string? Telefone { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime DataNascimento { get; set; }

        [StringLength(40)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Email { get; set; } = null!;

        [StringLength(8)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Cep { get; set; } = null!;

        [StringLength(50)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Bairro { get; set; } = null!;

        [StringLength(40)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string Rua { get; set; } = null!;

        [Display(Name = "Número da Residência")]
        [StringLength(10)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public string NumResidencia { get; set; } = null!;

        [Display(Name = "Ponto de Residência")]
        [StringLength(40)]
        public string? PontoReferencia { get; set; }

        public TipoPessoa TipoPessoa { get; set; } = default!;
    }
}