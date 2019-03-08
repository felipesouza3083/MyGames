using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGames.API.Models.Game
{
    public class GameConsultaViewModel
    {
        public int IdGame { get; set; }
        public string Nome { get; set; }
        public string NomePlataforma { get; set; }
        public string DescricaoStatus { get; set; }
    }
}
