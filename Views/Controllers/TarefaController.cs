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

        public ActionResult Index()
        {
            List<Tarefa> tarefas = repository.ObterTodos("");
            ViewBag.Tarefas = tarefas;
            return View();
        }

        public ActionResult Cadastro()
        {
            ProjetoRepository projetoRepository = new ProjetoRepository();
            List<Projeto> projetos = projetoRepository.ObterTodos("");
            ViewBag.Projetos = projetos;

            UsuarioRepository usuarioRepository = new UsuarioRepository();
            List<Usuario> usuarios = usuarioRepository.ObterTodos("");
            ViewBag.Usuarios = usuarios;

            CategoriaRepository categoriaRepository = new CategoriaRepository();
            List<Categoria> categorias = categoriaRepository.ObterTodos("");
            ViewBag.Categorias = categorias;
            return View();
        }

        public ActionResult Store(int idUsuarioResponsavel, int idProjeto, int idCategoria, string titulo, string descricao, DateTime duracao)
        {
            Tarefa tarefa = new Tarefa();
            tarefa.IdUsuarioResponsavel = idUsuarioResponsavel;
            tarefa.IdProjeto = idProjeto;
            tarefa.IdCategoria = idCategoria;
            tarefa.Titulo = titulo;
            tarefa.Descricao = descricao;
            tarefa.Duracao = duracao.Date;
            repository.Inserir(tarefa);
            return RedirectToAction("Index");
        }

        public ActionResult Apagar(int id)
        {
            repository.Apagar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            Tarefa tarefa = repository.ObterPeloId(id);
            ViewBag.Tarefa = tarefa;

            ProjetoRepository projetoRepository = new ProjetoRepository();
            List<Projeto> projetos = projetoRepository.ObterTodos("");
            ViewBag.Projetos = projetos;

            UsuarioRepository usuarioRepository = new UsuarioRepository();
            List<Usuario> usuarios = usuarioRepository.ObterTodos("");
            ViewBag.Usuarios = usuarios;

            CategoriaRepository categoriaRepository = new CategoriaRepository();
            List<Categoria> categorias = categoriaRepository.ObterTodos("");
            ViewBag.Categorias = categorias;
            return View();
        }

        public ActionResult Update(int id, int idUsuarioResponsavel, int idProjeto, int idCategoria, string titulo, string descricao, DateTime duracao)
        {
            Tarefa tarefa = new Tarefa();
            tarefa.Id = id;
            tarefa.IdUsuarioResponsavel = idUsuarioResponsavel;
            tarefa.IdProjeto = idProjeto;
            tarefa.IdCategoria = idCategoria;
            tarefa.Titulo = titulo;
            tarefa.Descricao = descricao;
            tarefa.Duracao = duracao;
            repository.Alterar(tarefa);
            return RedirectToAction("Index");
        }
    }
}