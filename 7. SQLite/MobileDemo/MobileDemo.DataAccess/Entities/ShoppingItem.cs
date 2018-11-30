using System.Collections.Generic;
using SQLite;

namespace DataAccessLayer.Entities
{
    public class ShoppingItem
    {
        [PrimaryKey, AutoIncrement]
        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public override string ToString()
        {
            return this.ItemName;
        }

        public override bool Equals(object obj)
        {
            var item = obj as ShoppingItem;

            return item.ItemName == this.ItemName;
        }

        public override int GetHashCode()
        {
            var hashCode = -1919740922;
            hashCode = hashCode * -1521134295 + ItemId.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ItemName);
            return hashCode;
        }

        public ShoppingItem(int id, string name)
        {
            ItemId = id;
            ItemName = name;
        }

        public ShoppingItem() { }
    }
}
