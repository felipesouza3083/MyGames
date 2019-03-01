using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyGames.API.Models.Perfil
{
    public class PerfilCadastroViewModel
    {
        [Required(ErrorMessage = "Informe o nome do perfil.")]
        public string Nome { get; set; }
    }
}
