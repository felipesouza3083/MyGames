using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyGames.API.Models.Plataforma
{
    public class PlataformaAtualizacaoViewModel
    {
        [Required(ErrorMessage = "Informe o Id.")]
        public int IdPlataforma { get; set; }

        [Required(ErrorMessage = "Informe o nome.")]
        public string Nome { get; set; }
    }
}
