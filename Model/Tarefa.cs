using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//Desenvolvido por Nathan Micael
namespace Model
{
    [Table("tarefas")]
    public class Tarefa : Base
    {
        [ForeignKey("IdUsuarioResponsavel")]
        public virtual Usuario Usuario { get; set; }

        [Column("id_usuario_responsavel")]
        public int IdUsuarioResponsavel { get; set; }

        [ForeignKey("IdProjeto")]
        public virtual Projeto Projeto { get; set; }

        [Column("id_projeto")]
        public int IdProjeto { get; set; }

        [ForeignKey("IdCategoria")]
        public virtual Categoria Categoria { get; set; }

        [Column("id_categoria")]
        public int IdCategoria { get; set; }

        [Column("titulo")]
        public string Titulo { get; set; }

        [Column("descricao")]
        public string Descricao { get; set; }

        [Column("duracao")]
        public DateTime Duracao { get; set; }
    }
}
