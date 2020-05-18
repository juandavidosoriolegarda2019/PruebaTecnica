using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Prueba.BackEnd.Data;
using Prueba.BackEnd.Models;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using System.Web.Http.Description;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;
using HttpPutAttribute = Microsoft.AspNetCore.Mvc.HttpPutAttribute;
using HttpDeleteAttribute = Microsoft.AspNetCore.Mvc.HttpDeleteAttribute;

namespace Prueba.BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class ValueController : ApiController
    {
        private readonly ILogger<ValueController> _logger;
        private readonly ValueRepository _repository;

        public ValueController(ValueRepository repository)
        {
            this._repository = repository ?? throw new ArgumentNullException(nameof(repository));
            Request = new System.Net.Http.HttpRequestMessage();
        }
        [HttpGet]
        public async Task<List<Persona>> GetAll()
        {
            return await _repository.GetAll();
        }

        [HttpGet]
        [Route("{intId}")]
        public async Task<Persona> GetbyId(int @NroDocumento)
        {
            return await _repository.Getbyid(@NroDocumento);
        }
        [HttpGet]
        [Route("GetFilter")]
        public async Task<List<Persona>> GetFilter(string filtro)
        {
            return await _repository.GetFilter(filtro);
        }
         
        [HttpGet]
        [Route("GetPersonasPremios")]
        public async Task<List<PersonasXPremios>> GetPersonasPremios()
        {
            return await _repository.GetPersonaXPremio();
        }

        [HttpGet]
        [Route("AsignarPremio")]
        public HttpResponseMessage AsignarPremio()
        {
            var configuration = new HttpConfiguration();
            var request = new HttpRequestMessage();
            request.SetConfiguration(configuration);

            
            string msj = string.Empty;
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            msj = _repository.AsignarPremio();  
            if (msj.Length <= 0)
            {
                return request.CreateResponse(HttpStatusCode.OK, msj);
            }
            else
            {
                return request.CreateResponse(HttpStatusCode.BadRequest, msj);
            }
        }

        [HttpPost]
        public HttpResponseMessage Post(Persona value)
        {
            HttpResponseMessage messageR;
      
            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            Task<string>a = _repository.Insert(value); 
            if (a.Result.Length<=0)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            { 
                return messageR= Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }

        [HttpPut]
        public async Task<bool> Put(Persona value)
        {

           return await _repository.Update(value); 
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int IntId)
        {
            HttpResponseMessage messageR;

            if (!ModelState.IsValid)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
            }
            Task<string> a = _repository.Delete(IntId);
            if (a.Result.Length <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return messageR = Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
         
    }
}