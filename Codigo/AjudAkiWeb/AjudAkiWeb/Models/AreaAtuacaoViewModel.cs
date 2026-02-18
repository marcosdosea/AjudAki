using System.ComponentModel.DataAnnotations;

namespace AjudAkiWeb.Models
{
    public class AreaAtuacaoViewModel
    {
        [Display(Name ="Código")]
        [Required(ErrorMessage = "Código da área de atuação é obrigatório")]
        [Key]
        public uint Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [StringLength(50)]
        public string Nome { get; set; } = null!;

        public ICollection<TipoServicoViewModel> TiposServico { get; set; } = new List<TipoServicoViewModel>();

    }
}
