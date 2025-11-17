using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace proyecto_final_backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "caracteristicas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_caracteristicas", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_completo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    correo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "productos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    codigo = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    stock = table.Column<byte>(type: "tinyint", nullable: false),
                    stock_minimo = table.Column<byte>(type: "tinyint", nullable: false),
                    nuevo = table.Column<bool>(type: "bit", nullable: false),
                    tipo = table.Column<byte>(type: "tinyint", nullable: false),
                    imagen = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "proveedores",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    nombre_contacto = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    correo = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    telefono = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_proveedores", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "carrito_compras",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    monto_total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    id_cliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_carrito_compras", x => x.id);
                    table.ForeignKey(
                        name: "FK_carrito_compras_clientes_id_cliente",
                        column: x => x.id_cliente,
                        principalTable: "clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "caracteristicas_productos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_caracteristica = table.Column<int>(type: "int", nullable: false),
                    id_producto = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_caracteristicas_productos", x => x.id);
                    table.ForeignKey(
                        name: "FK_caracteristicas_productos_caracteristicas_id_caracteristica",
                        column: x => x.id_caracteristica,
                        principalTable: "caracteristicas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_caracteristicas_productos_productos_id_producto",
                        column: x => x.id_producto,
                        principalTable: "productos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "componentes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_producto_principal = table.Column<int>(type: "int", nullable: false),
                    id_producto_secundario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_componentes", x => x.id);
                    table.ForeignKey(
                        name: "FK_componentes_productos_id_producto_principal",
                        column: x => x.id_producto_principal,
                        principalTable: "productos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_componentes_productos_id_producto_secundario",
                        column: x => x.id_producto_secundario,
                        principalTable: "productos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "compras",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    monto_total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false),
                    id_proveedor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compras", x => x.id);
                    table.ForeignKey(
                        name: "FK_compras_proveedores_id_proveedor",
                        column: x => x.id_proveedor,
                        principalTable: "proveedores",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre_completo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    nombre_usuario = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    contrasena = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    salario = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false),
                    id_rol = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.id);
                    table.ForeignKey(
                        name: "FK_usuarios_roles_id_rol",
                        column: x => x.id_rol,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "productos_carrito",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    cantidad = table.Column<byte>(type: "tinyint", nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false),
                    id_producto = table.Column<int>(type: "int", nullable: false),
                    id_carrito = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_productos_carrito", x => x.id);
                    table.ForeignKey(
                        name: "FK_productos_carrito_carrito_compras_id_carrito",
                        column: x => x.id_carrito,
                        principalTable: "carrito_compras",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_productos_carrito_productos_id_producto",
                        column: x => x.id_producto,
                        principalTable: "productos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "detalles_compras",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    cantidad = table.Column<byte>(type: "tinyint", nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false),
                    id_producto = table.Column<int>(type: "int", nullable: false),
                    id_compra = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalles_compras", x => x.id);
                    table.ForeignKey(
                        name: "FK_detalles_compras_compras_id_compra",
                        column: x => x.id_compra,
                        principalTable: "compras",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_detalles_compras_productos_id_producto",
                        column: x => x.id_producto,
                        principalTable: "productos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ventas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    monto_total = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false),
                    id_cliente = table.Column<int>(type: "int", nullable: false),
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ventas", x => x.id);
                    table.ForeignKey(
                        name: "FK_ventas_clientes_id_cliente",
                        column: x => x.id_cliente,
                        principalTable: "clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ventas_usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "detalles_ventas",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    cantidad = table.Column<byte>(type: "tinyint", nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false),
                    id_producto = table.Column<int>(type: "int", nullable: false),
                    id_venta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_detalles_ventas", x => x.id);
                    table.ForeignKey(
                        name: "FK_detalles_ventas_productos_id_producto",
                        column: x => x.id_producto,
                        principalTable: "productos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_detalles_ventas_ventas_id_venta",
                        column: x => x.id_venta,
                        principalTable: "ventas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "devoluciones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    precio_devolucion = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false),
                    id_venta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_devoluciones", x => x.id);
                    table.ForeignKey(
                        name: "FK_devoluciones_ventas_id_venta",
                        column: x => x.id_venta,
                        principalTable: "ventas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "garantias",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fecha = table.Column<DateOnly>(type: "date", nullable: false),
                    estado = table.Column<byte>(type: "tinyint", nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false),
                    id_usuario = table.Column<int>(type: "int", nullable: false),
                    id_venta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_garantias", x => x.id);
                    table.ForeignKey(
                        name: "FK_garantias_usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_garantias_ventas_id_venta",
                        column: x => x.id_venta,
                        principalTable: "ventas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ordenes_ensambles",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    precio_ensamble = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    estado = table.Column<byte>(type: "tinyint", nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false),
                    id_usuario = table.Column<int>(type: "int", nullable: false),
                    id_venta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ordenes_ensambles", x => x.id);
                    table.ForeignKey(
                        name: "FK_ordenes_ensambles_usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ordenes_ensambles_ventas_id_venta",
                        column: x => x.id_venta,
                        principalTable: "ventas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "reparaciones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    deleted = table.Column<bool>(type: "bit", nullable: false),
                    id_usuario = table.Column<int>(type: "int", nullable: false),
                    id_venta = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_reparaciones", x => x.id);
                    table.ForeignKey(
                        name: "FK_reparaciones_usuarios_id_usuario",
                        column: x => x.id_usuario,
                        principalTable: "usuarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_reparaciones_ventas_id_venta",
                        column: x => x.id_venta,
                        principalTable: "ventas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "devoluciones_productos",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_producto = table.Column<int>(type: "int", nullable: false),
                    id_devolucion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_devoluciones_productos", x => x.id);
                    table.ForeignKey(
                        name: "FK_devoluciones_productos_devoluciones_id_devolucion",
                        column: x => x.id_devolucion,
                        principalTable: "devoluciones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_devoluciones_productos_productos_id_producto",
                        column: x => x.id_producto,
                        principalTable: "productos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "componentes_garantias",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cantidad = table.Column<byte>(type: "tinyint", nullable: false),
                    id_producto = table.Column<int>(type: "int", nullable: false),
                    id_garantia = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_componentes_garantias", x => x.id);
                    table.ForeignKey(
                        name: "FK_componentes_garantias_garantias_id_garantia",
                        column: x => x.id_garantia,
                        principalTable: "garantias",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_componentes_garantias_productos_id_producto",
                        column: x => x.id_producto,
                        principalTable: "productos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "componentes_ordenes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    cantidad = table.Column<byte>(type: "tinyint", nullable: false),
                    id_producto = table.Column<int>(type: "int", nullable: false),
                    id_orden_ensamble = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_componentes_ordenes", x => x.id);
                    table.ForeignKey(
                        name: "FK_componentes_ordenes_ordenes_ensambles_id_orden_ensamble",
                        column: x => x.id_orden_ensamble,
                        principalTable: "ordenes_ensambles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_componentes_ordenes_productos_id_producto",
                        column: x => x.id_producto,
                        principalTable: "productos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "componentes_reparaciones",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    cantidad = table.Column<byte>(type: "tinyint", nullable: false),
                    id_producto = table.Column<int>(type: "int", nullable: false),
                    id_reparacion = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_componentes_reparaciones", x => x.id);
                    table.ForeignKey(
                        name: "FK_componentes_reparaciones_productos_id_producto",
                        column: x => x.id_producto,
                        principalTable: "productos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_componentes_reparaciones_reparaciones_id_reparacion",
                        column: x => x.id_reparacion,
                        principalTable: "reparaciones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "caracteristicas",
                columns: new[] { "id", "deleted", "descripcion", "tipo" },
                values: new object[,]
                {
                    { 1, false, "Socket LGA1700", "Compatibilidad" },
                    { 2, false, "16GB DDR4", "Capacidad" },
                    { 3, false, "SSD 1TB NVMe", "Almacenamiento" },
                    { 4, false, "Fuente 650W", "Potencia" }
                });

            migrationBuilder.InsertData(
                table: "clientes",
                columns: new[] { "id", "correo", "deleted", "nombre_completo", "telefono" },
                values: new object[,]
                {
                    { 1, "cliente@demo.com", false, "Cliente Demo", "555-3000" },
                    { 2, "juan@correo.com", false, "Juan Perez", "555-4000" }
                });

            migrationBuilder.InsertData(
                table: "productos",
                columns: new[] { "id", "codigo", "deleted", "imagen", "nombre", "nuevo", "precio", "stock", "stock_minimo", "tipo" },
                values: new object[,]
                {
                    { 1, "PROD-001", false, "mb-a1.png", "Tarjeta Madre A1", true, 1500.00m, (byte)50, (byte)10, (byte)1 },
                    { 2, "PROD-002", false, "cpu-x.png", "Procesador X", true, 2200.00m, (byte)35, (byte)8, (byte)1 },
                    { 3, "PROD-003", false, "ram-16gb.png", "Memoria 16GB", true, 600.00m, (byte)80, (byte)20, (byte)2 },
                    { 4, "PROD-004", false, "ssd-1tb.png", "SSD 1TB", true, 900.00m, (byte)60, (byte)15, (byte)2 },
                    { 5, "PROD-005", false, "psu-650w.png", "Fuente 650W", false, 500.00m, (byte)40, (byte)10, (byte)3 }
                });

            migrationBuilder.InsertData(
                table: "proveedores",
                columns: new[] { "id", "correo", "deleted", "nombre", "nombre_contacto", "telefono" },
                values: new object[,]
                {
                    { 1, "contacto@techparts.com", false, "Tech Parts", "Ana Lopez", "555-1000" },
                    { 2, "ventas@compudistrib.com", false, "CompuDistrib", "Luis Garcia", "555-2000" }
                });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "deleted", "descripcion", "nombre" },
                values: new object[,]
                {
                    { 1, false, "Acceso total al sistema", "Administrador" },
                    { 2, false, "Gestión de ventas", "Vendedor" }
                });

            migrationBuilder.InsertData(
                table: "caracteristicas_productos",
                columns: new[] { "id", "id_caracteristica", "id_producto" },
                values: new object[,]
                {
                    { 1, 1, 1 },
                    { 2, 2, 3 },
                    { 3, 3, 4 },
                    { 4, 4, 5 },
                    { 5, 1, 2 }
                });

            migrationBuilder.InsertData(
                table: "carrito_compras",
                columns: new[] { "id", "id_cliente", "monto_total" },
                values: new object[,]
                {
                    { 1, 1, 600.00m },
                    { 2, 2, 1500.00m }
                });

            migrationBuilder.InsertData(
                table: "componentes",
                columns: new[] { "id", "id_producto_principal", "id_producto_secundario" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 2, 1, 3 },
                    { 3, 2, 3 }
                });

            migrationBuilder.InsertData(
                table: "compras",
                columns: new[] { "id", "deleted", "fecha", "id_proveedor", "monto_total" },
                values: new object[,]
                {
                    { 1, false, new DateOnly(2025, 1, 5), 1, 14000.00m },
                    { 2, false, new DateOnly(2025, 2, 5), 2, 8500.00m }
                });

            migrationBuilder.InsertData(
                table: "usuarios",
                columns: new[] { "id", "contrasena", "deleted", "id_rol", "nombre_completo", "nombre_usuario", "salario" },
                values: new object[,]
                {
                    { 1, "admin123", false, 1, "Usuario Administrador", "admin", 0m },
                    { 2, "vendedor123", false, 2, "Usuario Vendedor", "vendedor", 0m }
                });

            migrationBuilder.InsertData(
                table: "detalles_compras",
                columns: new[] { "id", "cantidad", "deleted", "id_compra", "id_producto", "precio" },
                values: new object[,]
                {
                    { 1, (byte)10, false, 1, 1, 1400.00m },
                    { 2, (byte)10, false, 2, 4, 850.00m }
                });

            migrationBuilder.InsertData(
                table: "productos_carrito",
                columns: new[] { "id", "cantidad", "deleted", "id_carrito", "id_producto", "precio" },
                values: new object[,]
                {
                    { 1, (byte)1, false, 1, 3, 600.00m },
                    { 2, (byte)1, false, 2, 1, 1500.00m }
                });

            migrationBuilder.InsertData(
                table: "ventas",
                columns: new[] { "id", "deleted", "fecha", "id_cliente", "id_usuario", "monto_total" },
                values: new object[,]
                {
                    { 1, false, new DateOnly(2025, 1, 1), 1, 1, 2200.00m },
                    { 2, false, new DateOnly(2025, 2, 1), 2, 2, 1500.00m }
                });

            migrationBuilder.InsertData(
                table: "detalles_ventas",
                columns: new[] { "id", "cantidad", "deleted", "id_producto", "id_venta", "precio" },
                values: new object[,]
                {
                    { 1, (byte)1, false, 2, 1, 2200.00m },
                    { 2, (byte)1, false, 1, 2, 1500.00m }
                });

            migrationBuilder.InsertData(
                table: "devoluciones",
                columns: new[] { "id", "deleted", "id_venta", "precio_devolucion" },
                values: new object[,]
                {
                    { 1, false, 1, 500.00m },
                    { 2, false, 2, 1500.00m }
                });

            migrationBuilder.InsertData(
                table: "garantias",
                columns: new[] { "id", "deleted", "estado", "fecha", "id_usuario", "id_venta" },
                values: new object[,]
                {
                    { 1, false, (byte)1, new DateOnly(2025, 1, 15), 1, 1 },
                    { 2, false, (byte)1, new DateOnly(2025, 2, 15), 2, 2 }
                });

            migrationBuilder.InsertData(
                table: "ordenes_ensambles",
                columns: new[] { "id", "deleted", "estado", "id_usuario", "id_venta", "precio_ensamble" },
                values: new object[,]
                {
                    { 1, false, (byte)1, 1, 1, 300.00m },
                    { 2, false, (byte)1, 2, 2, 200.00m }
                });

            migrationBuilder.InsertData(
                table: "reparaciones",
                columns: new[] { "id", "deleted", "id_usuario", "id_venta", "precio" },
                values: new object[,]
                {
                    { 1, false, 1, 1, 300.00m },
                    { 2, false, 2, 2, 700.00m }
                });

            migrationBuilder.InsertData(
                table: "componentes_garantias",
                columns: new[] { "id", "cantidad", "id_garantia", "id_producto" },
                values: new object[,]
                {
                    { 1, (byte)1, 1, 4 },
                    { 2, (byte)1, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "componentes_ordenes",
                columns: new[] { "id", "cantidad", "id_orden_ensamble", "id_producto", "precio" },
                values: new object[,]
                {
                    { 1, (byte)1, 1, 1, 1500.00m },
                    { 2, (byte)1, 2, 3, 600.00m }
                });

            migrationBuilder.InsertData(
                table: "componentes_reparaciones",
                columns: new[] { "id", "cantidad", "id_producto", "id_reparacion", "precio" },
                values: new object[,]
                {
                    { 1, (byte)1, 5, 1, 500.00m },
                    { 2, (byte)1, 1, 2, 700.00m }
                });

            migrationBuilder.InsertData(
                table: "devoluciones_productos",
                columns: new[] { "id", "id_devolucion", "id_producto" },
                values: new object[,]
                {
                    { 1, 1, 5 },
                    { 2, 2, 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_caracteristicas_productos_id_caracteristica_id_producto",
                table: "caracteristicas_productos",
                columns: new[] { "id_caracteristica", "id_producto" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_caracteristicas_productos_id_producto",
                table: "caracteristicas_productos",
                column: "id_producto");

            migrationBuilder.CreateIndex(
                name: "IX_carrito_compras_id_cliente",
                table: "carrito_compras",
                column: "id_cliente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_clientes_correo",
                table: "clientes",
                column: "correo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_clientes_telefono",
                table: "clientes",
                column: "telefono",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_componentes_id_producto_principal_id_producto_secundario",
                table: "componentes",
                columns: new[] { "id_producto_principal", "id_producto_secundario" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_componentes_id_producto_secundario",
                table: "componentes",
                column: "id_producto_secundario");

            migrationBuilder.CreateIndex(
                name: "IX_componentes_garantias_id_garantia",
                table: "componentes_garantias",
                column: "id_garantia");

            migrationBuilder.CreateIndex(
                name: "IX_componentes_garantias_id_producto_id_garantia",
                table: "componentes_garantias",
                columns: new[] { "id_producto", "id_garantia" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_componentes_ordenes_id_orden_ensamble",
                table: "componentes_ordenes",
                column: "id_orden_ensamble");

            migrationBuilder.CreateIndex(
                name: "IX_componentes_ordenes_id_producto_id_orden_ensamble",
                table: "componentes_ordenes",
                columns: new[] { "id_producto", "id_orden_ensamble" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_componentes_reparaciones_id_producto_id_reparacion",
                table: "componentes_reparaciones",
                columns: new[] { "id_producto", "id_reparacion" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_componentes_reparaciones_id_reparacion",
                table: "componentes_reparaciones",
                column: "id_reparacion");

            migrationBuilder.CreateIndex(
                name: "IX_compras_id_proveedor",
                table: "compras",
                column: "id_proveedor",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_detalles_compras_id_compra",
                table: "detalles_compras",
                column: "id_compra",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_detalles_compras_id_producto",
                table: "detalles_compras",
                column: "id_producto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_detalles_ventas_id_producto",
                table: "detalles_ventas",
                column: "id_producto",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_detalles_ventas_id_venta",
                table: "detalles_ventas",
                column: "id_venta",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_devoluciones_id_venta",
                table: "devoluciones",
                column: "id_venta",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_devoluciones_productos_id_devolucion",
                table: "devoluciones_productos",
                column: "id_devolucion");

            migrationBuilder.CreateIndex(
                name: "IX_devoluciones_productos_id_producto_id_devolucion",
                table: "devoluciones_productos",
                columns: new[] { "id_producto", "id_devolucion" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_garantias_id_usuario",
                table: "garantias",
                column: "id_usuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_garantias_id_venta",
                table: "garantias",
                column: "id_venta",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ordenes_ensambles_id_usuario",
                table: "ordenes_ensambles",
                column: "id_usuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ordenes_ensambles_id_venta",
                table: "ordenes_ensambles",
                column: "id_venta",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_productos_codigo",
                table: "productos",
                column: "codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_productos_carrito_id_carrito",
                table: "productos_carrito",
                column: "id_carrito");

            migrationBuilder.CreateIndex(
                name: "IX_productos_carrito_id_producto_id_carrito",
                table: "productos_carrito",
                columns: new[] { "id_producto", "id_carrito" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_proveedores_correo",
                table: "proveedores",
                column: "correo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_proveedores_telefono",
                table: "proveedores",
                column: "telefono",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_reparaciones_id_usuario",
                table: "reparaciones",
                column: "id_usuario");

            migrationBuilder.CreateIndex(
                name: "IX_reparaciones_id_venta",
                table: "reparaciones",
                column: "id_venta");

            migrationBuilder.CreateIndex(
                name: "IX_roles_nombre",
                table: "roles",
                column: "nombre",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_id_rol",
                table: "usuarios",
                column: "id_rol",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_nombre_usuario",
                table: "usuarios",
                column: "nombre_usuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ventas_id_cliente",
                table: "ventas",
                column: "id_cliente",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ventas_id_usuario",
                table: "ventas",
                column: "id_usuario",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "caracteristicas_productos");

            migrationBuilder.DropTable(
                name: "componentes");

            migrationBuilder.DropTable(
                name: "componentes_garantias");

            migrationBuilder.DropTable(
                name: "componentes_ordenes");

            migrationBuilder.DropTable(
                name: "componentes_reparaciones");

            migrationBuilder.DropTable(
                name: "detalles_compras");

            migrationBuilder.DropTable(
                name: "detalles_ventas");

            migrationBuilder.DropTable(
                name: "devoluciones_productos");

            migrationBuilder.DropTable(
                name: "productos_carrito");

            migrationBuilder.DropTable(
                name: "caracteristicas");

            migrationBuilder.DropTable(
                name: "garantias");

            migrationBuilder.DropTable(
                name: "ordenes_ensambles");

            migrationBuilder.DropTable(
                name: "reparaciones");

            migrationBuilder.DropTable(
                name: "compras");

            migrationBuilder.DropTable(
                name: "devoluciones");

            migrationBuilder.DropTable(
                name: "carrito_compras");

            migrationBuilder.DropTable(
                name: "productos");

            migrationBuilder.DropTable(
                name: "proveedores");

            migrationBuilder.DropTable(
                name: "ventas");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
