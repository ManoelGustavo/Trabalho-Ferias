using Model;
using Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Views.Controllers
{
    public class ClienteController : Controller
    {
        private ClienteRepository repository;

        public ClienteController()
        {
            repository = new ClienteRepository();
        }

        public ActionResult Index()
        {
            List<Cliente> clientes = repository.ObterTodos("");
            ViewBag.Clientes = clientes;
            return View();
        }

        public ActionResult Cadastro()
        {
            CidadeRepository cidadeRepository = new CidadeRepository();
            List<Cidade> cidades = cidadeRepository.ObterTodos("");
            ViewBag.Cidades = cidades;
            return View();
        }

        public ActionResult Store(int idCidade, string nome, string cpf, DateTime dataNascimento, int numero, string complemento, string logradouro, string cep)
        {
            Cliente cliente = new Cliente();
            cliente.IdCidade = idCidade;
            cliente.Nome = nome;
            cliente.Cpf = cpf;
            cliente.DataNascimento = dataNascimento;
            cliente.Numero = numero;
            cliente.Complemento = complemento;
            cliente.Logradouro = logradouro;
            cliente.Cep = cep;
            repository.Inserir(cliente);
            return RedirectToAction("Index");
        }

        public ActionResult Apagar(int id)
        {
            repository.Apagar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            Cliente cliente = repository.ObterPeloId(id);
            ViewBag.Cliente = cliente;

            CidadeRepository cidadeRepository = new CidadeRepository();
            List<Cidade> cidades = cidadeRepository.ObterTodos("");
            ViewBag.Cidades = cidades;
            return View();
        }

        public ActionResult Update(int id, int idCidade, string nome, string cpf, DateTime dataNascimento, int numero, string complemento, string logradouro, string cep)
        {
            Cliente cliente = new Cliente();
            cliente.Id = id;
            cliente.IdCidade = idCidade;
            cliente.Nome = nome;
            cliente.Cpf = cpf;
            cliente.DataNascimento = dataNascimento;
            cliente.Numero = numero;
            cliente.Complemento = complemento;
            cliente.Logradouro = logradouro;
            cliente.Cep = cep;
            repository.Alterar(cliente);
            return RedirectToAction("Index");
        }
    }
}