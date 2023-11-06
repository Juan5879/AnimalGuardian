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
            db.CreateTableAsync<User>();
            db.CreateTableAsync<Notification>();
        }

        //Usuario
        public Task<User> GetUserById(int userId)
        {
            return db.Table<User>().Where(u => u.IdUserLocal == userId).FirstOrDefaultAsync();
        }

        public Task<int> SaveUser(User user)
        {
            return db.InsertAsync(user);
        }
        public Task<int> DeleteUser(User user)
        {
            return db.DeleteAsync(user);
        }


        //mascotas
        public async Task<int> CreatePet (pets pet)
        {
            return await db.InsertAsync(new pets { IdPet = Guid.NewGuid(), Name = pet.Name, Description = pet.Description });
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
            return db.Table<WikiData>().Where(p => p.Name.Contains(query)).ToListAsync();
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

        //Notification
        public Task<int> CreateNotification(Notification notification)
        {
            return db.InsertAsync(notification);
        }
        public Task<List<Notification>> ReadNotification()
        {
            return db.Table<Notification>().ToListAsync();
        }
        public Task<int> UpdateNotification(Notification notification)
        {
            return db.UpdateAsync(notification);
        }
        public Task<int> DeleteNotification(Notification notification)
        {
            return db.DeleteAsync(notification);
        }
    }
}
