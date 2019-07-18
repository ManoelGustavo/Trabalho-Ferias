using Model;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Views.Controllers
{
    public class TarefaController : Controller
    {
        private TarefaRepository repository;

        public TarefaController()
        {
            repository = new TarefaRepository();
        }

        [HttpGet]
        // GET: Tarefa
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ObterTodos(string busca)
        {
            List<Tarefa> tarefas = repository.ObterTodos(busca);
            return Json(tarefas, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Store(Tarefa tarefa)
        {
            tarefa.RegistroAtivo = true;
            repository.Inserir(tarefa);
            return Json(tarefa);
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
            Tarefa tarefa = repository.ObterPeloId(id);
            return Json(tarefa, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(Tarefa tarefa)
        {
            bool alterou = repository.Alterar(tarefa);
            return Json(new { status = alterou });
        }
    }
}