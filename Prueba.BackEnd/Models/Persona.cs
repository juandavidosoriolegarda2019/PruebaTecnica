using System;
using System.ComponentModel.DataAnnotations;

namespace Prueba.BackEnd.Models
{
    public class Persona   
    {
        [Key]
        [Display(Name = "Id")]
        public int IntId { get; set; }
        [Display(Name = "Nro. Documento")]
        [Required]
        public int NroDocumento { get; set; }
        [Required]
        [Display(Name="Tipo Documento")]
        public string TipoDocumento { get; set; }
        [Required]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }
        [Required]
        [Display(Name = "Apellidos")] 
        public string Apellidos { get; set; }
        [Required]
        [Display(Name = "Fecha Nacimiento")]
        public DateTime FechaNacimiento { get; set; }
    }
}
