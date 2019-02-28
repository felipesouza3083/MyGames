using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyGames.API.Models.Plataforma
{
    public class PlataformaCadastroViewModel
    {
        [Required(ErrorMessage = "Informe o nome da Plataforma.")]
        public string Nome { get; set; }
    }
}
