using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProyectoFinal.model;
using SQLite;

namespace ProyectoFinal.data
{
    public class SQLiteHelper
    {
        SQLiteAsyncConnection connection;
        public SQLiteHelper(string dbPath)
        {
            connection = new SQLiteAsyncConnection(dbPath);
            connection.CreateTableAsync<pets>().Wait();
        }
        public Task<int> SavePet(pets pet)
        {
             if(pet.IdPet == 0)
            {
                return connection.InsertAsync(pet);
            }
            else
            {
                return null; 
            }
        }

        //Obtiene información de todas las mascotas.
        public Task<List<pets>> GetAllPets()
        {
            return connection.Table<pets>().ToListAsync();
        }

        //Obtiene información de las mascotas según su número de identificación.
        public Task<pets> GetPetByIdPets(int id)
        {
            return connection.Table<pets>().Where(a => a.IdPet == id).FirstOrDefaultAsync();
        }
    }
}