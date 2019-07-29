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
    public class CategoriaController : Controller
    {
        private CategoriaRepository repository;

        public CategoriaController()
        {
            repository = new CategoriaRepository();
        }

        [HttpGet]
        // GET: Categoria
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ContentResult ObterTodos(string busca)
        {
            List<Categoria> categorias = repository.ObterTodos(busca);
            string jsonResult = JsonConvert.SerializeObject(categorias, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Content(jsonResult, "application/json");
        }

        [HttpPost]
        public JsonResult Store(Categoria categoria)
        {
            categoria.RegistroAtivo = true;
            repository.Inserir(categoria);
            return Json(categoria);
        }

        [HttpGet]
        [Route("apagar/{id}")]
        public JsonResult Apagar(int id)
        {
            bool apagou = repository.Apagar(id);
            return Json(new { status = apagou }, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        [Route("obterpeloid/{id}")]
        public ContentResult ObterPeloId(int id)
        {
            Categoria categoria = repository.ObterPeloId(id);
            string jsonResult = JsonConvert.SerializeObject(categoria, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Content(jsonResult, "application/json");
        }

        [HttpPost]
        public JsonResult Update(Categoria categoria)
        {
            bool alterou = repository.Alterar(categoria);
            return Json(new { status = alterou });
        }
    }
}