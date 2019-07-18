using Model;
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
        public JsonResult ObterTodos(string busca)
        {
            List<Usuario> usuarios = repository.ObterTodos(busca);
            return Json(usuarios, JsonRequestBehavior.AllowGet);
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
        public JsonResult ObterPeloId(int id)
        {
            Usuario usuario = repository.ObterPeloId(id);
            return Json(usuario, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(Usuario usuario)
        {
            bool alterou = repository.Alterar(usuario);
            return Json(new { status = alterou });
        }
    }
}