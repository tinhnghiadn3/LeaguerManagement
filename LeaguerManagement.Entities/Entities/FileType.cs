using System.Collections.Generic;

namespace LeaguerManagement.Entities.Entities
{
    public partial class FileType
    {
        public FileType()
        {
            File = new HashSet<File>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }

        public virtual ICollection<File> File { get; set; }
    }
}
