using Model;
using Newtonsoft.Json;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Views.Controllers
{
    public class EstadoController : Controller
    {
        private EstadoRepository repository;

        public EstadoController()
        {
            repository = new EstadoRepository();
        }

        [HttpGet]
        // GET: Estado
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ContentResult ObterTodos(string busca)
        {
            List<Estado> estados = repository.ObterTodos(busca);

            // Para evitar erro de referência circular entre Cidade e Estado, é utilizado 
            // o Newtonsoft para serializar o objeto com a configuração ReferenceLoopHandling para Ignore, fazendo com que a 
            // referência cirular seja ignorada.
            string jsonResult = JsonConvert.SerializeObject(estados, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Content(jsonResult, "application/json");
        }

        [HttpPost]
        // Para teste: [HttpGet]
        // Para executar: Estado/Store?Nome=Rio de Janeiro&Sigla=RJ
        public JsonResult Store(Estado estado)
        {
            estado.RegistroAtivo = true;
            repository.Inserir(estado);
            return Json(estado);
        }

        [HttpGet]
        [Route("apagar/{id}")]
        // Para executar: Estado/Apagar?id=1
        public JsonResult Apagar(int id)
        {
            bool apagou = repository.Apagar(id);
            return Json(new { status = apagou }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("obterpeloid/{id}")]
        public ContentResult ObterPeloId(int id)
        {
            Estado estado = repository.ObterPeloId(id);
            string jsonResult = JsonConvert.SerializeObject(estado, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Content(jsonResult, "application/json");
        }

        [HttpPost]
        public JsonResult Update(Estado estado)
        {
            bool alterou = repository.Alterar(estado);
            return Json(new { status = alterou });
        }
    }
}