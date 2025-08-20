using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SenacStore.API.Models
{
    [Table("Produto")]
    public class Produto
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        public int Nota { get; set; }
        public bool EhLancamento { get; set; }
        public decimal Preco { get; set; }
        public string Categoria { get; set; }
    }
}
