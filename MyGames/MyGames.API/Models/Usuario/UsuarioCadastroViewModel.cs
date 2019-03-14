using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyGames.API.Models.Usuario
{
    public class UsuarioCadastroViewModel
    {
        [Required(ErrorMessage = "Informe o nome do usuário.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe o login do usuário.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Informe a senha do usuário.")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Informe a confirmação da senha do usuário.")]
        [Compare("Senha", ErrorMessage = "Senhas não conferem.")]
        public string ConfirmaSenha { get; set; }

        [Required(ErrorMessage = "Informe o perfil do usuário.")]
        public int IdPerfil { get; set; }
    }
}
