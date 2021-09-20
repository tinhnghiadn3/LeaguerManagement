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
        public virtual DbSet<ChangeOfficialDocument> ChangeOfficialDocuments { get; set; }
        public virtual DbSet<ChangeOfficialDocumentType> ChangeOfficialDocumentTypes { get; set; }
        public virtual DbSet<Documentation> Documentations { get; set; }
        public virtual DbSet<DocumentationAttachment> DocumentationAttachments { get; set; }
        public virtual DbSet<Leaguer> Leaguers { get; set; }
        public virtual DbSet<LeaguerAttachment> LeaguerAttachments { get; set; }
        public virtual DbSet<Pronoun> Pronouns { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<RatingResult> RatingResults { get; set; }
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
                    .HasConstraintName("FK__AppliedDo__Leagu__3F466844");
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
                    .HasConstraintName("FK__AppliedDo__Appli__403A8C7D");
            });

            modelBuilder.Entity<ChangeOfficialDocument>(entity =>
            {
                entity.ToTable("ChangeOfficialDocument");

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.ChangeOfficialDocumentType)
                    .WithMany(p => p.ChangeOfficialDocuments)
                    .HasForeignKey(d => d.ChangeOfficialDocumentTypeId)
                    .HasConstraintName("FK__ChangeOff__Chang__412EB0B6");
            });

            modelBuilder.Entity<ChangeOfficialDocumentType>(entity =>
            {
                entity.ToTable("ChangeOfficialDocumentType");
            });

            modelBuilder.Entity<Documentation>(entity =>
            {
                entity.ToTable("Documentation");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<DocumentationAttachment>(entity =>
            {
                entity.ToTable("DocumentationAttachment");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FileExtension).IsRequired();

                entity.Property(e => e.FileName).IsRequired();

                entity.Property(e => e.FilePath).IsRequired();

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.DocumentationAttachments)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .HasConstraintName("FK__Documenta__Creat__5629CD9C");

                entity.HasOne(d => d.Documentation)
                    .WithMany(p => p.DocumentationAttachments)
                    .HasForeignKey(d => d.DocumentationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Documenta__Docum__5535A963");
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
                    .HasConstraintName("FK__Leaguer__StatusI__4222D4EF");

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Leaguers)
                    .HasForeignKey(d => d.UnitId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Leaguer__UnitId__4316F928");
            });

            modelBuilder.Entity<LeaguerAttachment>(entity =>
            {
                entity.ToTable("LeaguerAttachment");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FileExtension).IsRequired();

                entity.Property(e => e.FileName).IsRequired();

                entity.Property(e => e.FilePath).IsRequired();

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.LeaguerAttachments)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LeaguerAt__Creat__440B1D61");

                entity.HasOne(d => d.Leaguer)
                    .WithMany(p => p.LeaguerAttachments)
                    .HasForeignKey(d => d.LeaguerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LeaguerAt__Leagu__44FF419A");
            });

            modelBuilder.Entity<Rating>(entity =>
            {
                entity.ToTable("Rating");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<RatingResult>(entity =>
            {
                entity.ToTable("RatingResult");

                entity.Property(e => e.Year)
                    .IsRequired()
                    .HasMaxLength(55)
                    .IsUnicode(false);

                entity.HasOne(d => d.Leaguer)
                    .WithMany(p => p.RatingResults)
                    .HasForeignKey(d => d.LeaguerId)
                    .HasConstraintName("FK__RatingRes__Leagu__72C60C4A");

                entity.HasOne(d => d.Rating)
                    .WithMany(p => p.RatingResults)
                    .HasForeignKey(d => d.RatingId)
                    .HasConstraintName("FK__RatingRes__Ratin__71D1E811");
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

                entity.HasOne(d => d.Unit)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.UnitId)
                    .HasConstraintName("FK__User__UnitId__4F7CD00D");
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
