using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace OOLanches.Core.Entities
{
    public class Produto
    {
        public int Id { get; set; }
        [StringLength(100)]
        [Required]
        public string? Nome { get; set; }
        [StringLength(200)]
        [Required]
        public string? Detalhe { get; set; }
        [StringLength(200)]
        [Required]
        public string? UrlImagem { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }
        public bool Popular { get; set; }
        public bool MaisVendido { get; set; }
        public int EmEstoque { get; set; }
        public bool Disponivel { get; set; }
        public int CategoriaId { get; set; }

        // Instrui o serializador JSON a ignorar essa propriedade
        // ao serializar/deserializar objetos dessa classe para/de JSON.
        // Assim a propriedade não será incluída no JSON quando o objeto
        // for serializado (convertido em JSON) para ser enviado em uma
        // resposta da API.
        // E também não será considerada durante a deserialização
        // (conversão de JSON para objeto) quando a API receber um JSON
        // como parte de uma solicitação.
        [JsonIgnore]
        public ICollection<DetalhePedido>? DetalhesPedido { get; set; }
        [JsonIgnore]
        public ICollection<ItemCarrinhoCompra>? ItensCarrinhoCompras { get; set; }
    }
}
