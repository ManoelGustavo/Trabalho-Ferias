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
            List<Projeto> projetos = repository.ObterTodos("");
            ViewBag.Projetos = projetos;
            return View();
        }

        public ActionResult Cadastro()
        {
            ClienteRepository clienteRepository = new ClienteRepository();
            List<Cliente> clientes = clienteRepository.ObterTodos("");
            return View();
        }

        public ActionResult Store(int idCliente, string nome, DateTime data_criacao_projeto, DateTime data_finalizacao)
        {
            Projeto projeto = new Projeto();
            projeto.IdCliente = idCliente;
            projeto.Nome = nome;
            projeto.DataCriacaoProjeto = data_criacao_projeto;
            projeto.DataFinalizacao = data_finalizacao;
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

        public ActionResult Update(int idCliente, string nome, DateTime data_criacao_projeto, DateTime data_finalizacao, int id)
        {
            Projeto projeto = new Projeto();
            projeto.Id = id;
            projeto.IdCliente = idCliente;
            projeto.Nome = nome;
            projeto.DataCriacaoProjeto = data_criacao_projeto;
            projeto.DataFinalizacao = data_finalizacao;
            repository.Alterar(projeto);
            return RedirectToAction("Index");
        }
    }
}