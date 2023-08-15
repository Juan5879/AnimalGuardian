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
            db.CreateTableAsync<WikiData>();
            db.CreateTableAsync<ForumContent>();
        }

        //mascotas
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
        public Task<List<pets>> SearchPet(string query)
        {
            return db.Table<pets>().Where(p => p.Name.Contains(query)).ToListAsync();
        }

        //Wiki
        public Task<int> CreateWikiPage(WikiData wiki)
        {
            return db.InsertAsync(wiki);
        }
        public Task<List<WikiData>> ReadWiki()
        {
            return db.Table<WikiData>().ToListAsync();
        }
        public Task<List<WikiData>> SearchWiki(string query)
        {
            return db.Table<WikiData>().Where(p => p.NombreCientifico.Contains(query)).ToListAsync();
        }

        //Foro
        public Task<int> CreateForumPage(ForumContent forumContent)
        {
            return db.InsertAsync(forumContent);
        }
        public Task<List<ForumContent>> ReadForum()
        {
            return db.Table<ForumContent>().ToListAsync();
        }
        public Task<List<ForumContent>> SearchForum(string query)
        {
            return db.Table<ForumContent>().Where(p => p.Title.Contains(query)).ToListAsync();
        }
    }
}
