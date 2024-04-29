using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JogadorAPI.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Column("ID_USUARIO")]
        public int Id { get; set; }

        [Column("EMAIL")]
        [EmailAddress]
        [Required(ErrorMessage = "Email é obrigatório")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Email deve ter entre 5 e 100 caracteres")]
        public string Email { get; set; }

        [Column("TELEFONE")]
        [Required(ErrorMessage = "Telefone é obrigatório")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Telefone deve ter 11 caracteres")]
        public string Telefone { get; set; }

        [Column("CPF")]
        [Required(ErrorMessage = "CPF é obrigatório")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "CPF deve ter 11 caracteres")]
        public string CPF { get; set; }

        [Column("NOME")]
        [Required(ErrorMessage = "Nome é obrigatório")]
        [StringLength(80, MinimumLength = 2, ErrorMessage = "O nome deve ter entre 2 e 80 caracteres")]
        public string Nome { get; set; }

        [Column("SENHA")]
        [Required(ErrorMessage = "Senha é obrigatória")]
        //Validar tamanho no service
        public string Senha { get; set; }

        [Column("ENDERECO")]
        [Required(ErrorMessage = "Endereço é obrigatório")]
        [StringLength(100, ErrorMessage = "Endereço deve ter no máximo 100 caracteres")]
        public string Endereco { get; set; }

        [Column("NIVEL")]
        public short Nivel { get; set; }

        [Column("DATA_CRIACAO")]
        public DateTime DataCriacao { get; set; }


    }
}
