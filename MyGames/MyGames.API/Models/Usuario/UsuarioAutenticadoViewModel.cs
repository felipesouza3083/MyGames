using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyGames.API.Models.Usuario
{
    public class UsuarioAutenticadoViewModel
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string NomePerfil { get; set; }
        public string Token { get; set; }
    }
}
