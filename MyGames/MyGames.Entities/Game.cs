using System;
using System.Collections.Generic;
using System.Text;

namespace MyGames.Entities
{
    public class Game
    {
        public int IdGame { get; set; }
        public string Nome { get; set; }
        public int IdStatus { get; set; }
        public int IdPlataforma { get; set; }

        public Plataforma Plataforma { get; set; }
        public Status Status { get; set; }

        public Game()
        {

        }

        public Game(int idGame, string nome, int idStatus, int idPlataforma)
        {
            IdGame = idGame;
            Nome = nome;
            IdStatus = idStatus;
            IdPlataforma = idPlataforma;
        }

        public override string ToString()
        {
            return $"ID: {IdGame}, Nome:{Nome}";
        }
    }
}
