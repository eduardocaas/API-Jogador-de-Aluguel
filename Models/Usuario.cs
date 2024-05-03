using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace JogadorAPI.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        [Column("ID_USUARIO")]
        public int? Id { get; set; }

        [Column("EMAIL")]
        [EmailAddress(ErrorMessage = "Informe um email válido")]
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

        [Column("CIDADE")]
        [Required(ErrorMessage = "Cidade é obrigatória")]
        [StringLength(80, ErrorMessage = "A cidade deve ter até 80 caracteres")]
        public string Cidade { get; set; }

        [Column("BAIRRO")]
        [Required(ErrorMessage = "Bairro é obrigatório")]
        [StringLength(80, ErrorMessage = "O bairro deve ter até 80 caracteres")]
        public string Bairro { get; set; }

        [Column("NIVEL")]
        public short? Nivel { get; set; }

        [Column("DATA_CRIACAO")]
        public DateTime? DataCriacao { get; set; }


    }
}
