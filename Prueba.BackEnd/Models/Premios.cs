using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Prueba.BackEnd.Models
{
    public class Premios
    {
        [Key]
        [Display(Name = "Id")]
        public int intId { get; set; }
        [Display(Name = "Código Premio")]
        [Required]
        public string Codigo { get; set; }
        [Required]
        [Display(Name = "Descrpcion")]
        public string Descripcion { get; set; }
        [Required]
        [Display(Name = "Cantidad")]
        public int Cantidad { get; set; }
    }
}
