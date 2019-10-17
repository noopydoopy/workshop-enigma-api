using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Enigma.Controllers
{
    [Route("api/mission")]
    [ApiController]
    public class MissionController : ControllerBase
    {
        public MissionController()
        {
            
        }

        [Route("")]
        [HttpGet]
        public IActionResult Index()
        {
            return new JsonResult("123");
        }
    }
}