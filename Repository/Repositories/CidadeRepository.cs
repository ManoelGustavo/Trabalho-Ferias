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
            SqlCommand comando = SistemaContext.AbrirConexao();
            comando.CommandText = @"UPDATE cidades SET
nome = @NOME,
numero_habitantes = @NUMERO_HABITANTES,
id_estado = @ID_ESTADO,
data_criacao = @DATA_CRIACAO,
registro_ativo = @REGISTRO_ATIVO
WHERE id = @ID";
            comando.Parameters.AddWithValue("@NOME", cidade.Nome);
            comando.Parameters.AddWithValue("@NUMERO_HABITANTES", cidade.NumeroHabitantes);
            comando.Parameters.AddWithValue("@ID_ESTADO", cidade.IdEstado);
            comando.Parameters.AddWithValue("@DATA_CRIACAO", cidade.DataCriacao = DateTime.Now);
            comando.Parameters.AddWithValue("@REGISTRO_ATIVO", cidade.RegistroAtivo = true);
            comando.Parameters.AddWithValue("@ID", cidade.Id);

            int quantidade = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidade == 1;
        }

        public bool Apagar(int id)
        {
            SqlCommand comando = SistemaContext.AbrirConexao();
            comando.CommandText = "UPDATE cidades SET registro_ativo = 0 WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);

            int quantidade = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidade == 1;
        }

        public int Inserir(Cidade cidade)
        {
            SqlCommand comando = SistemaContext.AbrirConexao();
            comando.CommandText = @"INSERT INTO cidades
(nome, numero_habitantes, id_estado, data_criacao, registro_ativo)
OUTPUT INSERTED.ID
VALUES (@NOME, @NUMERO_HABITANTES, @ID_ESTADO, @DATA_CRIACAO, @REGISTRO_ATIVO)";
            comando.Parameters.AddWithValue("@NOME", cidade.Nome);
            comando.Parameters.AddWithValue("@NUMERO_HABITANTES", cidade.NumeroHabitantes);
            comando.Parameters.AddWithValue("@ID_ESTADO", cidade.IdEstado);
            comando.Parameters.AddWithValue("@DATA_CRIACAO", cidade.DataCriacao = DateTime.Now);
            comando.Parameters.AddWithValue("@REGISTRO_ATIVO", cidade.RegistroAtivo = true);

            int id = Convert.ToInt32(comando.ExecuteScalar());
            comando.Connection.Close();
            return id;
        }

        public Cidade ObterPeloId(int id)
        {
            SqlCommand comando = SistemaContext.AbrirConexao();
            comando.CommandText = "SELECT * FROM cidades WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);

            DataTable table = new DataTable();
            table.Load(comando.ExecuteReader());
            comando.Connection.Close();

            if (table.Rows.Count == 0)
            {
                return null;
            }

            DataRow row = table.Rows[0];
            Cidade cidade = new Cidade();
            cidade.Nome = row["nome"].ToString();
            cidade.NumeroHabitantes = row["numero_habitantes"].ToString();
            cidade.IdEstado = Convert.ToInt32(row["id_estado"]);
            cidade.Id = Convert.ToInt32(row["id"]);
            return cidade;
        }

        public List<Cidade> ObterTodos(string busca)
        {
            return context.Cidades.Where(x => x.RegistroAtivo && (string.IsNullOrEmpty(busca) ? true : (x.Nome.Contains(busca)))).OrderBy(x => x.Nome).ToList();
        }
    }
}
