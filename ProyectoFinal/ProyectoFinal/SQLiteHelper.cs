using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using ProyectoFinal.model;

namespace ProyectoFinal
{
    public class SQLiteHelper
    {
        private readonly SQLiteAsyncConnection db;
        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<pets>();
        }
        public Task<int> CreatePet (pets pet)
        {
            return db.InsertAsync(pet);
        }
        public Task<List<pets>> ReadPets()
        {
            return db.Table<pets>().ToListAsync();
        }
        public Task<int> UpdatePet (pets pet)
        {
            return db.UpdateAsync(pet);
        }
        public Task<int> DeletePet (pets pet)
        {
            return db.DeleteAsync(pet);
        }
    }
}
