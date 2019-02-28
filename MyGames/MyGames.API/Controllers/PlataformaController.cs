using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGames.API.Models.Plataforma;
using MyGames.Repository.Contracts;

namespace MyGames.API.Controllers
{
    [Route("mygameapi/plataforma")]
    [EnableCors("DefaultPolicy")]
    [Produces("application/json")]
    [ApiController]
    public class PlataformaController : ControllerBase
    {
        private readonly IPlataformaRepository repository;

        public PlataformaController(IPlataformaRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public IActionResult Post([FromBody] PlataformaCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {

            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}