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
        public int? IdUsuario { get; set; }

        [Column("JOGADOR_ID")]
        public int IdJogador { get; set; }

        [Column("CIDADE")]
        [Required(ErrorMessage = "Cidade é obrigatória")]
        [StringLength(80, ErrorMessage = "A cidade deve ter até 80 caracteres")]
        public string Cidade { get; set; }

        [Column("BAIRRO")]
        [Required(ErrorMessage = "Bairro é obrigatório")]
        [StringLength(80, ErrorMessage = "O bairro deve ter até 80 caracteres")]
        public string Bairro { get; set; }

        [Column("HORARIO")]
        [Required(ErrorMessage = "Horário é obrigatório")]
        public DateTime? Horario { get; set; }

        [Column("DURACAO_MINUTOS")]
        [Required(ErrorMessage = "Duração é obrigatória")]
        [Range(30, 240, ErrorMessage = "A duração deve ser entre 30 e 240 minutos")]
        public ushort? DuracaoMinutos { get; set; }

        [Column("DESCRICAO")]
        public string Descricao { get; set; }

        [Column("STATUS")]
        public byte Status { get; set; }

        [Column("CUSTO")]
        public ushort Custo { get; set; }

        [Column("POSICAO")]
        [Required(ErrorMessage = "A posição é obrigatória")]
        [Range(1, 3, ErrorMessage = "Escolha uma posição válida: 1 - Goleiro, 2 - Defesa, 3 - Ataque")]
        public byte? Posicao { get; set; }

        [Column("DATA_CRIACAO")]
        public DateTime DataCriacao { get; set; }
    }
}
