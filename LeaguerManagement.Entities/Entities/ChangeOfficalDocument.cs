using System;
using System.Collections.Generic;

#nullable disable

namespace LeaguerManagement.Entities.Entities
{
    public partial class ChangeOfficalDocument
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsActivated { get; set; }
    }
}
