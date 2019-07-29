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
    public class UsuarioController : Controller
    {
        private UsuarioRepository repository;

        public UsuarioController()
        {
            repository = new UsuarioRepository();
        }

        [HttpGet]
        // GET: Usuario
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ContentResult ObterTodos(string busca)
        {
            List<Usuario> usuarios = repository.ObterTodos(busca);
            string jsonResult = JsonConvert.SerializeObject(usuarios, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Content(jsonResult, "application/json");
        }

        [HttpPost]
        public JsonResult Store(Usuario usuario)
        {
            usuario.RegistroAtivo = true;
            repository.Inserir(usuario);
            return Json(usuario);
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
            Usuario usuario = repository.ObterPeloId(id);
            string jsonResult = JsonConvert.SerializeObject(usuario, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Content(jsonResult, "application/json");
        }

        [HttpPost]
        public JsonResult Update(Usuario usuario)
        {
            bool alterou = repository.Alterar(usuario);
            return Json(new { status = alterou });
        }
    }
}