using kol2.Models;
using kol2.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2.Services
{
    public class DbService : IDbService
    {
        private readonly MainDbContext _context;

        public DbService(MainDbContext context)
        {
            _context = context;
        }

        public async Task AddMemberToTeamAsync(int memberID, int teamID)
        {
            var member = await _context.Members.Where(m => m.MemberID == memberID).SingleOrDefaultAsync();
            if (member == null) throw new KeyNotFoundException("No such member");

            var team = await _context.Teams.Where(m => m.TeamID == teamID).SingleOrDefaultAsync();
            if (member == null) throw new KeyNotFoundException("No such team");

            if (team.OrganizationID != member.OrganizationID) throw new Exception("Member and Team in different organizations");

            var membership = await _context.Memberships.Where(ms => ms.MemberID == memberID && ms.TeamID == teamID).FirstOrDefaultAsync();
            if (membership != null) return;

            await _context.Memberships.AddAsync(new Membership
            {
                MemberID = memberID,
                TeamID = teamID,
                MembershipDate = DateTime.Now
            });

            throw new NotImplementedException();
        }

        public async Task<GetTeamDTO> GetTeamAsync(int id)
        {
            var team = await _context.Teams.Where(m => m.TeamID == id).SingleOrDefaultAsync();

            if (team == null) throw new KeyNotFoundException("Team does not exist");

            GetTeamDTO result = new GetTeamDTO
            {
                TeamName = team.TeamName,
                TeamDescription = team.TeamDescription,
                OrganizationName = await _context.Organizatons.Where(o => o.OrganizationID == team.OrganizationID).Select(o => o.OrganizationName).SingleOrDefaultAsync(),
                Members = await _context.Memberships.Where(ms => ms.TeamID == team.TeamID)
                                    .Join(_context.Members, ms => ms.MemberID, m => m.MemberID, (ms, m) => new GetMemberDTO
                                    {
                                        MemberName = m.MemberName,
                                        MemberSurname = m.MemberSurname
                                    }).ToListAsync()
            };

            return result;
        }
    }
}