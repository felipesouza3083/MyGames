using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGames.API.Models.Usuario;
using MyGames.Entities;
using MyGames.Repository.Contracts;
using MyGames.Repository.Util;

namespace MyGames.API.Controllers
{
    [Route("mygameapi/usuario")]
    [EnableCors("DefaultPolicy")]
    [Produces("application/json")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository repository;

        public UsuarioController(IUsuarioRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        [Route("cadastrarusuario")]
        public IActionResult Post([FromBody] UsuarioCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var u = Mapper.Map<Usuario>(model);

                    u.Senha = Criptografia.EncriptarSenhaMD5(u.Senha);

                    repository.Insert(u);

                    return Ok("Usuário cadastrado com sucesso.");
                }
                catch(Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("autenticarusuario")]
        public IActionResult PostAutenticate([FromBody] UsuarioLoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var u = repository.Find(model.Login, Criptografia.EncriptarSenhaMD5(model.Senha));

                    return Ok();
                }
                catch(Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}