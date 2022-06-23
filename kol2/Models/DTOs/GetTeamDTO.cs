using System.Collections.Generic;

namespace kol2.Models.DTOs
{
    public class GetTeamDTO
    {
        public string TeamName { get; set; }
        public string TeamDescription { get; set; }
        public string OrganizationName { get; set; }
        public IEnumerable<Member> Members { get; set; }
    }
}
