using System;
using System.Collections.Generic;

#nullable disable

namespace LeaguerManagement.Entities.Entities
{
    public partial class LeaguerAttachment
    {
        public int Id { get; set; }
        public int LeaguerId { get; set; }
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileExtension { get; set; }
        public string FileUrl { get; set; }
        public long? FileSize { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatedByUserId { get; set; }
        public bool IsAvatar { get; set; }

        public virtual User CreatedByUser { get; set; }
        public virtual Leaguer Leaguer { get; set; }
    }
}
