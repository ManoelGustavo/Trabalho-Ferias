using Model;
using Repository.DataBase;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Desenvolvido por Gustavo Manoel
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
            Categoria categoriaOriginal = (from x in context.Categorias where x.Id == categoria.Id select x).FirstOrDefault();
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
            Categoria categoria = (from categorias in context.Categorias where categorias.Id == id select categorias).FirstOrDefault();

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
            context.Categorias.Add(categoria);
            context.SaveChanges();
            return categoria.Id;
        }

        public Categoria ObterPeloId(int id)
        {
            return (from categoria in context.Categorias where categoria.Id == id select categoria).FirstOrDefault();
        }

        public List<Categoria> ObterTodos(string busca)
        {
            busca = ($"%{busca}%");
            return (from categoria 
                    in context.Categorias
                    where categoria.Nome.Contains(busca)
                    orderby categoria.Nome
                    select categoria).ToList();
        }
    }
}
