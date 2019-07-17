using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Desenvolvido pro Nathan Micael
namespace Model
{
    [Table("tarefas")]
    public class Tarefa : Base
    {
        [Column("id_usuario_responsavel")]
        public int IdUsuarioResponsavel { get; set; }
        public Usuario Usuario { get; set; }

        [Column("id_projeto")]
        public int IdProjeto { get; set; }
        public Projeto Projeto { get; set; }

        [Column("id_categoria")]
        public int IdCategoria { get; set; }
        public Categoria Categoria { get; set; }

        [Column("titulo")]
        public string Titulo { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("duracao")]
        public DateTime Duracao { get; set; }
    }
}
