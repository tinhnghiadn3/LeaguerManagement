using System.Collections.Generic;

namespace LeaguerManagement.Entities.Entities
{
    public partial class ConfirmPurpose
    {
        public ConfirmPurpose()
        {
            FileDetail = new HashSet<FileDetail>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<FileDetail> FileDetail { get; set; }
    }
}
