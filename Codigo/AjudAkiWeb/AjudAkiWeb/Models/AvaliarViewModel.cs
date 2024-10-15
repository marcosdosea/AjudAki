using Core;
using System.ComponentModel.DataAnnotations;

namespace AjudAkiWeb.Models
{
    public class AvaliarViewModel
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Código da avaliação é obrigatório")]
        [Key]
        public uint Id { get; set; }

        [Display(Name = "Nota do Serviço")]
        [Required(ErrorMessage = "A nota do serviço é obrigatória")]
        public sbyte NotaServico { get; set; }

        [Display(Name = "Nota do Profissional")]
        [Required(ErrorMessage = "A nota do profissional é obrigatória")]
        public sbyte NotaProfissional { get; set; }

        [Required(ErrorMessage = "O status da avaliação é obrigatório")]
        public int Status { get; set; }

        [Display(Name = "Comentário")]
        [StringLength(500, ErrorMessage = "O comentário pode ter no máximo 500 caracteres")]
        public string? Comentario { get; set; }

        [Display(Name = "Código da Contratação")]
        [Required(ErrorMessage = "O Código da contratação é obrigatório")]
        public uint IdContratacao { get; set; }

        [Display(Name = "Contratação")]
        [Required(ErrorMessage = "A navegação da contratação é obrigatória")]
        public virtual Contratacao IdContratacaoNavigation { get; set; } = null!;
    }
}
