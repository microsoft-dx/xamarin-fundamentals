using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using DataAccessLayer.Entities;
using SQLite;

namespace DataAccessLayer
{
    public partial class Database
    {
        private static Database database;
        private static SQLiteAsyncConnection _connection;

        public static Database Instance
        {
            get
            {
                if (database == null)
                {
                    database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "ShoppingItem.db3"));
                }

                return database;
            }
        }

        private Database(string dbPath)
        {
            _connection = new SQLiteAsyncConnection(dbPath);
            _connection.CreateTableAsync<ShoppingItem>().Wait();
        }
        public Task<List<ShoppingItem>> GetItemsAsync()
        {
            return _connection.Table<ShoppingItem>().OrderBy(x => x.ItemId).ToListAsync();
        }

        public Task<ShoppingItem> GetItemAsync(int id)
        {
            return _connection.Table<ShoppingItem>().Where(i => i.ItemId == id).FirstOrDefaultAsync();
        }

        public Task<int> InsertItemAsync(ShoppingItem item)
        {
            return _connection.InsertAsync(item);
        }

        public Task<int> DeleteItemAsync(ShoppingItem item)
        {
            return _connection.DeleteAsync(item);
        }
    }
}
