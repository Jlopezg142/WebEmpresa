using Microsoft.EntityFrameworkCore;
using WebEmpresa.Entities;

namespace WebEmpresa.Data;

public class Conexiones : DbContext
{
    public Conexiones(DbContextOptions<Conexiones> options)
        : base(options)
    {
    }

    public DbSet<Clientes> Clientes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Clientes>(entity =>
        {
            entity.ToTable("clientes");

            entity.HasKey(e => e.Id_cliente);

            entity.Property(e => e.Id_cliente)
                .HasColumnName("id_cliente");

            entity.Property(e => e.cui)
                .HasColumnName("cui")
                .HasMaxLength(13)
                .IsRequired();

            entity.Property(e => e.nit)
                .HasColumnName("nit")
                .HasMaxLength(15)
                .IsRequired();

            entity.Property(e => e.nombres)
                .HasColumnName("nombres")
                .HasMaxLength(60)
                .IsRequired();

            entity.Property(e => e.apellidos)
                .HasColumnName("apellidos")
                .HasMaxLength(60)
                .IsRequired();

            entity.Property(e => e.direccion)
                .HasColumnName("direccion")
                .HasMaxLength(150);

            entity.Property(e => e.telefono)
                .HasColumnName("telefono")
                .HasMaxLength(12);

            entity.Property(e => e.fecha_nacimiento)
                .HasColumnName("fecha_nacimiento")
                .HasColumnType("date")
                .IsRequired();

            entity.HasIndex(e => e.cui)
                .IsUnique();

            entity.HasIndex(e => e.nit)
                .IsUnique();
        });
    }
}