using kol2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kol2.Controllers
{
    [Route("api")]
    [ApiController]
    public class MainController : ControllerBase
    {
        private readonly IDbService _service;

        public MainController(IDbService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("team/{id}")]
        public async Task<IActionResult> GetTeam(int id)
        {
            try
            {
                return Ok(await _service.GetTeamAsync(id));
            }
            catch(KeyNotFoundException e)
            {
                //throw new NotImplementedException();
                return NotFound(e.Message);
            }
            catch(Exception)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        [Route("addmember")]
        public async Task<IActionResult> AddMemberToTeam([FromQuery] int memberID, [FromQuery] int teamID)
        {
            try
            {
                await _service.AddMemberToTeamAsync(memberID, teamID);
                return Ok("Member assigned");
            }
            catch(Exception)
            {
                throw new NotImplementedException();
            }
            
            throw new NotImplementedException();
        }
    }
}
