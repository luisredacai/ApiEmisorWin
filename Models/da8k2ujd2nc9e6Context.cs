using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ApiProject3.Models
{
    public partial class da8k2ujd2nc9e6Context : DbContext
    {
        public da8k2ujd2nc9e6Context()
        {
        }

        public da8k2ujd2nc9e6Context(DbContextOptions<da8k2ujd2nc9e6Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Archivo> Archivos { get; set; } = null!;
        public virtual DbSet<Empleado> Empleados { get; set; } = null!;
        public virtual DbSet<EquifaxRuc> EquifaxRucs { get; set; } = null!;
        public virtual DbSet<Servicio> Servicios { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
              //  optionsBuilder.UseSqlServer("Server=tcp:appx1.database.windows.net,1433;Initial Catalog=da8k2ujd2nc9e6;Persist Security Info=False;User ID=admin1;Password=lasamericas789@;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Archivo>(entity =>
            {
                entity.HasKey(e => e.IdAr)
                    .HasName("ARCHIVOS_PK");

                entity.ToTable("archivos");

                entity.Property(e => e.IdAr).HasColumnName("id_ar");

                entity.Property(e => e.ExtencionAr)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("extencion_ar");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Tamanio).HasColumnName("tamanio");

                entity.Property(e => e.Ubicacion)
                    .HasColumnType("text")
                    .HasColumnName("ubicacion");
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.ToTable("empleado");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("id");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Puesto)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("puesto");

                entity.Property(e => e.Sueldo).HasColumnName("sueldo");
            });

            modelBuilder.Entity<EquifaxRuc>(entity =>
            {
                entity.ToTable("equifax_RUC");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ApellidoMa)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("apellido_ma");

                entity.Property(e => e.ApellidoPa)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("apellido_pa");

                entity.Property(e => e.Deuda)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.FechaCreacionRuc)
                    .HasColumnType("datetime")
                    .HasColumnName("fecha_creacion_ruc");

                entity.Property(e => e.IdServicio).HasColumnName("id_servicio");

                entity.Property(e => e.Nombre)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("nombre");

                entity.Property(e => e.Ruc).HasColumnName("ruc");

                entity.Property(e => e.ScoreCrediticio).HasColumnName("Score_crediticio");

                entity.HasOne(d => d.IdServicioNavigation)
                    .WithMany(p => p.EquifaxRucs)
                    .HasForeignKey(d => d.IdServicio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__equifax_R__id_se__6FE99F9F");
            });

            modelBuilder.Entity<Servicio>(entity =>
            {
                entity.HasKey(e => e.IdServicio)
                    .HasName("id_servicio_pk");

                entity.ToTable("servicio");

                entity.Property(e => e.IdServicio).HasColumnName("id_servicio");

                entity.Property(e => e.Ce).HasColumnName("ce");

                entity.Property(e => e.Dni).HasColumnName("dni");

                entity.Property(e => e.Estado)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("estado");

                entity.Property(e => e.Ruc).HasColumnName("ruc");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
