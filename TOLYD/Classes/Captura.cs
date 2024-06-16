using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TOLYD.Classes
{
    public class Captura
    {
        [PrimaryKey, AutoIncrement]
        public int Id {  get; set; }
        public string LocCap { get; set; }
        public string DataCap { get; set; }
        public string Instituicao { get; set; }
        public string Contato { get; set; }
        public string Obs { get; set; }
    }
}
