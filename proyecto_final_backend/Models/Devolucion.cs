using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace proyecto_final_backend.Models
{
    [Table("devoluciones")]
    public class Devolucion
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("precio_devolucion")]
        public decimal PrecioDevolucion { get; set; }

        [Column("deleted")]
        public bool Deleted { get; set; } = false;

        [Column("id_venta")]
        public int IdVenta { get; set; }
        public Venta Venta { get; set; } = null!;

        public ICollection<DevolucionProducto> DevolucionesProducto { get; set; } = new List<DevolucionProducto>();
    }
}
