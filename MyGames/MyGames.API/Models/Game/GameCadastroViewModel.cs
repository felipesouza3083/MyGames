using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyGames.API.Models.Game
{
    public class GameCadastroViewModel
    {
        [Required(ErrorMessage = "Informe o nome do Game.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a Plataforma do Game.")]
        public int IdPlataforma { get; set; }

        [Required(ErrorMessage = "Informe o Status do Game.")]
        public int IdStatus { get; set; }
    }
}
