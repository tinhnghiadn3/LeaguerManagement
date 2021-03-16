using LeaguerManagement.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace LeaguerManagement.Entities.Contexts
{
    public partial class LandStatusConfirmationContext : DbContext
    {
        public LandStatusConfirmationContext()
        {
        }

        public LandStatusConfirmationContext(DbContextOptions<LandStatusConfirmationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccessControl> AccessControl { get; set; }
        public virtual DbSet<AccessOfRole> AccessOfRole { get; set; }
        public virtual DbSet<Apartment> Apartment { get; set; }
        public virtual DbSet<Applicant> Applicant { get; set; }
        public virtual DbSet<ApplicantType> ApplicantType { get; set; }
        public virtual DbSet<AppliedDocument> AppliedDocument { get; set; }
        public virtual DbSet<AppliedDocumentAttachment> AppliedDocumentAttachment { get; set; }
        public virtual DbSet<Certificate> Certificate { get; set; }
        public virtual DbSet<CertificateAttachment> CertificateAttachment { get; set; }
        public virtual DbSet<CertificateType> CertificateType { get; set; }
        public virtual DbSet<ChargeMethod> ChargeMethod { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<ConfirmPurpose> ConfirmPurpose { get; set; }
        public virtual DbSet<CopiedDocument> CopiedDocument { get; set; }
        public virtual DbSet<CopiedDocumentAttachment> CopiedDocumentAttachment { get; set; }
        public virtual DbSet<CopyResult> CopyResult { get; set; }
        public virtual DbSet<CopyType> CopyType { get; set; }
        public virtual DbSet<District> District { get; set; }
        public virtual DbSet<DocumentType> DocumentType { get; set; }
        public virtual DbSet<File> File { get; set; }
        public virtual DbSet<FileDetail> FileDetail { get; set; }
        public virtual DbSet<FileType> FileType { get; set; }
        public virtual DbSet<Formality> Formality { get; set; }
        public virtual DbSet<Holiday> Holiday { get; set; }
        public virtual DbSet<IdentifyNumberType> IdentifyNumberType { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<Notification> Notification { get; set; }
        public virtual DbSet<PointResult> PointResult { get; set; }
        public virtual DbSet<PointType> PointType { get; set; }
        public virtual DbSet<Pronouns> Pronouns { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<SearchResult> SearchResult { get; set; }
        public virtual DbSet<SearchResultAttachment> SearchResultAttachment { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Street> Street { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }
        public virtual DbSet<UserToken> UserToken { get; set; }
        public virtual DbSet<Ward> Ward { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AccessControl>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<AccessOfRole>(entity =>
            {
                entity.HasOne(d => d.AccessControl)
                    .WithMany(p => p.AccessOfRole)
                    .HasForeignKey(d => d.AccessControlId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AccessOfR__Acces__693CA210");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AccessOfRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AccessOfR__RoleI__6A30C649");
            });

            modelBuilder.Entity<Apartment>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Ward)
                    .WithMany(p => p.Apartment)
                    .HasForeignKey(d => d.WardId)
                    .HasConstraintName("FK__Apartment__WardI__6B24EA82");
            });

            modelBuilder.Entity<Applicant>(entity =>
            {
                entity.Property(e => e.DatedIdentifyCode).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.PhoneNumber).HasMaxLength(15);

                entity.Property(e => e.YearOfBirth)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.Property(e => e.Zone).HasMaxLength(10);

                entity.HasOne(d => d.Apartment)
                    .WithMany(p => p.Applicant)
                    .HasForeignKey(d => d.ApartmentId)
                    .HasConstraintName("FK__Applicant__Apart__6C190EBB");

                entity.HasOne(d => d.ApplicantType)
                    .WithMany(p => p.Applicant)
                    .HasForeignKey(d => d.ApplicantTypeId)
                    .HasConstraintName("FK__Applicant__Appli__6D0D32F4");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Applicant)
                    .HasForeignKey(d => d.CityId)
                    .HasConstraintName("FK__Applicant__CityI__6E01572D");

                entity.HasOne(d => d.Pronouns)
                    .WithMany(p => p.Applicant)
                    .HasForeignKey(d => d.PronounsId)
                    .HasConstraintName("FK__Applicant__Prono__6EF57B66");

                entity.HasOne(d => d.Street)
                    .WithMany(p => p.Applicant)
                    .HasForeignKey(d => d.StreetId)
                    .HasConstraintName("FK__Applicant__Stree__6FE99F9F");

                entity.HasOne(d => d.Ward)
                    .WithMany(p => p.Applicant)
                    .HasForeignKey(d => d.WardId)
                    .HasConstraintName("FK__Applicant__WardI__70DDC3D8");
            });

            modelBuilder.Entity<ApplicantType>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<AppliedDocument>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.District)
                    .WithMany(p => p.AppliedDocument)
                    .HasForeignKey(d => d.DistrictId)
                    .HasConstraintName("FK__AppliedDo__Distr__71D1E811");

                entity.HasOne(d => d.File)
                    .WithMany(p => p.AppliedDocument)
                    .HasForeignKey(d => d.FileId)
                    .HasConstraintName("FK__AppliedDo__FileI__72C60C4A");

                entity.HasOne(d => d.PointType)
                    .WithMany(p => p.AppliedDocument)
                    .HasForeignKey(d => d.PointTypeId)
                    .HasConstraintName("FK__AppliedDo__Point__29221CFB");
            });

            modelBuilder.Entity<AppliedDocumentAttachment>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FileExtension).IsRequired();

                entity.Property(e => e.FileName).IsRequired();

                entity.Property(e => e.FilePath).IsRequired();

                entity.HasOne(d => d.AppliedDocument)
                    .WithMany(p => p.AppliedDocumentAttachment)
                    .HasForeignKey(d => d.AppliedDocumentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AppliedDo__Appli__73BA3083");
            });

            modelBuilder.Entity<Certificate>(entity =>
            {
                entity.Property(e => e.CertificateCode).IsRequired();

                entity.Property(e => e.EntryDate).HasColumnType("date");

                entity.Property(e => e.EntryNumber).IsRequired();

                entity.Property(e => e.ForName).IsRequired();

                entity.Property(e => e.UsingPurpose).IsRequired();

                entity.HasOne(d => d.CertificateType)
                    .WithMany(p => p.Certificate)
                    .HasForeignKey(d => d.CertificateTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Certifica__Certi__74AE54BC");

                entity.HasOne(d => d.SearchResult)
                    .WithMany(p => p.Certificate)
                    .HasForeignKey(d => d.SearchResultId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Certifica__Searc__75A278F5");

                entity.HasOne(d => d.Ward)
                    .WithMany(p => p.Certificate)
                    .HasForeignKey(d => d.WardId)
                    .HasConstraintName("FK__Certifica__WardI__76969D2E");
            });

            modelBuilder.Entity<CertificateAttachment>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FileExtension).IsRequired();

                entity.Property(e => e.FileName).IsRequired();

                entity.Property(e => e.FilePath).IsRequired();

                entity.HasOne(d => d.Certificate)
                    .WithMany(p => p.CertificateAttachmentCertificate)
                    .HasForeignKey(d => d.CertificateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Certifica__Certi__778AC167");

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.CertificateAttachmentCreatedByUser)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .HasConstraintName("FK__Certifica__Creat__787EE5A0");
            });

            modelBuilder.Entity<CertificateType>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<CopiedDocument>(entity =>
            {
                entity.Property(e => e.DocumentName).IsRequired();

                entity.HasOne(d => d.CopyResult)
                    .WithMany(p => p.CopiedDocument)
                    .HasForeignKey(d => d.CopyResultId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CopiedDoc__CopyR__797309D9");

                entity.HasOne(d => d.CopyType)
                    .WithMany(p => p.CopiedDocument)
                    .HasForeignKey(d => d.CopyTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CopiedDoc__CopyT__7A672E12");

                entity.HasOne(d => d.DocumentType)
                    .WithMany(p => p.CopiedDocument)
                    .HasForeignKey(d => d.DocumentTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CopiedDoc__Docum__7B5B524B");
            });

            modelBuilder.Entity<CopiedDocumentAttachment>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FileExtension).HasMaxLength(50);

                entity.HasOne(d => d.CopiedDocument)
                    .WithMany(p => p.CopiedDocumentAttachment)
                    .HasForeignKey(d => d.CopiedDocumentId)
                    .HasConstraintName("FK__CopiedDoc__Copie__7C4F7684");
            });

            modelBuilder.Entity<CopyType>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<District>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<DocumentType>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.HasOne(d => d.CreateByUser)
                    .WithMany(p => p.File)
                    .HasForeignKey(d => d.CreateByUserId)
                    .HasConstraintName("FK__File__CreateByUs__7D439ABD");

                entity.HasOne(d => d.Detail)
                    .WithMany(p => p.File)
                    .HasForeignKey(d => d.DetailId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__File__DetailId__7E37BEF6");

                entity.HasOne(d => d.FileType)
                    .WithMany(p => p.File)
                    .HasForeignKey(d => d.FileTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__File__FileTypeId__7F2BE32F");

                entity.HasOne(d => d.FirstApplicant)
                    .WithMany(p => p.FileFirstApplicant)
                    .HasForeignKey(d => d.FirstApplicantId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__File__FirstAppli__00200768");

                entity.HasOne(d => d.SecondApplicant)
                    .WithMany(p => p.FileSecondApplicant)
                    .HasForeignKey(d => d.SecondApplicantId)
                    .HasConstraintName("FK__File__SecondAppl__01142BA1");
            });

            modelBuilder.Entity<FileDetail>(entity =>
            {
                entity.Property(e => e.ApplyDate).HasColumnType("datetime");

                entity.Property(e => e.AppointmentCode)
                    .IsRequired()
                    .HasMaxLength(15);

                entity.Property(e => e.AppointmentDate).HasColumnType("datetime");

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.EnactDate).HasColumnType("datetime");

                entity.Property(e => e.FileCode).HasMaxLength(13);

                entity.Property(e => e.Purpose).IsRequired();

                entity.Property(e => e.ReturnDate).HasColumnType("datetime");

                entity.HasOne(d => d.ConfirmPurpose)
                    .WithMany(p => p.FileDetail)
                    .HasForeignKey(d => d.ConfirmPurposeId)
                    .HasConstraintName("FK__FileDetai__Confi__02084FDA");

                entity.HasOne(d => d.CopyResult)
                    .WithMany(p => p.FileDetail)
                    .HasForeignKey(d => d.CopyResultId)
                    .HasConstraintName("FK__FileDetai__CopyR__02FC7413");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.FileDetail)
                    .HasForeignKey(d => d.InvoiceId)
                    .HasConstraintName("FK__FileDetai__Invoi__03F0984C");

                entity.HasOne(d => d.Notification)
                    .WithMany(p => p.FileDetail)
                    .HasForeignKey(d => d.NotificationId)
                    .HasConstraintName("FK__FileDetai__Notif__04E4BC85");

                entity.HasOne(d => d.PointResult)
                    .WithMany(p => p.FileDetail)
                    .HasForeignKey(d => d.PointResultId)
                    .HasConstraintName("FK__FileDetai__Point__2BFE89A6");

                entity.HasOne(d => d.SearchResult)
                    .WithMany(p => p.FileDetail)
                    .HasForeignKey(d => d.SearchResultId)
                    .HasConstraintName("FK__FileDetai__Searc__05D8E0BE");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.FileDetail)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FileDetai__Statu__06CD04F7");
            });

            modelBuilder.Entity<FileType>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Holiday>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("date");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.Property(e => e.InvoiceCode).IsRequired();

                entity.Property(e => e.PaidDate).HasColumnType("datetime");

                entity.HasOne(d => d.ChargeMethod)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.ChargeMethodId)
                    .HasConstraintName("FK__Invoice__ChargeM__07C12930");
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<SearchResultAttachment>(entity =>
            {
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.FileExtension).HasMaxLength(50);

                entity.HasOne(d => d.Result)
                    .WithMany(p => p.SearchResultAttachment)
                    .HasForeignKey(d => d.ResultId)
                    .HasConstraintName("FK__SearchRes__Resul__08B54D69");
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Street>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Salt).IsRequired();
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserRole__RoleId__09A971A2");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UserRole__UserId__0A9D95DB");
            });

            modelBuilder.Entity<UserToken>(entity =>
            {
                entity.Property(e => e.ExpireAt).HasColumnType("datetime");

                entity.Property(e => e.ImageToken).IsRequired();

                entity.Property(e => e.Token).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserToken)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserToken__UserI__0B91BA14");
            });

            modelBuilder.Entity<Ward>(entity =>
            {
                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.District)
                    .WithMany(p => p.Ward)
                    .HasForeignKey(d => d.DistrictId)
                    .HasConstraintName("FK__Ward__DistrictId__0C85DE4D");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
