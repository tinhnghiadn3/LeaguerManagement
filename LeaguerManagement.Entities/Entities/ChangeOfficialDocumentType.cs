using System;
using System.Collections.Generic;

#nullable disable

namespace LeaguerManagement.Entities.Entities
{
    public partial class ChangeOfficialDocumentType
    {
        public ChangeOfficialDocumentType()
        {
            ChangeOfficialDocuments = new HashSet<ChangeOfficialDocument>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<ChangeOfficialDocument> ChangeOfficialDocuments { get; set; }
    }
}
