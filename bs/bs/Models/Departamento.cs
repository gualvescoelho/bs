using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace bs.Models
{
    public class Departamento
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        [MaxLength(50)]
        public string Nome { get; set; }
    }
}
