namespace SenacStore.API.DTOs
{
    public class ProdutoDTO
    {
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
