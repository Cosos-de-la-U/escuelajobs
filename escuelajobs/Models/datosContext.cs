using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace escuelajobs.Models
{
    public partial class datosContext : DbContext
    {
        public datosContext()
        {
        }

        public datosContext(DbContextOptions<datosContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<Calificacion> Calificacions { get; set; } = null!;
        public virtual DbSet<Grado> Grados { get; set; } = null!;
        public virtual DbSet<Materium> Materia { get; set; } = null!;
        public virtual DbSet<NonimaAlumno> NonimaAlumnos { get; set; } = null!;
        public virtual DbSet<NonimaDocente> NonimaDocentes { get; set; } = null!;
        public virtual DbSet<Notum> Nota { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=holaescuela.database.windows.net,1433;Database=datos;User ID=CultOfJava503;Password=passIsBanana100!!;TrustServerCertificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Apellidos)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.Nombres)
                    .HasMaxLength(255)
                    .HasDefaultValueSql("(N'')");

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.ProviderKey).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.Property(e => e.LoginProvider).HasMaxLength(128);

                entity.Property(e => e.Name).HasMaxLength(128);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Calificacion>(entity =>
            {
                entity.ToTable("Calificacion");

                entity.Property(e => e.CalificacionCuatro).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.CalificacionDos).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.CalificacionTotal).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.CalificacionTres).HasColumnType("decimal(18, 4)");

                entity.Property(e => e.CalificacionUno).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<Grado>(entity =>
            {
                entity.ToTable("Grado");

                entity.Property(e => e.Grado1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Grado");
            });

            modelBuilder.Entity<Materium>(entity =>
            {
                entity.HasKey(e => e.MateriaId)
                    .HasName("PK__Materia__0D019DE1F0AB7A68");

                entity.Property(e => e.Materia)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<NonimaAlumno>(entity =>
            {
                entity.HasKey(e => e.NominaAlumnoId)
                    .HasName("PK__NonimaAl__C5F2B1F094DE9035");

                entity.ToTable("NonimaAlumno");

                entity.Property(e => e.AlumnoId).HasMaxLength(450);

                entity.HasOne(d => d.Alumno)
                    .WithMany(p => p.NonimaAlumnos)
                    .HasForeignKey(d => d.AlumnoId)
                    .HasConstraintName("FK__NonimaAlu__Alumn__367C1819");

                entity.HasOne(d => d.Grado)
                    .WithMany(p => p.NonimaAlumnos)
                    .HasForeignKey(d => d.GradoId)
                    .HasConstraintName("FK__NonimaAlu__Grado__2BFE89A6");
            });

            modelBuilder.Entity<NonimaDocente>(entity =>
            {
                entity.HasKey(e => e.NominaDocenteId)
                    .HasName("PK__NonimaDo__F6B7B4D93471A396");

                entity.ToTable("NonimaDocente");

                entity.Property(e => e.DocenteId).HasMaxLength(450);

                entity.HasOne(d => d.Docente)
                    .WithMany(p => p.NonimaDocentes)
                    .HasForeignKey(d => d.DocenteId)
                    .HasConstraintName("FK__NonimaDoc__Docen__3587F3E0");

                entity.HasOne(d => d.Grado)
                    .WithMany(p => p.NonimaDocentes)
                    .HasForeignKey(d => d.GradoId)
                    .HasConstraintName("FK__NonimaDoc__Grado__2B0A656D");

                entity.HasOne(d => d.Materia)
                    .WithMany(p => p.NonimaDocentes)
                    .HasForeignKey(d => d.MateriaId)
                    .HasConstraintName("FK__NonimaDoc__Mater__2A164134");
            });

            modelBuilder.Entity<Notum>(entity =>
            {
                entity.HasKey(e => e.NotaId)
                    .HasName("PK__Nota__EF36CC1ACF17F673");

                entity.Property(e => e.AlumnoId).HasMaxLength(450);

                entity.Property(e => e.DocenteId).HasMaxLength(450);

                entity.HasOne(d => d.Alumno)
                    .WithMany(p => p.NotumAlumnos)
                    .HasForeignKey(d => d.AlumnoId)
                    .HasConstraintName("FK__Nota__AlumnoId__339FAB6E");

                entity.HasOne(d => d.Calificacion)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.CalificacionId)
                    .HasConstraintName("FK__Nota__Calificaci__2DE6D218");

                entity.HasOne(d => d.Docente)
                    .WithMany(p => p.NotumDocentes)
                    .HasForeignKey(d => d.DocenteId)
                    .HasConstraintName("FK__Nota__DocenteId__3493CFA7");

                entity.HasOne(d => d.Grado)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.GradoId)
                    .HasConstraintName("FK__Nota__GradoId__2EDAF651");

                entity.HasOne(d => d.Materia)
                    .WithMany(p => p.Nota)
                    .HasForeignKey(d => d.MateriaId)
                    .HasConstraintName("FK__Nota__MateriaId__37703C52");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
