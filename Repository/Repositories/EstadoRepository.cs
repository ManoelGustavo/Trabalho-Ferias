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
    public class EstadoRepository : IEstadoRepository
    {
        public SistemaContext context;

        public EstadoRepository()
        {
            context = new SistemaContext();
        }

        public bool Alterar(Estado estado)
        {
            Estado estadoOriginal = context.Estados.FirstOrDefault(x => x.Id == estado.Id);
            if (estadoOriginal == null)
            {
                return false;
            }
            estadoOriginal.Nome = estado.Nome;
            estadoOriginal.Sigla = estado.Sigla;
            context.SaveChanges();
            return true;
        }

        public bool Apagar(int id)
        {
            Estado estado = context.Estados.FirstOrDefault(x => x.Id == id);
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
            return context.Estados.FirstOrDefault(x => x.Id == id);
        }

        public List<Estado> ObterTodos(string busca)
        {
            return context.Estados.Where(x => x.RegistroAtivo && (string.IsNullOrEmpty(busca) ? true : (x.Nome.Contains(busca) || x.Sigla.Contains(busca)))).OrderBy(x => x.Sigla).ToList();
        }
    }
}
