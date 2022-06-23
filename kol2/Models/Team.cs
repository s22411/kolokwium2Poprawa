using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2.Models
{
    public class Team
    {
        public Team()
        {
            Memberships = new HashSet<Membership>();
            Files = new HashSet<File>();
        }

        public int TeamID { get; set; }
        public int OrganizationID { get; set; }
        public string TeamName { get; set; }
        public string? TeamDescription { get; set; }
        
        public virtual Organization Organization { get; set; }
        public virtual IEnumerable<Membership> Memberships { get; set; }
        public virtual IEnumerable<File> Files { get; set; }
    }
}