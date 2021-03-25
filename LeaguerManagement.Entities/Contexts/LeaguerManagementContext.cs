using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LeaguerManagement.Entities.Entities;

#nullable disable

namespace LeaguerManagement.Entities.Contexts
{
    public partial class LeaguerManagementContext : DbContext
    {
        public LeaguerManagementContext()
        {
        }

        public LeaguerManagementContext(DbContextOptions<LeaguerManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccessControl> AccessControls { get; set; }
        public virtual DbSet<AccessOfRole> AccessOfRoles { get; set; }
        public virtual DbSet<AppliedDocument> AppliedDocuments { get; set; }
        public virtual DbSet<AppliedDocumentAttachment> AppliedDocumentAttachments { get; set; }
        public virtual DbSet<Leaguer> Leaguers { get; set; }
        public virtual DbSet<Pronoun> Pronouns { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Status> Statuses { get; set; }
        public virtual DbSet<Unit> Units { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserRole> UserRoles { get; set; }
        public virtual DbSet<UserToken> UserTokens { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AccessControl>(entity =>
            {
                entity.ToTable("AccessControl");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<AccessOfRole>(entity =>
            {
                entity.ToTable("AccessOfRole");
            });

            modelBuilder.Entity<AppliedDocument>(entity =>
            {
                entity.ToTable("AppliedDocument");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Leaguer)
                    .WithMany(p => p.AppliedDocuments)
                    .HasForeignKey(d => d.LeaguerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppliedDo__Leagu__33D4B598");
            });

            modelBuilder.Entity<AppliedDocumentAttachment>(entity =>
            {
                entity.ToTable("AppliedDocumentAttachment");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FileExtension).IsRequired();

                entity.Property(e => e.FileName).IsRequired();

                entity.Property(e => e.FilePath).IsRequired();

                entity.HasOne(d => d.AppliedDocument)
                    .WithMany(p => p.AppliedDocumentAttachments)
                    .HasForeignKey(d => d.AppliedDocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppliedDo__Appli__36B12243");
            });

            modelBuilder.Entity<Leaguer>(entity =>
            {
                entity.ToTable("Leaguer");

                entity.Property(e => e.BackgroundNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.BadgeNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.CardNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DeadDate).HasColumnType("datetime");

                entity.Property(e => e.GetOutDate).HasColumnType("datetime");

                entity.Property(e => e.MoveInDated).HasColumnType("datetime");

                entity.Property(e => e.MoveOutDated).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.OfficialApplyDate).HasColumnType("datetime");

                entity.Property(e => e.PreliminaryApplyDate).HasColumnType("datetime");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Leaguers)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Leaguer__StatusI__30F848ED");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Leaguers)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Leaguer__UnitId__300424B4");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("Status");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Unit>(entity =>
            {
                entity.ToTable("Unit");

                entity.Property(e => e.IdentifyNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Salt).IsRequired();
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("UserRole");
            });

            modelBuilder.Entity<UserToken>(entity =>
            {
                entity.ToTable("UserToken");

                entity.Property(e => e.ExpireAt).HasColumnType("datetime");

                entity.Property(e => e.ImageToken).IsRequired();

                entity.Property(e => e.Token).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
