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
    public class ClienteRepository : IClienteRepository
    {
        public SistemaContext context;

        public ClienteRepository()
        {
            context = new SistemaContext();
        }

        public bool Alterar(Cliente cliente)
        {
            Cliente clienteOriginal = context.Clientes.FirstOrDefault(x => x.Id == cliente.Id);
            if (clienteOriginal == null)
            {
                return false;
            }
            clienteOriginal.IdCidade = cliente.IdCidade;
            clienteOriginal.Nome = cliente.Nome;
            clienteOriginal.Cpf = cliente.Cpf;
            clienteOriginal.DataNascimento = cliente.DataNascimento;
            clienteOriginal.Numero = cliente.Numero;
            clienteOriginal.Complemento = cliente.Complemento;
            clienteOriginal.Logradouro = cliente.Logradouro;
            clienteOriginal.Cep = cliente.Cep;
            context.SaveChanges();
            return true;
        }

        public bool Apagar(int id)
        {
            Cliente cliente = context.Clientes.FirstOrDefault(x => x.Id == id);
            if (cliente == null)
            {
                return false;
            }
            cliente.RegistroAtivo = false;
            context.SaveChanges();
            return true;
        }

        public int Inserir(Cliente cliente)
        {
            cliente.DataCriacao = DateTime.Now;
            context.Clientes.Add(cliente);
            context.SaveChanges();
            return cliente.Id;
        }

        public Cliente ObterPeloId(int id)
        {
            return context.Clientes.FirstOrDefault(x => x.Id == id);
        }

        public List<Cliente> ObterTodos(string busca)
        {
            return context.Clientes.Where(x => x.RegistroAtivo && x.Cidade.Nome.Contains(busca) || x.Nome.Contains(busca) || x.Cpf.Contains(busca)).OrderBy(x => x.Nome).ToList();
        }
    }
}
