using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OOLanches.Core.Entities
{
    public class Categoria
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? Nome { get; set; }
        [StringLength(200)]
        [Required]
        public string? UrlImagem { get; set; }
        //public string? CaminhoImagem { get; set; }

        [JsonIgnore]
        public ICollection<Produto>? Produtos { get; set; }
    }
}
