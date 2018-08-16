using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GymApp.Core.Model;
using SQLite;

namespace GymApp.Core.Repositories
{
    public class ExcersizeDatabase
    {
        readonly SQLiteAsyncConnection database;

        public ExcersizeDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Excersize>().Wait();
        }

        public Task<List<Excersize>> GetItemsAsync()
        {
            return database.Table<Excersize>().ToListAsync();
        }

        public Task<Excersize> GetItemAsync(string id)
        {
            return database.Table<Excersize>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Excersize item)
        {
            
            //Excersize excersize = (Excersize)item;
            return database.InsertOrReplaceAsync(item);
        }

        public Task<int> SaveLoggedAsExcersizeAsync(LoggedExcersize item)
        {
            Excersize excersize = new Excersize(item);
            //Excersize excersize = (Excersize)item;
            return database.InsertOrReplaceAsync(excersize);
        }

        public Task<int> DeleteItemAsync(Excersize item)
        {
            return database.DeleteAsync(item);
        }
    }
}
