using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace proyecto_final_backend.Models
{
    [Table("usuarios")]
    public class Usuario
    {
        [Key]
        [Column("id")]
        public int Id { get; set; }

        [Column("nombre_completo")]
        [MaxLength(50)]
        public required string NombreCompleto { get; set; }

        [Column("nombre_usuario")]
        [MaxLength(15)]
        public required string NombreUsuario { get; set; }

        [Column("contrasena")]
        [MaxLength(255)]
        public required string Contrasena { get; set; }

        [Column("salario")]
        public decimal Salario { get; set; }

        [Column("deleted")]
        public bool Deleted { get; set; } = false;

        [Column("id_rol")]
        public int IdRol { get; set; }
        public Rol Rol { get; set; } = null!;

        public ICollection<Garantia> Garantias { get; set; } = new List<Garantia>();
        public ICollection<Reparacion> Reparaciones { get; set; } = new List<Reparacion>();
        public ICollection<OrdenEnsamble> OrdenesEnsamble { get; set; } = new List<OrdenEnsamble>();
        public ICollection<Venta> Ventas { get; set; } = new List<Venta>();
    }
}
