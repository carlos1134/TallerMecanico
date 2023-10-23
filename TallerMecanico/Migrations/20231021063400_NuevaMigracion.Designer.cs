﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TallerMecanico.Modelos;

#nullable disable

namespace TallerMecanico.Migrations
{
    [DbContext(typeof(TallerMecanicoContext))]
    [Migration("20231021063400_NuevaMigracion")]
    partial class NuevaMigracion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("TallerMecanico.Modelos.Automovil", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("Id"));

                    b.Property<short?>("CantidadPuertas")
                        .HasColumnType("smallint");

                    b.Property<long?>("IdVehiculo")
                        .HasColumnType("bigint");

                    b.Property<short?>("Tipo")
                        .HasColumnType("smallint");

                    b.HasKey("Id")
                        .HasName("PK__Automovi__3214EC0767C44BF4");

                    b.HasIndex("IdVehiculo");

                    b.ToTable("Automovil", (string)null);
                });

            modelBuilder.Entity("TallerMecanico.Modelos.Cliente", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"));

                    b.Property<string>("Apellido")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("apellido");

                    b.Property<int?>("Dni")
                        .HasColumnType("int")
                        .HasColumnName("dni");

                    b.Property<string>("Nombre")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre");

                    b.HasKey("Id")
                        .HasName("PK__Cliente__3214EC0767C44BF4");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("TallerMecanico.Modelos.Desperfecto", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("Id"));

                    b.Property<string>("Descripcion")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<long?>("IdPresupuesto")
                        .HasColumnType("bigint");

                    b.Property<decimal?>("ManoDeObra")
                        .HasColumnType("decimal(18, 0)");

                    b.Property<int?>("Tiempo")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Desperfe__3214EC0784402348");

                    b.HasIndex("IdPresupuesto");

                    b.ToTable("Desperfecto", (string)null);
                });

            modelBuilder.Entity("TallerMecanico.Modelos.DesperfectoRepuesto", b =>
                {
                    b.Property<long?>("IdDesperfecto")
                        .HasColumnType("bigint");

                    b.Property<long?>("IdRepuesto")
                        .HasColumnType("bigint");

                    b.HasIndex("IdDesperfecto");

                    b.HasIndex("IdRepuesto");

                    b.ToTable("DesperfectoRepuesto", (string)null);
                });

            modelBuilder.Entity("TallerMecanico.Modelos.Moto", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("Id"));

                    b.Property<string>("Cilindrada")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<long?>("IdVehiculo")
                        .HasColumnType("bigint");

                    b.HasKey("Id")
                        .HasName("PK__Moto__3214EC07BF1A4F65");

                    b.HasIndex("IdVehiculo");

                    b.ToTable("Moto", (string)null);
                });

            modelBuilder.Entity("TallerMecanico.Modelos.Presupuesto", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("Id"));

                    b.Property<string>("Apellido")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Email")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<long?>("IdVehiculo")
                        .HasColumnType("bigint");

                    b.Property<string>("Nombre")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<decimal?>("Total")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("Id")
                        .HasName("PK__Presupue__3214EC07D7F34AD5");

                    b.HasIndex("IdVehiculo");

                    b.ToTable("Presupuesto", (string)null);
                });

            modelBuilder.Entity("TallerMecanico.Modelos.Repuesto", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("Id"));

                    b.Property<string>("Nombre")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<decimal?>("Precio")
                        .HasColumnType("decimal(18, 0)");

                    b.HasKey("Id")
                        .HasName("PK__Repuesto__3214EC0720012543");

                    b.ToTable("Repuesto", (string)null);
                });

            modelBuilder.Entity("TallerMecanico.Modelos.Vehiculo", b =>
                {
                    b.Property<long?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long?>("Id"));

                    b.Property<string>("Marca")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Modelo")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Patente")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id")
                        .HasName("PK__Vehiculo__3214EC073E604B41");

                    b.ToTable("Vehiculo", (string)null);
                });

            modelBuilder.Entity("TallerMecanico.Modelos.Automovil", b =>
                {
                    b.HasOne("TallerMecanico.Modelos.Vehiculo", "IdVehiculoNavigation")
                        .WithMany("Automovils")
                        .HasForeignKey("IdVehiculo")
                        .HasConstraintName("FK__Automovil__IdVeh__3C69FB99");

                    b.Navigation("IdVehiculoNavigation");
                });

            modelBuilder.Entity("TallerMecanico.Modelos.Desperfecto", b =>
                {
                    b.HasOne("TallerMecanico.Modelos.Presupuesto", "IdPresupuestoNavigation")
                        .WithMany("Desperfectos")
                        .HasForeignKey("IdPresupuesto")
                        .HasConstraintName("FK__Desperfec__IdPre__4222D4EF");

                    b.Navigation("IdPresupuestoNavigation");
                });

            modelBuilder.Entity("TallerMecanico.Modelos.DesperfectoRepuesto", b =>
                {
                    b.HasOne("TallerMecanico.Modelos.Desperfecto", "IdDesperfectoNavigation")
                        .WithMany()
                        .HasForeignKey("IdDesperfecto")
                        .HasConstraintName("FK__Desperfec__IdDes__5441852A");

                    b.HasOne("TallerMecanico.Modelos.Repuesto", "IdRepuestoNavigation")
                        .WithMany()
                        .HasForeignKey("IdRepuesto")
                        .HasConstraintName("FK__Desperfec__IdRep__5535A963");

                    b.Navigation("IdDesperfectoNavigation");

                    b.Navigation("IdRepuestoNavigation");
                });

            modelBuilder.Entity("TallerMecanico.Modelos.Moto", b =>
                {
                    b.HasOne("TallerMecanico.Modelos.Vehiculo", "IdVehiculoNavigation")
                        .WithMany("Motos")
                        .HasForeignKey("IdVehiculo")
                        .HasConstraintName("FK__Moto__IdVehiculo__398D8EEE");

                    b.Navigation("IdVehiculoNavigation");
                });

            modelBuilder.Entity("TallerMecanico.Modelos.Presupuesto", b =>
                {
                    b.HasOne("TallerMecanico.Modelos.Vehiculo", "IdVehiculoNavigation")
                        .WithMany("Presupuestos")
                        .HasForeignKey("IdVehiculo")
                        .HasConstraintName("FK__Presupues__IdVeh__3F466844");

                    b.Navigation("IdVehiculoNavigation");
                });

            modelBuilder.Entity("TallerMecanico.Modelos.Presupuesto", b =>
                {
                    b.Navigation("Desperfectos");
                });

            modelBuilder.Entity("TallerMecanico.Modelos.Vehiculo", b =>
                {
                    b.Navigation("Automovils");

                    b.Navigation("Motos");

                    b.Navigation("Presupuestos");
                });
#pragma warning restore 612, 618
        }
    }
}
