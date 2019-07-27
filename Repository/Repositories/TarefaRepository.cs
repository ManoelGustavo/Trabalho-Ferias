using Model;
using Repository.DataBase;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Desenvolvido por Nathan Micael
namespace Repository.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        public SistemaContext context;

        public TarefaRepository()
        {
            context = new SistemaContext();
        }
        /*
         * LINQ
        Tarefa tarefaOriginal = (from tarefas in context.Tarefas
                                 where tarefas.Id == tarefa.Id
                                 select tarefas).FirstOrDefault();
         */
        // Lambda Expression.
        public bool Alterar(Tarefa tarefa)
        {
            SqlCommand comando = SistemaContext.AbrirConexao();
            comando.CommandText = @"UPDATE tarefas SET
id_usuario_responsavel = @ID_USUARIO_RESPONSAVEL,
id_projeto = @ID_PROJETO,
id_categoria = @ID_CATEGORIA,
titulo = @TITULO,
descricao = @DESCRICAO,
duracao = @DURACAO,
data_criacao = @DATA_CRIACAO,
registro_ativo = @REGISTRO_ATIVO
WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", tarefa.Id);
            comando.Parameters.AddWithValue("@ID_USUARIO_RESPONSAVEL", tarefa.IdUsuarioResponsavel);
            comando.Parameters.AddWithValue("@ID_PROJETO", tarefa.IdProjeto);
            comando.Parameters.AddWithValue("@ID_CATEGORIA", tarefa.IdCategoria);
            comando.Parameters.AddWithValue("@TITULO", tarefa.Titulo);
            comando.Parameters.AddWithValue("@DESCRICAO", tarefa.Descricao);
            comando.Parameters.AddWithValue("@DURACAO", tarefa.Duracao);
            comando.Parameters.AddWithValue("@DATA_CRIACAO", tarefa.DataCriacao);
            comando.Parameters.AddWithValue("@REGISTRO_ATIVO", tarefa.RegistroAtivo = true);

            int quantidade = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidade == 1;
        }

        public bool Apagar(int id)
        {
            SqlCommand comando = SistemaContext.AbrirConexao();
            comando.CommandText = "UPDATE tarefas SET registro_ativo = 0 WHERE id = @ID";
            comando.Parameters.AddWithValue("@ID", id);

            int quantidade = comando.ExecuteNonQuery();
            comando.Connection.Close();
            return quantidade == 1;
        }

        public int Inserir(Tarefa tarefa)
        {
            SqlCommand comando = SistemaContext.AbrirConexao();
            comando.CommandText = @"INSERT INTO tarefas 
(id_usuario_responsavel, id_projeto, id_categoria, titulo, descricao, duracao, data_criacao, registro_ativo)
OUTPUT INSERTED.ID VALUES 
(@ID_USUARIO_RESPONSAVEL, @ID_PROJETO, @ID_CATEGORIA, @TITULO, @DESCRICAO, @DURACAO, @DATA_CRIACAO, @REGISTRO_ATIVO)";
            comando.Parameters.AddWithValue("@ID_USUARIO_RESPONSAVEL", tarefa.IdUsuarioResponsavel);
            comando.Parameters.AddWithValue("@ID_PROJETO", tarefa.IdProjeto);
            comando.Parameters.AddWithValue("@ID_CATEGORIA", tarefa.IdCategoria);
            comando.Parameters.AddWithValue("@TITULO", tarefa.Titulo);
            comando.Parameters.AddWithValue("@DESCRICAO", tarefa.Descricao);
            comando.Parameters.AddWithValue("@DURACAO", tarefa.Duracao);
            comando.Parameters.AddWithValue("@DATA_CRIACAO", tarefa.DataCriacao);
            comando.Parameters.AddWithValue("@REGISTRO_ATIVO", tarefa.RegistroAtivo = true);

            int id = Convert.ToInt32(comando.ExecuteScalar());
            comando.Connection.Close();
            return id;
        }

        public Tarefa ObterPeloId(int id)
        {
            return context.Tarefas.FirstOrDefault(x => x.Id == id);
        }

        public List<Tarefa> ObterTodos(string busca)
        {
            return context.Tarefas.Where(x => x.RegistroAtivo && (string.IsNullOrEmpty(busca) ? true : (x.Usuario.Nome.Contains(busca)))).OrderBy(x => x.Usuario.Nome).ToList();
        }
    }
}
