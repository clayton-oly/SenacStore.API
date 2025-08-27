using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SenacStore.API.Models
{
    [Table("Cadastro")]
    public class Cadastro
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [MaxLength(200)]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [MaxLength(14)]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "O Email é obrigatório.")]
        [MaxLength(80)]
        public string Email { get; set; }
        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [MaxLength(15)]
        public string Telefone { get; set; }
        [Required(ErrorMessage = "O endereço é obrigatório.")]
        [MaxLength(100)]
        public string Endereco { get; set; }
        [Required(ErrorMessage = "O número de endereço é obrigatório.")]
        [MaxLength(10)]
        public string Nro { get; set; }
        [Required(ErrorMessage = "O bairro do endereço é obrigatório.")]
        [MaxLength(50)]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "O cidade é obrigatório.")]
        [MaxLength(50)]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "A estado nome é obrigatório.")]
        [MaxLength(2)]
        public string Estado { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
