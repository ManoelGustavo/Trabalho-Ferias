using Model;
using Repository.DataBase;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Desenvolvido por Nathan Micael
namespace Repository.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        public SistemaContext context;

        public TarefaRepository()
        {
            context = new SistemaContext();
        }

        public bool Alterar(Tarefa tarefa)
        {
            // LINQ.
            /*
            Tarefa tarefaOriginal = (from tarefas in context.Tarefas
                                     where tarefas.Id == tarefa.Id
                                     select tarefas).FirstOrDefault();
             */

            // Lambda Expression.
            Tarefa tarefaOriginal = context.Tarefas.FirstOrDefault(x => x.Id == tarefa.Id);
            if(tarefaOriginal == null)
            {
                return false;
            }
            tarefaOriginal.IdUsuarioResponsavel = tarefa.IdUsuarioResponsavel;
            tarefaOriginal.IdProjeto = tarefa.IdProjeto;
            tarefaOriginal.IdCategoria = tarefa.IdCategoria;
            tarefaOriginal.Titulo = tarefa.Titulo;
            tarefaOriginal.Descricao = tarefa.Descricao;
            tarefaOriginal.Duracao = tarefa.Duracao;
            context.SaveChanges();
            return true;
        }

        public bool Apagar(int id)
        {
            Tarefa tarefa = context.Tarefas.FirstOrDefault(x => x.Id == id);
            if (tarefa == null)
            {
                return false;
            }
            tarefa.RegistroAtivo = false;
            context.SaveChanges();
            return true;
        }

        public int Inserir(Tarefa tarefa)
        {
            tarefa.DataCriacao = DateTime.Now;
            context.Tarefas.Add(tarefa);
            context.SaveChanges();
            return tarefa.Id;
        }

        public Tarefa ObterPeloId(int id)
        {
            return context.Tarefas.FirstOrDefault(x => x.Id == id);
        }

        public List<Tarefa> ObterTodos(string busca)
        {
            return context.Tarefas.Where(x => x.RegistroAtivo && x.Usuario.Nome.Contains(busca)).OrderBy(x => x.Usuario.Nome).ToList();
        }
    }
}
