using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace proyecto_final_backend.Models
{
    [Table("carrito_compras")]
    public class Carrito
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("monto_total")]
        public decimal MontoTotal { get; set; }

        [Column("id_cliente")]
        public int IdCliente { get; set; }
        public Cliente Cliente { get; set; } = null!;

        public ICollection<ProductoCarrito> ProductosCarrito { get; set; } = new List<ProductoCarrito>();
    }
}
