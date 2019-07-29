using Model;
using Repository.DataBase;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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
            SqlCommand comando = SistemaContext.AbrirConexao();
            comando.CommandText = @"UPDATE projetos SET
id_cliente = @ID_CLIENTE,
nome = @NOME,
data_criacao_projeto = @DATA_CRIACAO_PROJETO,
data_finalizacao = @DATA_FINALIZACAO,
data_criacao = @DATA_CRIACAO,
registro_ativo = @REGISTRO_ATIVO
WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID_CLIENTE",projeto.IdCliente);
            comando.Parameters.AddWithValue("@NOME", projeto.Nome);
            comando.Parameters.AddWithValue("@DATA_CRIACAO_PROJETO", projeto.DataCriacaoProjeto);
            comando.Parameters.AddWithValue("@DATA_FINALIZACAO", projeto.DataFinalizacao);
            comando.Parameters.AddWithValue("@DATA_CRIACAO", projeto.DataCriacao = DateTime.Now);
            comando.Parameters.AddWithValue("@REGISTRO_ATIVO", projeto.RegistroAtivo = true);
            comando.Parameters.AddWithValue("@ID", projeto.Id);

            int quantidade = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidade == -1;
        }

        public bool Apagar(int id)
        {
            SqlCommand comando = SistemaContext.AbrirConexao();
            comando.CommandText = "UPDATE projetos SET registro_ativo = 0 WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);

            int quantidade = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidade == 1;
        }

        public int Inserir(Projeto projeto)
        {
            SqlCommand comando = SistemaContext.AbrirConexao();
            comando.CommandText = @"INSERT INTO projetos
(id_cliente, nome, data_criacao_projeto, data_finalizacao, data_criacao, registro_ativo)
OUTPUT INSERTED.ID
VALUES (@ID_CLIENTE, @NOME, @DATA_CRIACAO_PROJETO, @DATA_FINALIZACAO, @DATA_CRIACAO, @REGISTRO_ATIVO)";

            comando.Parameters.AddWithValue("@ID_CLIENTE", projeto.IdCliente);
            comando.Parameters.AddWithValue("@NOME", projeto.Nome);
            comando.Parameters.AddWithValue("@DATA_CRIACAO_PROJETO", projeto.DataCriacaoProjeto);
            comando.Parameters.AddWithValue("@DATA_FINALIZACAO", projeto.DataFinalizacao);
            comando.Parameters.AddWithValue("@DATA_CRIACAO", projeto.DataCriacao = DateTime.Now);
            comando.Parameters.AddWithValue("@REGISTRO_ATIVO", projeto.RegistroAtivo = true);

            int id = Convert.ToInt32(comando.ExecuteScalar());
            comando.Connection.Close();
            return id;

        }

        public Projeto ObterPeloId(int id)
        {
            return context.Projetos.FirstOrDefault(x => x.Id == id);
        }

        public List<Projeto> ObterTodos(string busca)
        {
            return context.Projetos.Where(x => x.RegistroAtivo && (string.IsNullOrEmpty(busca) ? true : (x.Nome.Contains(busca) || x.Cliente.Nome.Contains(busca)))).OrderBy(x => x.Nome).ToList();
        }
    }
}
