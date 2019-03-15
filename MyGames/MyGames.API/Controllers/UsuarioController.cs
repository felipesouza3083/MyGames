using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyGames.API.Configuration;
using MyGames.API.Models.Usuario;
using MyGames.API.Provider;
using MyGames.Entities;
using MyGames.Repository.Contracts;
using MyGames.Repository.Util;
using Newtonsoft.Json;

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
        [Authorize(Roles = "Administrador")]
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
                catch (Exception e)
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
        public IActionResult PostAutenticate([FromBody] UsuarioLoginViewModel model,
                                             [FromServices]SigningConfigurations signingConfigurations)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var u = repository.Find(model.Login, Criptografia.EncriptarSenhaMD5(model.Senha));

                    if (u != null)
                    {
                        var usuarioAutenticado = Mapper.Map<UsuarioAutenticadoViewModel>(u);

                        ClaimsIdentity identity = new ClaimsIdentity(
                            new[] {
                                    new Claim(ClaimTypes.Name, JsonConvert.SerializeObject(usuarioAutenticado)),
                                    new Claim(ClaimTypes.Role, usuarioAutenticado.NomePerfil)
                                  }
                        );

                        var handler = new JwtSecurityTokenHandler();

                        DateTime dataCriacao = DateTime.Now;

                        DateTime dataExpiracao = DateTime.Now.AddHours(1);

                        var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                        {
                            Issuer = "MyGamesIssuer",
                            Audience = "MyGamesAudience",
                            SigningCredentials = signingConfigurations.SigningCredentials,
                            Subject = identity,
                            NotBefore = dataCriacao,
                            Expires = dataExpiracao
                        });

                        var token = handler.WriteToken(securityToken);

                        var retorno = new
                        {
                            authenticated = true,
                            created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                            expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                            accessToken = token,
                            message = "OK"
                        };

                        return Ok(retorno);
                    }
                    else
                    {
                        return BadRequest("Acesso negado.");
                    }
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpGet]
        [Authorize]
        [Route("obterdados")]
        public IActionResult GetData()
        {
            try
            {
                var model = JsonConvert.DeserializeObject<UsuarioAutenticadoViewModel>(User.Identity.Name);

                return Ok(model);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}