using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JogadorAPI.Models
{
    [Table("AVALIACAO")]
    public class Avaliacao
    {
        [Column("ID_AVALIACAO")]
        public int Id { get; set; }

        [Column("USUARIO_ID")]
        [Required(ErrorMessage = "ID de Usuário é obrigatório")]
        public int IdUsuario { get; set; }

        [Column("JOGADOR_ID")]
        [Required(ErrorMessage = "ID de Jogador é obrigatório")]
        public int IdJogador { get; set; }

        [Column("NIVEL_AVALIACAO")]
        [Required(ErrorMessage = "Avaliação é obrigatória")]
        public byte NivelAvaliacao { get; set; }

        [Column("DATA_CRIACAO")]
        public DateTime DataCriacao { get; set; }

        [Column("CONDICAO")]
        public byte Condicao { get; set; }
    }
}
