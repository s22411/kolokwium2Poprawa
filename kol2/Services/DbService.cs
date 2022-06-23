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

        public async Task<GetTeamDTO> GetTeamAsync(int id)
        {
            var team = await _context.Teams.Where(m => m.TeamID == id).SingleOrDefaultAsync();

            if (team == null) throw new KeyNotFoundException("Team does not exist");

            GetTeamDTO resp = new GetTeamDTO
            {
                TeamName = team.TeamName,
                TeamDescription = team.TeamDescription,
                OrganizationName = await _context.Organizatons.Where(o => o.OrganizationID == team.OrganizationID).Select(o => o.OrganizationName).SingleOrDefaultAsync(),
                //Members = await _context.Mem
            }

            throw new NotImplementedException();
        }
    }
}