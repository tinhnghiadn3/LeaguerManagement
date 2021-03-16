using System.Collections.Generic;

namespace LeaguerManagement.Entities.Entities
{
    public partial class CopyType
    {
        public CopyType()
        {
            CopiedDocument = new HashSet<CopiedDocument>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<CopiedDocument> CopiedDocument { get; set; }
    }
}
