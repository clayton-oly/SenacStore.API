using System.ComponentModel.DataAnnotations;

namespace SenacStore.API.DTOs
{
    public class ProdutoDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Imagem { get; set; }
        [Range(1,5, ErrorMessage = "A nota do produto deve ser entre 1 e 5")]
        public int Nota { get; set; }
        public bool EhLancamento { get; set; }
        public decimal Preco { get; set; }
        public int CategoriaId { get; set; }
        public string Categoria { get; set; }
    }
}
