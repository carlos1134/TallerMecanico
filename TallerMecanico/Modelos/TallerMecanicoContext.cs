using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TallerMecanico.Modelos;

public partial class TallerMecanicoContext : DbContext
{
    public TallerMecanicoContext()
    {
    }

    public TallerMecanicoContext(DbContextOptions<TallerMecanicoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Automovil> Automovils { get; set; }

    public virtual DbSet<Desperfecto> Desperfectos { get; set; }

    public virtual DbSet<DesperfectoRepuesto> DesperfectoRepuestos { get; set; }

    public virtual DbSet<Moto> Motos { get; set; }

    public virtual DbSet<Presupuesto> Presupuestos { get; set; }

    public virtual DbSet<Repuesto> Repuestos { get; set; }

    public virtual DbSet<Vehiculo> Vehiculos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-JI7GCO0\\SQLEXPRESS;Database=TallerMecanico;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Automovil>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Automovi__3214EC073BAEF71C");

            entity.ToTable("Automovil");

            entity.HasOne(d => d.IdVehiculoNavigation).WithMany(p => p.Automovils)
                .HasForeignKey(d => d.IdVehiculo)
                .HasConstraintName("FK__Automovil__IdVeh__5DCAEF64");
        });

        modelBuilder.Entity<Desperfecto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Desperfe__3214EC07206DA805");

            entity.ToTable("Desperfecto");

            entity.Property(e => e.Descripcion).IsUnicode(false);
            entity.Property(e => e.ManoDeObra).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdPresupuestoNavigation).WithMany(p => p.Desperfectos)
                .HasForeignKey(d => d.IdPresupuesto)
                .HasConstraintName("FK__Desperfec__IdPre__6383C8BA");
        });

        modelBuilder.Entity<DesperfectoRepuesto>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("DesperfectoRepuesto");

            entity.HasOne(d => d.IdDesperfectoNavigation).WithMany()
                .HasForeignKey(d => d.IdDesperfecto)
                .HasConstraintName("FK__Desperfec__IdDes__6754599E");

            entity.HasOne(d => d.IdRepuestoNavigation).WithMany()
                .HasForeignKey(d => d.IdRepuesto)
                .HasConstraintName("FK__Desperfec__IdRep__68487DD7");
        });

        modelBuilder.Entity<Moto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Moto__3214EC07C19719CF");

            entity.ToTable("Moto");

            entity.Property(e => e.Cilindrada)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.IdVehiculoNavigation).WithMany(p => p.Motos)
                .HasForeignKey(d => d.IdVehiculo)
                .HasConstraintName("FK__Moto__IdVehiculo__5AEE82B9");
        });

        modelBuilder.Entity<Presupuesto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Presupue__3214EC07B33C58A2");

            entity.ToTable("Presupuesto");

            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Total).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.IdVehiculoNavigation).WithMany(p => p.Presupuestos)
                .HasForeignKey(d => d.IdVehiculo)
                .HasConstraintName("FK__Presupues__IdVeh__60A75C0F");
        });

        modelBuilder.Entity<Repuesto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Repuesto__3214EC077AD04A55");

            entity.ToTable("Repuesto");

            entity.Property(e => e.Nombre)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.Precio).HasColumnType("decimal(18, 0)");
        });

        modelBuilder.Entity<Vehiculo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Vehiculo__3214EC07C915A84F");

            entity.ToTable("Vehiculo");

            entity.Property(e => e.Marca)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Modelo)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Patente)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
