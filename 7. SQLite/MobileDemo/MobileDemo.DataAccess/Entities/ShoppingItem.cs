using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace MobileDemo.DataAccess.Entities
{
    public class ShoppingItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            return this.Name;
        }

        public override bool Equals(object obj)
        {
            var item = obj as ShoppingItem;

            return item.Name == this.Name;
        }
    }
}
