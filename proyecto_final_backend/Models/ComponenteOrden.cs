using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_final_backend.Models
{
    [Table("componentes_ordenes")]
    public class ComponenteOrden
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
        public Producto Producto { get; set; } = null!;

        [Column("id_orden_ensamble")]
        public int IdOrdenEnsamble { get; set; }
        public OrdenEnsamble OrdenEnsamble { get; set; } = null!;
    }
}
