using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Prueba.BackEnd.Controllers;
using Prueba.BackEnd.Models;

namespace Prueba.FrontEnd.Pages.Listas
{

    public class EditarModel : PageModel
    {
        [BindProperty]
        public Persona Persona { get; set; }

        [BindProperty]
        public List<SelectListItem> lista { get; set; }
        [BindProperty]
        public List<SelectListItem> listaSubAreas { get; set; }

        private readonly ValueController _valueController;
         

        public EditarModel(ValueController vc)
        {
            _valueController = vc;
        }


        public async Task OnGet(int IntId)
        {
            Persona = await _valueController.GetbyId(IntId);
             
        }
        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                Persona obj = new Persona();
                obj.NroDocumento = Persona.NroDocumento;
                obj.TipoDocumento = Persona.TipoDocumento;
                obj.Nombres = Persona.Nombres;
                obj.Apellidos = Persona.Apellidos;
                obj.FechaNacimiento = DateTime.Now;// Persona.FechaNacimiento;
    

                await _valueController.Put(obj);
                return RedirectToPage("Index");
            }
        }
    }
}