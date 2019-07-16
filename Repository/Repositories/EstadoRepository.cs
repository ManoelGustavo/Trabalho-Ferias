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
    public class EstadoRepository : IEstadoRepository
    {
        public SistemaContext context;

        public EstadoRepository()
        {
            context = new SistemaContext();
        }

        public bool Alterar(Estado estado)
        {
            Estado estadoOriginal = (from x in context.Estados where x.Id == estado.Id select x).FirstOrDefault();
            if (estadoOriginal == null)
            {
                return false;
            }
            estado.Nome = estado.Nome;
            estado.Sigla = estado.Sigla;
            context.SaveChanges();
            return true;
        }

        public bool Apagar(int id)
        {
            Estado estado = (from estados in context.Estados where estados.Id == id select estados).FirstOrDefault();

            if (estado == null)
            {
                return false;
            }
            estado.RegistroAtivo = false;
            context.SaveChanges();
            return true;
        }

        public int Inserir(Estado estado)
        {
            estado.DataCriacao = DateTime.Now;
            context.Estados.Add(estado);
            context.SaveChanges();
            return estado.Id;
        }

        public Estado ObterPeloId(int id)
        {
            return (from estado in context.Estados where estado.Id == id select estado).FirstOrDefault();
        }

        public List<Estado> ObterTodos(string busca)
        {
            busca = ($"%{busca}%");
            return (from estado in context.Estados
                    where estado.Nome.Contains(busca)|| estado.Sigla.Contains(busca)
                    orderby estado.Sigla
                    select estado).ToList();
        }
    }
}
