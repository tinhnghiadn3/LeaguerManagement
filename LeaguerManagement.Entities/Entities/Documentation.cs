using System;
using System.Collections.Generic;

#nullable disable

namespace LeaguerManagement.Entities.Entities
{
    public partial class Documentation
    {
        public Documentation()
        {
            DocumentationAttachments = new HashSet<DocumentationAttachment>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<DocumentationAttachment> DocumentationAttachments { get; set; }
    }
}
