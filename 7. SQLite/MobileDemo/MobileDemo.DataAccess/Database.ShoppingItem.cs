using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MobileDemo.DataAccess.Entities;

namespace MobileDemo.DataAccess
{
    public partial class Database
    {
        public void AddItem(string name)
        {
            using (var dbContext = Database.Instance.GetConnection())
            {
                dbContext.Insert(new ShoppingItem
                {
                    Name = name
                });
            }
        }

        public void DeleteItemById(int id)
        {
            using (var dbContext = Database.Instance.GetConnection())
            {
                var existingItems = dbContext.Query<ShoppingItem>($"SELECT * FROM ShoppingItem WHERE Id = {id}");

                if (existingItems.Any())
                {
                    var toDelete = existingItems
                        .Where(x => x.Id == id)
                        .FirstOrDefault();

                    if (toDelete != null)
                    {
                        dbContext.Delete(toDelete);
                    }
                }
            }
        }

        public IEnumerable<ShoppingItem> LoadItems()
        {
            using (var dbContext = Database.Instance.GetConnection())
            {
                return dbContext.Query<ShoppingItem>($"SELECT * FROM ShoppingItem");
            }
        }
    }
}
