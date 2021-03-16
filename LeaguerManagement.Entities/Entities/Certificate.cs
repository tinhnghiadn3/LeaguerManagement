using System;
using System.Collections.Generic;

namespace LeaguerManagement.Entities.Entities
{
    public partial class Certificate
    {
        public Certificate()
        {
            CertificateAttachmentCertificate = new HashSet<CertificateAttachment>();
            CertificateAttachmentCreatedByUser = new HashSet<CertificateAttachment>();
        }

        public int Id { get; set; }
        public int SearchResultId { get; set; }
        public int CertificateTypeId { get; set; }
        public string ForName { get; set; }
        public string CertificateCode { get; set; }
        public string EntryNumber { get; set; }
        public DateTime EntryDate { get; set; }
        public int MapNumber { get; set; }
        public int ParcelNumber { get; set; }
        public int OldMapNumber { get; set; }
        public int OldParcelNumber { get; set; }
        public int? WardId { get; set; }
        public int LandArea { get; set; }
        public int? BuiltArea { get; set; }
        public string UsingPurpose { get; set; }

        public virtual CertificateType CertificateType { get; set; }
        public virtual SearchResult SearchResult { get; set; }
        public virtual Ward Ward { get; set; }
        public virtual ICollection<CertificateAttachment> CertificateAttachmentCertificate { get; set; }
        public virtual ICollection<CertificateAttachment> CertificateAttachmentCreatedByUser { get; set; }
    }
}
