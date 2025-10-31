using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_final_backend.Models
{
    [Table("componentes_orden")]
    public class Componentes_Orden
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [ForeignKey("id_orden_ensamble")]
        public required int IdOrdenEnsamble { get; set; }
        public OrdenEnsamble? OrdenEnsamble { get; set; }

        [ForeignKey("id_producto")]
        public required int IdProducto { get; set; }
        public Producto? Producto { get; set; }

        [Required]
        [Column("cantidad")]
        public Byte Cantidad { get; set; }

        [Required]
        [Column("precio")]
        public decimal Precio { get; set; }
    }
}
