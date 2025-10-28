using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyecto_final_backend.Models
{
    [Table ("Productos")]
    public class Producto
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }
        [Required]
        [Column("nombre")]
        public required string Nombre { get; set; }
        [Required]
        [Column("codigo")]
        public required string Codigo { get; set; }
        [Required]
        [Column("precio")]
        public required decimal Precio { get; set; }
        [Required]
        [Column("stock")]
        public required int Stock { get; set; }
        [Required]
        [Column("stock_minimo")]
        public required int StockMinimo { get; set; }
        [Required]
        [Column("nuevo")]
        public required bool Nuevo { get; set; }
        [Required]

    }
}
