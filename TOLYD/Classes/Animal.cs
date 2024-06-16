using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TOLYD.Classes
{
    public class Animal
    {
        [PrimaryKey, AutoIncrement]
        public int IdAnimal {get;set;}
        public string NomAnimal {get;set;}
        public string Peso {get;set;}
        public string NumMicroChip {get;set;}

        [Ignore]
        public Captura Captura { get; set; }
    }
}
