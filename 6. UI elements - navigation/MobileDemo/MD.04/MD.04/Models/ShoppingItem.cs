namespace MD._04.Models
{
    public class ShoppingItem
    {
        public ShoppingItem(int givenID, string givenName)
        {
            this.ItemId = givenID;
            this.ItemName = givenName;
        }

        public int ItemId { get; set; }

        public string ItemName { get; set; }
    }
}
