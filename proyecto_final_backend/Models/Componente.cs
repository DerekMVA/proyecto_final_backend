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

        [Column("id_producto_principal")]
        public int IdProductoPrincipal { get; set; }

        [Column("id_producto_secundario")]
        public int IdProductoSecundario { get; set; }

        public Producto ProductoPrincipal { get; set; } = null!;
        public Producto ProductoSecundario { get; set; } = null!;
    }
}
