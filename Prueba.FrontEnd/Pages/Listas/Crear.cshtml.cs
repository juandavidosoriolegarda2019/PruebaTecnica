using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Prueba.BackEnd.Models;
using Prueba.BackEnd;
using Prueba.BackEnd.Controllers;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Net.Http;

namespace Prueba.FrontEnd.Pages.Listas
{
    public class CrearModel : PageModel
    {
        [TempData]
        public string Mensaje { get; set; }
        [BindProperty]
        public IEnumerable<Persona> Personas { get; set; } 
        [BindProperty]
        public Persona Persona { get; set; }

        [BindProperty]
        public List<SelectListItem> lista { get; set; } 
        [BindProperty]
        public List<SelectListItem> listaSubAreas { get; set; }

        private readonly ValueController _valueController; 
        public CrearModel(ValueController vc)
        {
         
            _valueController = vc;
        }
      

        public void OnGet()
        { 
        }
        public async Task<IActionResult> OnPost()
        {
            HttpResponseMessage messageR;

            if (!ModelState.IsValid)
            {
                return Page();
            }else
            {
                /*Consumo la API*/

                Persona obj = new Persona();
                obj.NroDocumento = Persona.NroDocumento;
                obj.TipoDocumento = Persona.TipoDocumento;
                obj.Nombres = Persona.Nombres;
                obj.Apellidos = Persona.Apellidos;
                obj.FechaNacimiento = Persona.FechaNacimiento;  

                messageR =   _valueController.Post(obj);  
               
                if (messageR.IsSuccessStatusCode)
                {
                    return RedirectToPage("Index"); 
                }
                else
                { 
                    Mensaje ="Ya existe un Registro con el Nro.Documento:"+" "+ obj.NroDocumento.ToString()+" y el tipo documento:"+" "+obj.TipoDocumento.ToString();
                    return RedirectToPage("Crear");
                } 
            }
        }
    }
}