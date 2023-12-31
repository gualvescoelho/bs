﻿using SQLite;
using System.IO;
using System.Threading.Tasks;
using System.Text;
using bs.Models;
using System.Collections.Generic;
using Xamarin.Forms.Internals;
using System;
using System.Linq;

namespace bs.Services
{
    public class DatabaseHelper
    {
        private readonly SQLiteAsyncConnection db;

        public DatabaseHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<Departamento>();
            db.CreateTableAsync<Sugestao>();
        }

        public Task<int> CreateDepartamento(Departamento departamento)
        {
            return db.InsertAsync(departamento);
        }

        public Task<List<Departamento>>ReadDepartamentos()
        {
            return db.Table<Departamento>().ToListAsync();
        }

        public async Task<bool> isDepartamentos()
        {
            List<Departamento> count = await db.Table<Departamento>().ToListAsync();

            if(count.Count() > 0)
            {
                return true;
            }

            return false;
        }

        public Task<int>UpdateDepartamento(Departamento departamento)
        {
            return db.UpdateAsync(departamento);
        }

        public async Task<int>DeleteDepartamento(Departamento departamento)
        {
            List<Sugestao> Sugestoes = await ReadSugestaos();

            foreach (Sugestao s in Sugestoes)
            {
                if (s.DepartamentoId == departamento.ID)
                    await App.MyDatabase.DeleteSugestao(s);
            }

            return await db.DeleteAsync(departamento);
        }

        public Task<List<Departamento>> SearchDepartamento(string search)
        {
            return db.Table<Departamento>().Where(p => p.Nome.StartsWith(search)).ToListAsync();
        }

        public Task<List<Departamento>> SearchDepartamentoId(int search)
        {
            return db.Table<Departamento>().Where(p => p.ID == search).ToListAsync();
        }

        public Task<int> CreateSugestao(Sugestao Sugestao)
        {
            return db.InsertAsync(Sugestao);
        }

        public Task<List<Sugestao>> ReadSugestaos()
        {
            return db.Table<Sugestao>().ToListAsync();
        }

        public Task<int> UpdateSugestao(Sugestao Sugestao)
        {
            return db.UpdateAsync(Sugestao);
        }

        public Task<int> DeleteSugestao(Sugestao Sugestao)
        {
            return db.DeleteAsync(Sugestao);
        }

        List<Sugestao> auxList = new List<Sugestao>();

        public async Task<List<Sugestao>>SearchSugestao(string search)
        {
            if (search == "")
            {
                return await db.Table<Sugestao>()
                .Where(p => p.Id != 0)
                .ToListAsync();
            }
            else
            {
                auxList.Clear();
                List<Departamento> departamento = await SearchDepartamento(search);

                var sugestoes = await db.Table<Sugestao>()
                    .Where(p => p.Id != 0)
                    .ToListAsync();


                foreach (Sugestao s in sugestoes)
                {

                    foreach (Departamento d in departamento)
                    {
                        if (s.DepartamentoId == d.ID)
                        {
                            auxList.Add(s);
                        }
                    }
                }

                return auxList;
            }
        }
    }
}   
