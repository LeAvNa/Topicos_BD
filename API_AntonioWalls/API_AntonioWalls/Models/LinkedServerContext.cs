using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API_AntonioWalls.Models;

public partial class LinkedServerContext : DbContext
{
    public LinkedServerContext()
    {
    }

    public LinkedServerContext(DbContextOptions<LinkedServerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Sucursales> Sucursales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Sucursales>(entity =>
        {
            entity.HasKey(e => e.IdSucursal).HasName("PK__Sucursal__4C75801305289BED");

            entity.Property(e => e.IdSucursal)
                .ValueGeneratedNever()
                .HasColumnName("id_sucursal");
            entity.Property(e => e.Calle)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("calle");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("ciudad");
            entity.Property(e => e.Col)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("col");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Cp).HasColumnName("cp");
            entity.Property(e => e.Estado)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaAp).HasColumnName("fecha_ap");
            entity.Property(e => e.Num).HasColumnName("num");
            entity.Property(e => e.Pais)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("pais");
            entity.Property(e => e.Presup)
                .HasColumnType("money")
                .HasColumnName("presup");
            entity.Property(e => e.RazSoc)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("raz_soc");
            entity.Property(e => e.Rfc)
                .HasMaxLength(13)
                .IsUnicode(false)
                .HasColumnName("rfc");
            entity.Property(e => e.TelefonoSuc)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("telefono_suc");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
