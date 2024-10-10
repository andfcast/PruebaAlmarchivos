using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PersonApp.Infrastructure.Entidades;

namespace PersonApp.Infrastructure.Context;

public partial class RegistrosDbContext : DbContext
{
    public RegistrosDbContext()
    {
    }

    public RegistrosDbContext(DbContextOptions<RegistrosDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<TiposIdentificacion> TiposIdentificacions { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Persona>(entity =>
        {
            entity.Property(e => e.Apellidos).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FechaModificacion).HasColumnType("datetime");
            entity.Property(e => e.Nombres).HasMaxLength(50);
            entity.Property(e => e.NumIdentificacion).HasMaxLength(20);

            entity.HasOne(d => d.IdTipoIdentificacionNavigation).WithMany(p => p.Personas)
                .HasForeignKey(d => d.IdTipoIdentificacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Personas_TiposIdentificacion");
        });

        modelBuilder.Entity<TiposIdentificacion>(entity =>
        {
            entity.ToTable("TiposIdentificacion");

            entity.Property(e => e.Descripcion).HasMaxLength(50);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {            
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NombreUsuario).HasMaxLength(20);
            entity.Property(e => e.Password).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
