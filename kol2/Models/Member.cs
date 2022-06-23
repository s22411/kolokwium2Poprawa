using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2.Models
{
    public class Member
    {
        public Member()
        {
            Memberships = new HashSet<Membership>();
        }
        
        public int MemberID { get; set; }
        public int OrganizationID { get; set; }
        public string MemberName { get; set; }
        public string MemberSurname { get; set; }
        public string MemberNickName { get; set; }

        public virtual Organization Organization { get; set; }
        public virtual IEnumerable<Membership> Memberships { get; set; }
    }
}