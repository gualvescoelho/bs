using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace bs.Models
{
    public class Departamento
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Nome { get; set; }
    }
}
