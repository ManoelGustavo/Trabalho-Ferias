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
    public class CidadeController : Controller
    {
        private CidadeRepository repository;

        public CidadeController()
        {
            repository = new CidadeRepository();
        }

        public ActionResult Index()
        {
            List<Cidade> cidades = repository.ObterTodos("");
            ViewBag.Cidades = cidades;
            return View();
        }

        public ActionResult ObterTodos(string busca)
        {
            List<Cidade> cidades = repository.ObterTodos(busca);
            string jsonResult = JsonConvert.SerializeObject(cidades, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });
            return Content(jsonResult, "application/json");
        }

        public ActionResult Cadastro()
        {
            EstadoRepository estadoRepository = new EstadoRepository();
            List<Estado> estados = estadoRepository.ObterTodos("");
            ViewBag.Estados = estados;
            return View();
        }

        public ActionResult Store(int idEstado, string nome, string numeroHabitantes)
        {
            Cidade cidade = new Cidade();
            cidade.IdEstado = idEstado;
            cidade.Nome = nome;
            cidade.NumeroHabitantes = numeroHabitantes;
            repository.Inserir(cidade);
            return RedirectToAction("Index");
        }

        public ActionResult Apagar(int id)
        {
            repository.Apagar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            Cidade cidade = repository.ObterPeloId(id);
            ViewBag.Cidade = cidade;

            EstadoRepository estadoRepository = new EstadoRepository();
            List<Estado> estados = estadoRepository.ObterTodos("");
            ViewBag.Estados = estados;
            return View();
        }

        public ActionResult Update(int idEstado, string nome, string numeroHabitantes, int id)
        {
            Cidade cidade = new Cidade();
            cidade.Id = id;
            cidade.IdEstado = idEstado;
            cidade.Nome = nome;
            cidade.NumeroHabitantes = numeroHabitantes;
            repository.Alterar(cidade);
            return RedirectToAction("Index");
        }
    }
}