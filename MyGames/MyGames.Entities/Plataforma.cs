using System;
using System.Collections.Generic;
using System.Text;

namespace MyGames.Entities
{
    public class Plataforma
    {
        public int IdPlataforma { get; set; }
        public string Nome { get; set; }

        public List<Game> Games { get; set; }

        public Plataforma()
        {

        }

        public Plataforma(int idPlataforma, string nome)
        {
            IdPlataforma = idPlataforma;
            Nome = nome;
        }

        public override string ToString()
        {
            return $"Id:{IdPlataforma}, Nome:{Nome}";
        }
    }
}
