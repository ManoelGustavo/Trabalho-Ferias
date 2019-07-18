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
            Projeto projetoOriginal = (from projetos in context.Projetos where projetos.Id == projeto.Id select projetos).FirstOrDefault();
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
            Projeto projeto = (from projetos in context.Projetos where projetos.Id == id select projetos).FirstOrDefault();
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
            return (from projeto in context.Projetos where projeto.Id == id select projeto).FirstOrDefault();
        }

        public List<Projeto> ObterTodos(string busca)
        {
            return (from projeto in context.Projetos
                    where projeto.RegistroAtivo == true && (projeto.Cliente.Nome.Contains(busca) || projeto.Nome.Contains(busca))
                    orderby projeto.Nome
                    select projeto).ToList();
        }
    }
}
