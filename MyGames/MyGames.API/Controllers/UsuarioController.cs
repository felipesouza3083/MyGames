using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyGames.API.Controllers
{
    [Route("mygameapi/usuario")]
    [EnableCors("DefaultPolicy")]
    [Produces("application/json")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
    }
}