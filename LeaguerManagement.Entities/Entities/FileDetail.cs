using System;
using System.Collections.Generic;

namespace LeaguerManagement.Entities.Entities
{
    public partial class FileDetail
    {
        public FileDetail()
        {
            File = new HashSet<File>();
        }

        public int Id { get; set; }
        public int FormalityId { get; set; }
        public DateTime ApplyDate { get; set; }
        public string Content { get; set; }
        public string Purpose { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string AppointmentCode { get; set; }
        public int? NotificationId { get; set; }
        public int? SearchResultId { get; set; }
        public int? CopyResultId { get; set; }
        public DateTime? EnactDate { get; set; }
        public DateTime? ReturnDate { get; set; }
        public int? InvoiceId { get; set; }
        public string ReceiverName { get; set; }
        public string ReceivingNotes { get; set; }
        public int StatusId { get; set; }
        public string FileCode { get; set; }
        public string Notes { get; set; }
        public string CertificateNumber { get; set; }
        public int? ConfirmPurposeId { get; set; }
        public string ArchivesNumber { get; set; }
        public int? PointResultId { get; set; }

        public virtual ConfirmPurpose ConfirmPurpose { get; set; }
        public virtual CopyResult CopyResult { get; set; }
        public virtual Invoice Invoice { get; set; }
        public virtual Notification Notification { get; set; }
        public virtual PointResult PointResult { get; set; }
        public virtual SearchResult SearchResult { get; set; }
        public virtual Status Status { get; set; }
        public virtual ICollection<File> File { get; set; }
    }
}
