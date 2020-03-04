using System.Collections.Generic;
using System.Net.Mime;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;
using System.Web.Http.Results;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI1.Models;

namespace WebAPI1.Controllers
{
    public class ContatoController : ApiController
    {
        static readonly IContatoRepositorio repositorio = new ContatoRepositorio();
        // implementar retornos 404 Unauthorized, quando for implementada a autenticação na API

        [HttpGet]
        public HttpResponseMessage Get(string id)
        {
            Contato contato = repositorio.Get(id);
            if (contato==null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            } else
            {
                string json = JsonConvert.SerializeObject(contato);
                return Request.CreateResponse(HttpStatusCode.OK, json);
            }
        }

        [HttpPut]
        public HttpResponseMessage Put(string id, Contato contato)
        {
            if (repositorio.Update(id, contato))
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(string id)
        {
            if (repositorio.Remove(id))
            {
                return Request.CreateResponse(HttpStatusCode.NoContent);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
        }

        [HttpGet]
        public HttpResponseMessage Get(int size = 10, int page = 0)
        {
            IEnumerable<Contato> contatos = repositorio.GetAll(size, page);
            if (contatos == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            else
            {
                string json = JsonConvert.SerializeObject(contatos);
                return Request.CreateResponse(HttpStatusCode.OK, json);
            }
        }

        [HttpPost]
        public HttpResponseMessage Post(Contato contato)
        {
            if (repositorio.Add(contato))
            {
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
    }
}
