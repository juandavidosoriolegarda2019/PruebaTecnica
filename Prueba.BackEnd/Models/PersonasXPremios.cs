using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba.BackEnd.Models
{
    public class PersonasXPremios
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }
        [Display(Name = "Codigo")]
        [Required]
        public string Codigo { get; set; }
        [Display(Name = "Nro. Documento")]
        [Required]
        public string NroDocumento { get; set; }
        [Required]
        [Display(Name = "Premio")]
        public string Premio { get; set; }
        [Required]
        [Display(Name = "Nombres")]
        public string Nombres { get; set; }
        [Required]

        [Display(Name = "Fecha Premio")]
        public DateTime FechaPremio { get; set; }
    }
}
