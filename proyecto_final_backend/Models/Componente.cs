using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_final_backend.Models
{
    [Table("componentes")]
    public class Componente
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [ForeignKey("Producto")]
        [Column("id_producto_principal")]
        public required int IdProductoPrincipal { get; set; }
        [ForeignKey("Producto")]
        [Column("id_producto_secundario")]
        public required int IdProductoSecundario { get; set; }
    }
}
