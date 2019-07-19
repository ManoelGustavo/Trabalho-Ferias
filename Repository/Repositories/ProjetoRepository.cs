using Model;
using Repository.DataBase;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Desenvolvido por Matheus Donato
namespace Repository.Repositories
{
    public class ProjetoRepository : IProjetoRepository
    {
        public SistemaContext context;

        public ProjetoRepository()
        {
            context = new SistemaContext();
        }

        public bool Alterar(Projeto projeto)
        {
            Projeto projetoOriginal = context.Projetos.FirstOrDefault(x => x.Id == projeto.Id);
            if (projetoOriginal == null)
            {
                return false;
            }
            projetoOriginal.IdCliente = projeto.IdCliente;
            projetoOriginal.Nome = projeto.Nome;
            projetoOriginal.DataCriacao = projeto.DataCriacao;
            projetoOriginal.DataFinalizacao = projeto.DataFinalizacao;
            context.SaveChanges();
            return true;
        }

        public bool Apagar(int id)
        {
            Projeto projeto = context.Projetos.FirstOrDefault(x => x.Id == id);
            if (projeto == null)
            {
                return false;
            }
            projeto.RegistroAtivo = false;
            context.SaveChanges();
            return true;
        }

        public int Inserir(Projeto projeto)
        {
            projeto.DataCriacao = DateTime.Now;
            context.Projetos.Add(projeto);
            context.SaveChanges();
            return projeto.Id;
        }

        public Projeto ObterPeloId(int id)
        {
            return context.Projetos.FirstOrDefault(x => x.Id == id);
        }

        public List<Projeto> ObterTodos(string busca)
        {
            return context.Projetos.Where(x => x.RegistroAtivo && x.Cliente.Nome.Contains(busca) || x.Nome.Contains(busca)).OrderBy(x => x.Nome).ToList();
        }
    }
}
