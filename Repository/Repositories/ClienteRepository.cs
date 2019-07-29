using Model;
using Repository.DataBase;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            SqlCommand comando = SistemaContext.AbrirConexao();
            comando.CommandText = @"UPDATE clientes SET
nome = @NOME,
cpf = @CPF,
data_nascimento = @DATA_NASCIMENTO,
numero = @NUMERO,
complemento = @COMPLEMENTO,
logradouro = @LOGRADOURO,
cep = @CEP,
data_criacao = @DATA_CRIACAO,
registro_ativo = @REGISTRO_ATIVO,
id_cidade = @ID_CIDADE
WHERE id = @ID";
            comando.Parameters.AddWithValue("@NOME", cliente.Nome);
            comando.Parameters.AddWithValue("@CPF", cliente.Cpf);
            comando.Parameters.AddWithValue("@DATA_NASCIMENTO", cliente.DataNascimento);
            comando.Parameters.AddWithValue("@NUMERO", cliente.Numero);
            comando.Parameters.AddWithValue("@COMPLEMENTO", cliente.Complemento);
            comando.Parameters.AddWithValue("@LOGRADOURO", cliente.Logradouro);
            comando.Parameters.AddWithValue("@CEP", cliente.Cep);
            comando.Parameters.AddWithValue("@DATA_CRIACAO", cliente.DataCriacao = DateTime.Now);
            comando.Parameters.AddWithValue("@REGISTRO_ATIVO", cliente.RegistroAtivo = true);
            comando.Parameters.AddWithValue("@ID_CIDADE", cliente.IdCidade);
            comando.Parameters.AddWithValue("@ID", cliente.Id);

            int quantidade = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidade == 1;
        }

        public bool Apagar(int id)
        {
            SqlCommand comando = SistemaContext.AbrirConexao();
            comando.CommandText = "UPDATE clientes SET registro_ativo = 0 WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);

            int quantidade = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidade == 1;
        }

        public int Inserir(Cliente cliente)
        {
            SqlCommand comando = SistemaContext.AbrirConexao();
            comando.CommandText = @"INSERT INTO clientes 
(id_cidade, nome, cpf, data_nascimento, numero, complemento, logradouro, cep, data_criacao, registro_ativo)
OUTPUT INSERTED.ID VALUES 
(@ID_CIDADE, @NOME, @CPF, @DATA_NASCIMENTO, @NUMERO, @COMPLEMENTO, @LOGRADOURO, @CEP, @DATA_CRIACAO, @REGISTRO_ATIVO)";
            comando.Parameters.AddWithValue("@ID_CIDADE", cliente.IdCidade);
            comando.Parameters.AddWithValue("@NOME", cliente.Nome);
            comando.Parameters.AddWithValue("@CPF", cliente.Cpf);
            comando.Parameters.AddWithValue("@DATA_NASCIMENTO", cliente.DataNascimento);
            comando.Parameters.AddWithValue("@NUMERO", cliente.Numero);
            comando.Parameters.AddWithValue("@COMPLEMENTO", cliente.Complemento);
            comando.Parameters.AddWithValue("@LOGRADOURO", cliente.Logradouro);
            comando.Parameters.AddWithValue("@CEP", cliente.Cep);
            comando.Parameters.AddWithValue("@DATA_CRIACAO", cliente.DataCriacao = DateTime.Now);
            comando.Parameters.AddWithValue("@REGISTRO_ATIVO", cliente.RegistroAtivo = true);

            int id = Convert.ToInt32(comando.ExecuteScalar());
            comando.Connection.Close();
            return id;
        }

        public Cliente ObterPeloId(int id)
        {
            return context.Clientes.FirstOrDefault(x => x.Id == id);
        }

        public List<Cliente> ObterTodos(string busca)
        {
            return context.Clientes.Where(x => x.RegistroAtivo && (string.IsNullOrEmpty(busca) ? true : (x.Cidade.Nome.Contains(busca) || x.Nome.Contains(busca) || x.Cpf.Contains(busca)))).OrderBy(x => x.Nome).ToList();
        }
    }
}
