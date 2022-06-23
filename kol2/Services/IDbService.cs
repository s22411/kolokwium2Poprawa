using kol2.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2.Services
{
    public interface IDbService
    {
        public Task<GetTeamDTO> GetTeamAsync(int id);
    }
}