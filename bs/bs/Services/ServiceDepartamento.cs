using bs.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace bs.Services
{
    public class ServiceDepartamento
    {
        // Em algum lugar do seu código, você pode usar o banco de dados
        public void CreateOrInsert(Departamento Departamento)
        {
            var connection = DatabaseHelper.GetConnection("departamento");

            // verificar se ja existe banco e ...
            // if (connection.GetTableInfo())
            connection.CreateTable<Departamento>();

            // Inserir dados
            connection.Insert(Departamento);

            Console.WriteLine("a");
        }

        public List<Departamento> listDepartamentos()
        {
            var connection = DatabaseHelper.GetConnection("departamento");

            var departamentos = connection.Table<Departamento>().ToList();

            foreach (var p in departamentos)
            {
                Console.WriteLine($"Nome: {p.Nome}, Departamento: {p.ID}");
            }

            return departamentos;
        }
    }
}
