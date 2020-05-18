using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Prueba.BackEnd.Controllers;
using Prueba.BackEnd.Models;

namespace Prueba.FrontEnd.Pages.Listas
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public List<Persona> Personas { get; set; }

        [TempData]
        public string Mensaje { get; set; } 

        [BindProperty]
        public Persona Persona { get; set; }
        private readonly ValueController _valueController;
        public IndexModel(ValueController vc)
        {
            _valueController = vc; 
        }
        public void OnGet(string buscar)
        {
            if (!string.IsNullOrEmpty(buscar))
            {
                Personas = (List<Persona>)_valueController.GetFilter(buscar).Result;
            }
            else
            {
                Personas = (List<Persona>)_valueController.GetAll().Result; 
            }
        } 
    
        public async Task<IActionResult> OnPostDelete(int IntId)
        {
            HttpResponseMessage messageR;
            messageR = _valueController.Delete(IntId); 
            if (messageR.IsSuccessStatusCode)
            {
                Mensaje = "Se elimino el registro Exitosamente!";

            }
            else
            {
                Mensaje ="¡No es posible Eliminar una Persona con Premio Asignado!";
        
            }
            return RedirectToPage("Index");

        }
    }
}