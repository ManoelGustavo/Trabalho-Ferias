using Model;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
// Desenvolvido por Matheus Donato
namespace Views.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteRepository repository;

        public ClienteController()
        {
            repository = new ClienteRepository();
        }

        [HttpGet]
        // GET: Cliente
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ObterTodos(string busca)
        {
            List<Cliente> clientes = repository.ObterTodos(busca);
            return Json(clientes, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Store(Cliente cliente)
        {
            cliente.RegistroAtivo = true;
            repository.Inserir(cliente);
            return Json(cliente);
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
            Cliente cliente = repository.ObterPeloId(id);
            return Json(cliente, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Update(Cliente cliente)
        {
            bool alterou = repository.Alterar(cliente);
            return Json(new { status = alterou });
        }
    }
}