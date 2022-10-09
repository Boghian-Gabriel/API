﻿using System.ComponentModel.DataAnnotations.Schema;

namespace API.Model
{
    public class ActorAdress
    {
        //in baza de data este cheie unica pt tabela in sine dar si FK ce face referire la tab. Actor
        [ForeignKey("Actor")]
        public Guid ActorAdressId { get; set; }

        public string? Adress1 { get; set; }
        public string? Adress2 { get; set; }
        public string? City { get; set; }
        public int ZipCode { get; set; }
        public string? Country { get; set; }

        // 1:1 Actor - ActorAdress
        public virtual Actor? Actor { get; set; }
    }
}
