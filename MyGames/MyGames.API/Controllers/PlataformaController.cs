using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGames.API.Models.Plataforma;
using MyGames.Entities;
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
        [Route("cadastrarplataforma")]
        public IActionResult Post([FromBody] PlataformaCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var p = Mapper.Map<Plataforma>(model);

                    repository.Insert(p);

                    return Ok("Plataforma cadastrada com sucesso!");
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

        [HttpPut]
        [Route("atualizarplataforma")]
        public IActionResult Put([FromBody] PlataformaAtualizacaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var p = Mapper.Map<Plataforma>(model);

                    repository.Update(p);

                    return Ok("Plataforma atualizada com sucesso!");
                }
                catch(Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("deletarplataforma/{idPlataforma}")]
        public IActionResult Delete(int idPlataforma)
        {
            try
            {
                var p = repository.FindById(idPlataforma);

                repository.Delete(p);

                return Ok("Plataforma deletada com sucesso!");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("listartodasplataformas")]
        public IActionResult Get()
        {
            try
            {
                List<PlataformaConsultaViewModel> lista = new List<PlataformaConsultaViewModel>();

                foreach(var p in repository.FindAll())
                {
                    var model = Mapper.Map<PlataformaConsultaViewModel>(p);

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
        [Route("listarplataformaporid/{idPlataforma}")]
        public IActionResult GetById(int idPlataforma)
        {
            try
            {
                var p = repository.FindById(idPlataforma);

                var model = Mapper.Map<PlataformaConsultaViewModel>(p);

                return Ok(model);
            }
            catch (Exception e)
            {

                return StatusCode(500, e.Message);
            }
        }
    }
}