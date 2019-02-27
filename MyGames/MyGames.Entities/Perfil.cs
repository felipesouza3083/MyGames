using System;
using System.Collections.Generic;

namespace MyGames.Entities
{
    public class Perfil
    {
        public int IdPerfil { get; set; }
        public string Nome { get; set; }

        public List<Usuario> Usuarios { get; set; }

        public Perfil()
        {

        }

        public Perfil(int idPerfil, string nome)
        {
            IdPerfil = idPerfil;
            Nome = nome;
        }

        public override string ToString()
        {
            return $"Id do Perfil: {IdPerfil}, Nome:{Nome}";
        }
    }
}
