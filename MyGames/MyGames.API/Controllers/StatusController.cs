using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGames.API.Models.Status;
using MyGames.Entities;
using MyGames.Repository.Contracts;

namespace MyGames.API.Controllers
{
    [Route("mygameapi/status")]
    [EnableCors("DefaultPolicy")]
    [Produces("application/json")]
    [ApiController]
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository repository;

        public StatusController(IStatusRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        [Route("cadastrarstatus")]
        public IActionResult Post([FromBody] StatusCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var s = Mapper.Map<Status>(model);

                    repository.Insert(s);

                    return Ok("Status cadastrado com sucesso!");
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
        [Route("alterarstatus")]
        public IActionResult Put([FromBody] StatusAtualizacaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var s = Mapper.Map<Status>(model);

                    repository.Update(s);

                    return Ok("Status Alterado com sucesso");
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
        [Route("deletarstatus/{idStatus}")]
        public IActionResult Delete(int idStatus)
        {
            try
            {
                repository.Delete(repository.FindById(idStatus));

                return Ok("Status deletado com sucesso!");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("listarstatus")]
        public IActionResult Get()
        {
            try
            {
                List<StatusConsultaViewModel> lista = new List<StatusConsultaViewModel>();

                foreach(var s in repository.FindAll())
                {
                    var model = Mapper.Map<StatusConsultaViewModel>(s);

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
        [Route("listarstatusporid/{idStatus}")]
        public IActionResult Get(int idStatus)
        {
            try
            {
                var model = Mapper.Map<StatusConsultaViewModel>(repository.FindById(idStatus));

                return Ok(model);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}