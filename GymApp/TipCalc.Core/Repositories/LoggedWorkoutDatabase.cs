using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GymApp.Core.Model;
using SQLite;

namespace GymApp.Core.Repositories
{
    public class LoggedWorkoutDatabase
    {
        readonly SQLiteAsyncConnection database;

        public LoggedWorkoutDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<LoggedWorkout>().Wait();
        }

        public Task<List<LoggedWorkout>> GetItemsAsync()
        {
            return database.Table<LoggedWorkout>().ToListAsync();
        }

        public Task<LoggedWorkout> GetItemAsync(string id)
        {
            return database.Table<LoggedWorkout>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(LoggedWorkout item)
        {
            return database.InsertOrReplaceAsync(item);
        }

        public Task<int> DeleteItemAsync(LoggedWorkout item)
        {
            return database.DeleteAsync(item);
        }
    }
}
