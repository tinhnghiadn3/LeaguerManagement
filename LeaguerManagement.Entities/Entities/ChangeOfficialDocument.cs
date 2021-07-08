using System;
using System.Collections.Generic;

#nullable disable

namespace LeaguerManagement.Entities.Entities
{
    public partial class ChangeOfficialDocument
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ChangeOfficialDocumentTypeId { get; set; }

        public virtual ChangeOfficialDocumentType ChangeOfficialDocumentType { get; set; }
    }
}
