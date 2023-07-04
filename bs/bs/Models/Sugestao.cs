using SQLite;
using System;

namespace bs.Models
{
    public class Sugestao
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get; set; }
        public string Colaborador { get; set; }
        public string Descricao { get; set; }
        public string Justificativa { get; set; }

        public Departamento Departamento { get; set; }
    }
}