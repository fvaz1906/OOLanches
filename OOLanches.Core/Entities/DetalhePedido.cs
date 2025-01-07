using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOLanches.Core.Entities
{
    public class DetalhePedido
    {
        public int Id { get; set; }

        //public string? Nome { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }

        public int Quantidade { get; set; }

        [Column(TypeName = "decimal(12,2)")]
        public decimal ValorTotal { get; set; }

        public int PedidoId { get; set; }
        public Pedido? Pedido { get; set; }
        public int ProdutoId { get; set; }
        public Produto? Produto { get; set; }
    }
}
