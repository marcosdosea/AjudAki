using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace AjudAkiWeb.Models
{
    public enum TurnoEnum
    {
        MANHÃ, TARDE, NOITE
    }

    public class AgendaViewModel
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Código da agenda é obrigatório")]
        [Key]
        public uint Id { get; set; }

        [Display(Name = "Data da agenda")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true, ConvertEmptyStringToNull = true)]
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime Data { get; set; }

        [Display(Name = "Turnos: MANHÃ, TARDE E NOITE")]
        public TurnoEnum? Turno { get; set; }

        [Display(Name = "Turno Ocupado")]
        public bool TurnoOcupado { get; set; }

        [Display(Name = "Dia Ocupado")]
        public bool DiaOcupado { get; set; }

        public SelectList? TurnoList { get; set; }

    }
}
