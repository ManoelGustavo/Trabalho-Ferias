using Model;
using Repository.DataBase;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class CategoriaRepository : ICategoriaRepository
    {
        public SistemaContext context;

        public CategoriaRepository()
        {
            context = new SistemaContext();
        }
        public bool Alterar(Categoria categoria)
        {
            Categoria categoriaOriginal = context.Categorias.FirstOrDefault(x => x.Id == categoria.Id);
            if (categoriaOriginal == null)
            {
                return false;
            }
            categoriaOriginal.Nome = categoria.Nome;
            context.SaveChanges();
            return true;
        }

        public bool Apagar(int id)
        {
            Categoria categoria = context.Categorias.FirstOrDefault(x => x.Id == id);
            if (categoria == null)
            {
                return false;
            }
            categoria.RegistroAtivo = false;
            context.SaveChanges();
            return true;
        }

        public int Inserir(Categoria categoria)
        {
            categoria.DataCriacao = DateTime.Now;
            context.Categorias.Add(categoria);
            context.SaveChanges();
            return categoria.Id;
        }

        public Categoria ObterPeloId(int id)
        {
            return context.Categorias.FirstOrDefault(x => x.Id == id);
        }

        public List<Categoria> ObterTodos(string busca)
        {
            return context.Categorias.Where(x => x.RegistroAtivo && (string.IsNullOrEmpty(busca) ? true : (x.Nome.Contains(busca)))).OrderBy(x => x.Nome).ToList();
        }
    }
}
