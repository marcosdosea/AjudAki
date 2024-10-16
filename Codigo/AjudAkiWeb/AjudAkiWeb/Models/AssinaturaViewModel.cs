using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AjudAkiWeb.Models
{
    public enum AssinaturaStatusEnum
    {
        ATIVA,
        INATIVA
    }
    public enum AssinaturaNomeEnum
    {
        FREE, BÁSICO, AVANÇADO
    }
    public class AssinaturaViewModel
    {
        [Display(Name = "Código")]
        [Key]
        [Required(ErrorMessage = "Campo requerido")]
        public uint Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public AssinaturaNomeEnum Nome { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public AssinaturaStatusEnum Status { get; set; }

        [Range(0, float.MaxValue, ErrorMessage = "Valor deve ser positivo")]
        public float? Valor { get; set; }

        [StringLength(150, ErrorMessage = "Descrição não pode exceder 150 caracteres")]
        public string? Descricao { get; set; }

        public SelectList? PlanoList { get; set; }

        public SelectList? StatusList { get; set; }
    }
}
