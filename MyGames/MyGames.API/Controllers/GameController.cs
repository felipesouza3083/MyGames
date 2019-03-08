using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyGames.API.Models.Game;
using MyGames.Entities;
using MyGames.Repository.Contracts;

namespace MyGames.API.Controllers
{
    [Route("mygameapi/games")]
    [EnableCors("DefaultPolicy")]
    [Produces("application/json")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameRepository repository;

        public GameController(IGameRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        [Route("cadastrargame")]
        public IActionResult Post(GameCadastroViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var g = Mapper.Map<Game>(model);

                    repository.Insert(g);

                    return Ok("Game cadastrado com sucesso!");
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
        [Route("atualizargame")]
        public IActionResult Put(GameAtualizacaoViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var g = Mapper.Map<Game>(model);

                    repository.Update(g);

                    return Ok("Game cadastrado com sucesso!");
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
        [Route("deletargame/{idGame}")]
        public IActionResult Delete(int idGame)
        {
            try
            {
                repository.Delete(repository.FindById(idGame));

                return Ok("Game deletado com sucesso!");
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        [Route("listargames")]
        public IActionResult Get()
        {
            try
            {
                List<GameConsultaViewModel> lista = new List<GameConsultaViewModel>();

                foreach (var g in repository.FindAll())
                {
                    var model = Mapper.Map<GameConsultaViewModel>(g);

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
        [Route("listargameporid/{idGame}")]
        public IActionResult GetById(int idGame)
        {
            try
            {
                var model = repository.FindById(idGame);

                return Ok(model);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}