using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2.Models
{
    public class Organization
    {
        public Organization()
        {
            Members = new HashSet<Member>();
            Teams = new HashSet<Team>();
        }

        public int OrganizationID { get; set; }
        public string OrganizationName { get; set; }
        public string OrganizationDomain { get; set; }
        public virtual IEnumerable<Member> Members { get; set; }
        public virtual IEnumerable<Team> Teams { get; set; }
    }
}