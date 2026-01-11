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
        public uint Id { get; set; }

        [Display(Name = "Nome do plano")]
        [Required(ErrorMessage = "Campo requerido")]
        public AssinaturaNomeEnum Nome { get; set; }

        [Display(Name = "Status do plano")]
        [Required(ErrorMessage = "Campo requerido")]
        public AssinaturaStatusEnum Status { get; set; }

        [Display(Name = "Valor")]
        [Range(0, float.MaxValue, ErrorMessage = "Valor deve ser positivo")]
        [Required(ErrorMessage = "Campo requerido")]
        public float Valor { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(150, ErrorMessage = "Descrição não pode exceder 150 caracteres")]
        [Required(ErrorMessage = "Campo requerido")]
        public string Descricao { get; set; } = string.Empty;

        public SelectList? PlanoList { get; set; }

        public SelectList? StatusList { get; set; }
    }
}
