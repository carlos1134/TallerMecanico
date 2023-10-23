using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TallerMecanico.Migrations
{
    /// <inheritdoc />
    public partial class NuevaMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    apellido = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    dni = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Cliente__3214EC0767C44BF4", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Repuesto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Precio = table.Column<decimal>(type: "decimal(18,0)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Repuesto__3214EC0720012543", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vehiculo",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Marca = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Modelo = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Patente = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Vehiculo__3214EC073E604B41", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Automovil",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVehiculo = table.Column<long>(type: "bigint", nullable: true),
                    Tipo = table.Column<short>(type: "smallint", nullable: true),
                    CantidadPuertas = table.Column<short>(type: "smallint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Automovi__3214EC0767C44BF4", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Automovil__IdVeh__3C69FB99",
                        column: x => x.IdVehiculo,
                        principalTable: "Vehiculo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Moto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdVehiculo = table.Column<long>(type: "bigint", nullable: true),
                    Cilindrada = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Moto__3214EC07BF1A4F65", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Moto__IdVehiculo__398D8EEE",
                        column: x => x.IdVehiculo,
                        principalTable: "Vehiculo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Presupuesto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Apellido = table.Column<string>(type: "varchar(100)", unicode: false, maxLength: 100, nullable: true),
                    Email = table.Column<string>(type: "varchar(200)", unicode: false, maxLength: 200, nullable: true),
                    Total = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    IdVehiculo = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Presupue__3214EC07D7F34AD5", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Presupues__IdVeh__3F466844",
                        column: x => x.IdVehiculo,
                        principalTable: "Vehiculo",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Desperfecto",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPresupuesto = table.Column<long>(type: "bigint", nullable: true),
                    Descripcion = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    ManoDeObra = table.Column<decimal>(type: "decimal(18,0)", nullable: true),
                    Tiempo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Desperfe__3214EC0784402348", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Desperfec__IdPre__4222D4EF",
                        column: x => x.IdPresupuesto,
                        principalTable: "Presupuesto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DesperfectoRepuesto",
                columns: table => new
                {
                    IdDesperfecto = table.Column<long>(type: "bigint", nullable: true),
                    IdRepuesto = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__Desperfec__IdDes__5441852A",
                        column: x => x.IdDesperfecto,
                        principalTable: "Desperfecto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Desperfec__IdRep__5535A963",
                        column: x => x.IdRepuesto,
                        principalTable: "Repuesto",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Automovil_IdVehiculo",
                table: "Automovil",
                column: "IdVehiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Desperfecto_IdPresupuesto",
                table: "Desperfecto",
                column: "IdPresupuesto");

            migrationBuilder.CreateIndex(
                name: "IX_DesperfectoRepuesto_IdDesperfecto",
                table: "DesperfectoRepuesto",
                column: "IdDesperfecto");

            migrationBuilder.CreateIndex(
                name: "IX_DesperfectoRepuesto_IdRepuesto",
                table: "DesperfectoRepuesto",
                column: "IdRepuesto");

            migrationBuilder.CreateIndex(
                name: "IX_Moto_IdVehiculo",
                table: "Moto",
                column: "IdVehiculo");

            migrationBuilder.CreateIndex(
                name: "IX_Presupuesto_IdVehiculo",
                table: "Presupuesto",
                column: "IdVehiculo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Automovil");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "DesperfectoRepuesto");

            migrationBuilder.DropTable(
                name: "Moto");

            migrationBuilder.DropTable(
                name: "Desperfecto");

            migrationBuilder.DropTable(
                name: "Repuesto");

            migrationBuilder.DropTable(
                name: "Presupuesto");

            migrationBuilder.DropTable(
                name: "Vehiculo");
        }
    }
}
