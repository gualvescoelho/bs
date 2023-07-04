using bs.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace bs.Services
{
    internal class Servicesugestao
    {
        // Em algum lugar do seu código, você pode usar o banco de dados
        public void CreateOrInsert(Sugestao sugestao)
        {
            var connection = DatabaseHelper.GetConnection("sugestao");

            // verificar se ja existe banco e ...
            // if (connection.GetTableInfo())
            connection.CreateTable<Sugestao>();

            connection.Insert(sugestao);

        }

        public List<Sugestao> listSugestoes()
        {
            var connection = DatabaseHelper.GetConnection("sugestao");

            var sugestoes = connection.Table<Sugestao>().ToList();
            foreach (var p in sugestoes)
            {
                Console.WriteLine($"Nome: {p.Colaborador}, Departamento: {p.Departamento}, {p.Descricao}, {p.Justificativa}");
            }

            return sugestoes;
        }
    }
}
