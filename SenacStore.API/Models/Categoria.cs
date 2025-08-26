using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SenacStore.API.Models
{
    [Table("Categoria")]
    public class Categoria
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
    }
}
