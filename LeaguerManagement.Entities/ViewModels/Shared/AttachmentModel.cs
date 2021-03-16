using System;
using System.Collections.Generic;

namespace LeaguerManagement.Entities.ViewModels.Shared
{
    public class AttachmentModel
    {
        public int Id { get; set; }
        public int ReferenceId { get; set; }
        public string ReferenceName { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string Notes { get; set; }
        public long FileSize { get; set; }
        public string FileExtension { get; set; }
        public string Extension => FileExtension?.Replace(".", "").ToLower();
        public DateTime CreatedDate { get; set; }
        public int? CreatedByUserId { get; set; }
        public string CreatedByName { get; set; }
        public bool IsImage => Extension != null && (Extension == "jpg" || Extension == "jpeg" || Extension == "gif" || Extension == "png");
    }

    public class ReferenceWithAttachmentModel<T>
    {
        public T Reference { get; set; }
        public IList<AttachmentModel> Attachments { get; set; }
        public int TotalAttachments { get; set; }

        public ReferenceWithAttachmentModel()
        {
            Attachments = new List<AttachmentModel>();
        }
    }

    public class RenameAttachmentModel
    {
        public int AttachmentId { get; set; }
        public string NewName { get; set; }
        public int ReferenceId { get; set; }
    }
}
