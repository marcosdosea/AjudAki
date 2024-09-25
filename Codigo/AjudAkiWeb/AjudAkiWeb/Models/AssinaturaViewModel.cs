using System.ComponentModel.DataAnnotations;

namespace AjudAkiWeb.Models
{

    public enum StatusEnum
    {
        ATIVA,
        INATIVA
    }
    public class AssinaturaViewModel
    {
        [Display(Name ="Código")]
        [Key]
        [Required(ErrorMessage = "Campo requerido")]
        public uint Id { get; set; }

        [StringLength(20, ErrorMessage = "Nome não pode exceder 20 caracteres")]
        public string? Nome { get; set; }

        public StatusEnum? Status { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "Valor deve ser positivo")]
        public float? Valor { get; set; }

        [StringLength(150, ErrorMessage = "Descrição não pode exceder 150 caracteres")]
        public string? Descricao { get; set; }
    }
}
