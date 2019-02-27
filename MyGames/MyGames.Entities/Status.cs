using System;
using System.Collections.Generic;
using System.Text;

namespace MyGames.Entities
{
    public class Status
    {
        public int IdStatus { get; set; }
        public string Descricao { get; set; }

        public List<Game> Games { get; set; }

        public Status()
        {

        }

        public Status(int idStatus, string descricao)
        {
            IdStatus = idStatus;
            Descricao = descricao;
        }

        public override string ToString()
        {
            return $"Id: {IdStatus}, Descrição:{Descricao}";
        }
    }
}