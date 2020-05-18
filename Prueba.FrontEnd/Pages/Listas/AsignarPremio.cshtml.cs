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
    public class AsignarPremio : PageModel
    {
        [TempData]
        public string Mensaje { get; set; }
        [BindProperty]
        public IEnumerable<PersonasXPremios> _PersonasxPremios { get; set; } 
  
        private readonly ValueController _valueController; 
        public AsignarPremio(ValueController vc)
        {
         
            _valueController = vc;
        }
      

        public void OnGet()
        {

            _PersonasxPremios = (List<PersonasXPremios>)_valueController.GetPersonasPremios().Result;

        }
        public IActionResult OnPost()
        {
            HttpResponseMessage messageR;
            messageR = _valueController.AsignarPremio();
            Mensaje = messageR.Content.ReadAsAsync<string>().Result;
            if (messageR.IsSuccessStatusCode)
            {
                Mensaje = "Se Asignarón los premios Satisfactoriamente";
            }
            else
            {
                Mensaje = messageR.Content.ReadAsAsync<string>().Result;
            }
            return RedirectToPage("AsignarPremio");
        }
    }
}