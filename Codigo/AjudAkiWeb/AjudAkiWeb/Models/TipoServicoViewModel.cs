using Core;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AjudAkiWeb.Models
{
    public class TipoServicoViewModel
    {
        [Display(Name = "Código do tipo de serviço")]
        [Required(ErrorMessage = "Código do tipo do serviço é obrigatório")]
        [Key]
        public uint Id { get; set; }

        [StringLength(50)]
        public string? Nome { get; set; }

        [Display(Name = "Código de área de atuação")]
        [Required(ErrorMessage = "Código de área de atuação obrigatório")]
        [Key]
        public uint IdAreaAtuacao { get; set; }

        [Display(Name = "Código da agenda")]
        [Required(ErrorMessage = "Código da agenda obrigatório")]
        [Key]
        public uint IdAgenda { get; set; }
    }
}
