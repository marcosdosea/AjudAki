using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AjudAkiWeb.Models
{
    public class TipoServicoViewModel
    {
        [Display(Name = "Código do tipo de serviço")]
        [Required(ErrorMessage = "Código do tipo do serviço é obrigatório")]
        [Key]
        public uint Id { get; set; }

        [Display(Name = "Área de atuação")]
        [Required(ErrorMessage = "Código do área de atuação é obrigatório")]
        public uint IdAreaAtuacao { get; set; }

        [Display(Name = "Agenda")]
        [Required(ErrorMessage = "Código do agenda é obrigatório")]
        public uint IdAgenda { get; set; }

        [StringLength(50)]
        [Required(ErrorMessage = "Nome do tipo do serviço é obrigatório")]
        public string? Nome { get; set; }

        public SelectList? ListaAreasAtuacoes { get; set; }
        public SelectList? ListaAgenda { get; set; }
    }
}
