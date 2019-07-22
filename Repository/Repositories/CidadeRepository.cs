using Model;
using Repository.DataBase;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Desenvolvido por Matheus Donato
namespace Repository.Repositories
{
    public class CidadeRepository : ICidadeRepository
    {
        public SistemaContext context;

        public CidadeRepository()
        {
            context = new SistemaContext();
        }

        public bool Alterar(Cidade cidade)
        {
            Cidade cidadeOriginal = context.Cidades.FirstOrDefault(x => x.Id == cidade.Id);
            if (cidadeOriginal == null)
            {
                return false;
            }
            cidadeOriginal.IdEstado = cidade.IdEstado;
            cidadeOriginal.Nome = cidade.Nome;
            cidadeOriginal.NumeroHabitantes = cidade.NumeroHabitantes;
            context.SaveChanges();
            return true;
        }

        public bool Apagar(int id)
        {
            Cidade cidade = context.Cidades.FirstOrDefault(x => x.Id == id);
            if (cidade == null)
            {
                return false;
            }
            cidade.RegistroAtivo = false;
            context.SaveChanges();
            return true;
        }

        public int Inserir(Cidade cidade)
        {
            cidade.DataCriacao = DateTime.Now;
            context.Cidades.Add(cidade);
            context.SaveChanges();
            return cidade.Id;
        }

        public Cidade ObterPeloId(int id)
        {
            return context.Cidades.FirstOrDefault(x => x.Id == id);
        }

        public List<Cidade> ObterTodos(string busca)
        {
            return context.Cidades.Where(x => x.RegistroAtivo && (string.IsNullOrEmpty(busca) ? true : (x.Estado.Nome.Contains(busca) || x.Nome.Contains(busca)))).OrderBy(x => x.Nome).ToList();
        }
    }
}
