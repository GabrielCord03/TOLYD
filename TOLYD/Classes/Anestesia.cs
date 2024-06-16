using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TOLYD.Classes
{
    public class Anestesia
    {   
        [PrimaryKey, AutoIncrement]
        public int idAnimalAnestesia { get; set; }
        public string TipoAnestesia { get; set; }
        public string AplicacaoAnestesia { get; set; }
        public string InducaoAnestesia { get; set; }
        public string RetornoAnestesia { get; set; }
        public string TempAnestesia { get; set; }
        public string OBSAnestesia { get; set; }
    }
}
