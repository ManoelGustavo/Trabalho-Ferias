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
    public class ProjetoController : Controller
    {
        private ProjetoRepository repository;

        public ProjetoController()
        {
            repository = new ProjetoRepository();
        }

        // GET: Projeto
        public ActionResult Index()
        {
            List<Projeto> projetos = repository.ObterTodos("");
            ViewBag.Projetos = projetos;
            return View();
        }

        public ActionResult ObterTodos(string busca)
        {
            List<Projeto> projetos = repository.ObterTodos(busca);
            string jsonResult = JsonConvert.SerializeObject(projetos, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Content(jsonResult, "application/json");
        }

        public ActionResult Cadastro()
        {
            ClienteRepository clienteRepository = new ClienteRepository();
            List<Cliente> clientes = clienteRepository.ObterTodos("");
            ViewBag.Clientes = clientes;
            return View();
        }

        public ActionResult Store(int idCliente, string nome, DateTime dataCriacaoProjeto, DateTime dataFinalizacao)
        {
            Projeto projeto = new Projeto();
            projeto.IdCliente = idCliente;
            projeto.Nome = nome;
            projeto.DataCriacaoProjeto = dataCriacaoProjeto;
            projeto.DataFinalizacao = dataFinalizacao;
            repository.Inserir(projeto);
            return RedirectToAction("Index");
        }

        public ActionResult Apagar(int id)
        {
            repository.Apagar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            Projeto projeto = repository.ObterPeloId(id);
            ViewBag.Projeto = projeto;

            ClienteRepository clienteRepository = new ClienteRepository();
            List<Cliente> clientes = clienteRepository.ObterTodos("");
            ViewBag.Clientes = clientes;
            return View();
        }

        public ActionResult Update(int idCliente, string nome, DateTime dataCriacaoProjeto, DateTime dataFinalizacao, int id)
        {
            Projeto projeto = new Projeto();
            projeto.Id = id;
            projeto.IdCliente = idCliente;
            projeto.Nome = nome;
            projeto.DataCriacaoProjeto = dataCriacaoProjeto;
            projeto.DataFinalizacao = dataFinalizacao;
            repository.Alterar(projeto);
            return RedirectToAction("Index");
        }
    }
}