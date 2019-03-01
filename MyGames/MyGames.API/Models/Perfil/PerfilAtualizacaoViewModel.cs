using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyGames.API.Models.Perfil
{
    public class PerfilAtualizacaoViewModel
    {
        [Required(ErrorMessage = "Informe o id do perfil.")]
        public int IdPerfil { get; set; }

        [Required(ErrorMessage = "Informe o nome do perfil.")]
        public string Nome { get; set; }
    }
}
