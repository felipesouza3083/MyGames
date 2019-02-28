using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyGames.API.Controllers
{
    [Route("mygameapi/status")]
    [EnableCors("DefaultPolicy")]
    [Produces("application/json")]
    [ApiController]
    public class StatusController : ControllerBase
    {
    }
}