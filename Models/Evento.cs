using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JogadorAPI.Models
{
    [Table("Evento")]
    public class Evento
    {
        [Column("ID_EVENTO")]
        public int Id { get; set; }

        [Column("USUARIO_ID")]
        [Required(ErrorMessage = "ID de Usuário é obrigatório")]
        public int IdUsuario { get; set; }

        [Column("JOGADOR_ID")]
        public int IdJogador { get; set; }

        [Column("ENDERECO")]
        [Required(ErrorMessage = "Endereço é obrigatório")]
        [StringLength(100, ErrorMessage = "O endereço deve ter no máximo 100 caracteres")]
        public string Endereco { get; set; }

        [Column("HORARIO")]
        [Required(ErrorMessage = "Horário é obrigatório")]
        public DateTime Horario { get; set; }

        [Column("DURACAO_MINUTOS")]
        [Required(ErrorMessage = "Duração é obrigatória")]
        [Range(30, 240, ErrorMessage = "A duração deve ser entre 30 e 240 minutos")]
        public ushort DuracaoMinutos { get; set; }

        [Column("DESCRICAO")]
        [Required(ErrorMessage = "A descrição é obrigatória")]
        public string Descricao { get; set; }

        [Column("CUSTO")]
        public ushort Custo { get; set; }

        [Column("POSICAO")]
        [Required(ErrorMessage = "A posição é obrigatória")]
        [Range(1, 3, ErrorMessage = "Escolha uma posição válida: 1 - Goleiro, 2 - Defesa, 3 - Ataque")]
        public byte Posicao { get; set; }

        [Column("DATA_CRIACAO")]
        public DateTime DataCriacao { get; set; }
    }
}
