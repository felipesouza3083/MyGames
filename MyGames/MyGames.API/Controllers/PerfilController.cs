using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGames.API.Models.Perfil;
using MyGames.Entities;
using MyGames.Repository.Contracts;

namespace MyGames.API.Controllers
{
    [Route("mygameapi/perfil")]
    [EnableCors("DefaultPolicy")]
    [Produces("application/json")]
    [ApiController]
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilRepository repository;

        public PerfilController(IPerfilRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        [Route("cadastrarperfil")]
        public IActionResult Post([FromBody] PerfilCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var p = Mapper.Map<Perfil>(model);

                    repository.Insert(p);

                    return Ok("Perfil cadastrado com sucesso!");
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

        [HttpPut]
        [Route("atualizarperfil")]
        public IActionResult Put([FromBody] PerfilAtualizacaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var p = Mapper.Map<Perfil>(model);

                    repository.Update(p);

                    return Ok("Perfil atualizado com sucesso!");
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

        [HttpDelete]
        [Route("deletarperfil/{idPerfil}")]
        public IActionResult Delete(int idPerfil)
        {
            try
            {
                repository.Delete(repository.FindById(idPerfil));

                return Ok("Perfil excluído com sucesso!");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("listarperfis")]
        public IActionResult Get()
        {
            try
            {
                List<PerfilConsultaViewModel> lista = new List<PerfilConsultaViewModel>();

                foreach (var p in repository.FindAll())
                {
                    var model = Mapper.Map<PerfilConsultaViewModel>(p);

                    lista.Add(model);
                }

                return Ok(lista);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("listarperfilporid/{idPerfil}")]
        public IActionResult GetById(int idPerfil)
        {
            try
            {
                var p = repository.FindById(idPerfil);

                if (p != null)
                {
                    var model = Mapper.Map<PerfilConsultaViewModel>(p);

                    return Ok(model);
                }
                else
                {
                    return NotFound($"Não foi encontrado nenhum perfil com o ID:{idPerfil}");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}