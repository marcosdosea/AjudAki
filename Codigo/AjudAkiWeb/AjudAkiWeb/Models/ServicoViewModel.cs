using Core;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace AjudAkiWeb.Models
{
    public class ServicoViewModel
    {

        [Display(Name ="Código")]
        [Required(ErrorMessage = "Código do autor é obrigatório")]
        [Key]
        public uint Id { get; set; }

        [Display(Name = "Nome")]
        [StringLength(50)]
        public string? Nome { get; set; }

        [Display(Name = "Data")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Campo Obrigatório")]
        public DateTime Data { get; set; }
    }
}
