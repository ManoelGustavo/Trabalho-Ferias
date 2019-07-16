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
    class CidadeRepository : ICidadeRepository
    {
        public SistemaContext context;

        public CidadeRepository()
        {
            context = new SistemaContext();
        }

        public bool Alterar(Cidade cidade)
        {
            Cidade cidadeOriginal = (from cidades in context.Cidades where cidades.Id == cidade.Id select cidades).FirstOrDefault();
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
            Cidade cidade = (from cidades in context.Cidades where cidades.Id == id select cidades).FirstOrDefault();
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
            return (from cidade in context.Cidades where cidade.Id == id select cidade).FirstOrDefault();
        }

        public List<Cidade> ObterTodos(string busca)
        {
            return (from cidade in context.Cidades
                    where cidade.RegistroAtivo == true && (cidade.Estado.Nome.Contains(busca) || cidade.Nome.Contains(busca))
                    orderby cidade.Nome select cidade).ToList();
        }
    }
}
