using Core;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AjudAkiWeb.Models
{
    public class TipoServicoViewModel
    {
        [Required(ErrorMessage = "Código do tipo do serviço é obrigatório")]
        [Key]
        public uint Id { get; set; }

        [Display(Name = "Nome")]
        [StringLength(50)]
        public string? Nome { get; set; }

        public AreaAtuacaoViewModel? AreaAtuacaoViewModel { get; set; }
    }
}
