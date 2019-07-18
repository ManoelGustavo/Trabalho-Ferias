using Model;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Views.Controllers
{
    public class ProjetoController : Controller
    {
        private ProjetoRepository repository;

        public ProjetoController()
        {
            repository = new ProjetoRepository();
        }

        [HttpGet]
        // GET: Projeto
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ObterTodos(string busca)
        {
            List<Projeto> projetos = repository.ObterTodos(busca);
            return Json(projetos, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Store(Projeto projeto)
        {
            projeto.RegistroAtivo = true;
            repository.Inserir(projeto);
            return Json(projeto);
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
            Projeto projeto = repository.ObterPeloId(id);
            return Json(projeto, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(Projeto projeto)
        {
            bool alterou = repository.Alterar(projeto);
            return Json(new { status = alterou });
        }
    }
}