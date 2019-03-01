using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyGames.API.Models.Status
{
    public class StatusAtualizacaoViewModel
    {
        [Required(ErrorMessage = "Informe o id do status.")]
        public int IdStatus { get; set; }

        [Required(ErrorMessage = "Informe a descirção do status.")]
        public string Descricao { get; set; }
    }
}
