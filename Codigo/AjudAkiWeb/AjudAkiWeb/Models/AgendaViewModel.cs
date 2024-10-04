using System.ComponentModel.DataAnnotations;

namespace AjudAkiWeb.Models
{
    public enum TurnoEnum
    {
        MANHA, TARDE, NOITE
    }

    public class AgendaViewModel
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "Código da agenda é obrigatório")]
        [Key]
        public uint Id { get; set; }

        [Display(Name = "Data da agenda")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/mm/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Campo obrigatório")]
        public DateTime Data { get; set; }

        [Display(Name = "Turnos: MANHÃ, TARDE E NOITE")]
        public TurnoEnum? Turno { get; set; } = null;
        
        [Display(Name = "Turno Ocupado (0 = Livre, 1 = Ocupado)")]
        [Range(0, 1, ErrorMessage = "O valor de Turno ocupado deve ser 0 (Livre) ou 1 (Ocupado)")]
        public sbyte TurnoOcupado { get; set; }

        [Display(Name = "Dia Ocupado (0 = Livre, 1 = Ocupado)")]
        [Range(0, 1, ErrorMessage = "O valor de Dia ocupado deve ser 0 (Livre) ou 1 (Ocupado)")]
        public sbyte DiaOcupado { get; set; }
    }
}
