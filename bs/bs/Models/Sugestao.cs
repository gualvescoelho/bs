using SQLite;
using System;
using System.Diagnostics.Contracts;

namespace bs.Models
{
    public class Sugestao
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string NomeColaborador { get; set; }

        public int DepartamentoId { get; set; }

        public string Descricao { get; set; }

        public string Justificativa { get; set; }
    }
}