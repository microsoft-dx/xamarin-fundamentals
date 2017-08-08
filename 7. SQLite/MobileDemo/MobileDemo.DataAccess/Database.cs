using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MobileDemo.DataAccess.Entities;
using Plugin.NetStandardStorage;
using Plugin.NetStandardStorage.Abstractions.Types;
using SQLite;

namespace MobileDemo.DataAccess
{
    public partial class Database
    {
        #region Singleton

        private static Database _instance = null;

        public static Database Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Database();
                }

                return _instance;
            }
        }

        private Database()
        {

        }

        #endregion

        private string DatabasePath = null;

        private void CreateTables()
        {
            using (var dbContext = Database.Instance.GetConnection())
            {
                dbContext.CreateTable<ShoppingItem>();
            }
        }

        public void InitializeDatabase()
        {
            var task = Task.Run(() =>
            {
                var db = CrossStorage.FileSystem.LocalStorage.CreateFile(
                    "xamarin-fundamentals.db",
                    CreationCollisionOption.OpenIfExists);

                return db.FullPath;
            });

            task.Wait();

            this.DatabasePath = task.Result;


            this.CreateTables();
        }

        public SQLiteConnection GetConnection()
        {
            return new SQLiteConnection(this.DatabasePath);
        }
    }
}
