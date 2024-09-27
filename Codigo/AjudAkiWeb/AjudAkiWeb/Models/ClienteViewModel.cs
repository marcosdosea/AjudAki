using Core;
using System.ComponentModel.DataAnnotations;

namespace AjudAkiWeb.Models
{
    public class ClienteViewModel
    {
        [Display(Name = "C�digo")]
        [Required(ErrorMessage = "C�digo do cliente � obrigat�rio")]
        [Key]
        public uint Id{ get; set; }

        [Required(ErrorMessage = "Campo obrigat�rio")]
        [StringLength(50)]
        public string Nome { get; set; } = null!;

        [Display(Name = "CPF")]
        [StringLength(11)]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter apenas n�meros e ter 11 d�gitos.")]
        [Required(ErrorMessage = "Campo Obrigat�rio")]
        public string Cpf { get; set; } = null!;

        [StringLength(11)]
        [RegularExpression(@"^\d{10,11}$", ErrorMessage = "O celular deve conter apenas n�meros e ter entre 10 e 11 d�gitos.")]
        [Required(ErrorMessage = "Campo Obrigat�rio")]
        public string Celular { get; set; } = null!;

        [StringLength(11)]
        [RegularExpression(@"^\d{0,11}$", ErrorMessage = "O telefone deve conter apenas n�meros e ter entre 0 e 11 d�gitos.")]
        public string? Telefone { get; set; }

        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Campo Obrigat�rio")]
        public DateTime DataNascimento { get; set; }

        [StringLength(40)]
        [Required(ErrorMessage = "Campo Obrigat�rio")]
        public string Email { get; set; } = null!;

        [StringLength(8)]
        [Required(ErrorMessage = "Campo Obrigat�rio")]
        public string Cep { get; set; } = null!;

        [StringLength(50)]
        [Required(ErrorMessage = "Campo Obrigat�rio")]
        public string Bairro { get; set; } = null!;

        [StringLength(40)]
        [Required(ErrorMessage = "Campo Obrigat�rio")]
        public string Rua { get; set; } = null!;

        [Display(Name = "N�mero da Resid�ncia")]
        [StringLength(10)]
        [Required(ErrorMessage = "Campo Obrigat�rio")]
        public string NumResidencia { get; set; } = null!;

        [Display(Name = "Ponto de Resid�ncia")]
        [StringLength(40)]
        public string? PontoReferencia { get; set; }

        public TipoPessoa TipoPessoa { get; set; } = default!;
    }
}