using kol2.Services;
using Microsoft.AspNetCore.Mvc;

namespace kol2.Controllers
{
    public class TeamsController : ControllerBase
    {
        public readonly IDbService _service;

        public TeamsController(IDbService service)
        {
            _service = service;
        }


    }
}