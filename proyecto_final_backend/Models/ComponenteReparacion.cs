using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_final_backend.Models
{
    [Table("componentes_reparaciones")]
    public class ComponenteReparacion
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("precio")]
        public decimal Precio { get; set; }

        [Column("cantidad")]
        public byte Cantidad { get; set; }

        [Column("id_producto")]
        public int IdProducto { get; set; }

        [Column("id_reparacion")]
        public int IdReparacion { get; set; }

        public Producto Producto { get; set; } = null!;
        public Reparacion Reparacion { get; set; } = null!;
    }
}
