using Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AjudAkiWeb.Models
{
    public class AvaliarViewModel
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Código da avaliação é obrigatório")]
        [Key]
        public uint Id { get; set; }

        [Display(Name = "Contratação")]
        public int IdContratacao { get; set; }

        [Display(Name = "Nota do Serviço")]
        [Required(ErrorMessage = "A nota do serviço é obrigatória")]
        [Range(0, 5, ErrorMessage = "A nota do serviço deve ser entre 0 e 5")]
        public sbyte NotaServico { get; set; }

        [Display(Name = "Nota do Profissional")]
        [Required(ErrorMessage = "A nota do profissional é obrigatória")]
        [Range(0, 5, ErrorMessage = "A nota do profissional deve ser entre 0 e 5")]
        public sbyte NotaProfissional { get; set; }

        [Required(ErrorMessage = "O status da avaliação é obrigatório")]
        public int Status { get; set; }

        [Display(Name = "Comentário")]
        [StringLength(500, ErrorMessage = "O comentário pode ter no máximo 500 caracteres")]
        public string? Comentario { get; set; }

        [Display(Name = "Contratação")]
        [Required(ErrorMessage = "A navegação da contratação é obrigatória")]
        public virtual Contratacao IdContratacaoNavigation { get; set; } = null!;
        public SelectList? ListaContratacaos { get; set; }
    }
}
