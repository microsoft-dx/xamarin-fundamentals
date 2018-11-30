using DataAccessLayer;
using DataAccessLayer.Entities;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;

namespace MD._05
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<ShoppingItem> ShoppingItems { get; set; }
        private int itemCount;

        //public List<ShoppingItem> ShoppingItemsList { get; set; }

        public MainPage()
        {
            InitializeComponent();

            InitializeItems();
            ContentListView.ItemsSource = ShoppingItems;
        }

        private void InitializeItems()
        {
            //Get the Items From the Database
            this.ShoppingItems = new ObservableCollection<ShoppingItem>(Database.Instance.GetItemsAsync().Result);
            itemCount = ShoppingItems.Count > 0 ? ShoppingItems.Max(x => x.ItemId) + 1 : 0;
        }

        private void AddNewItem(object sender, System.EventArgs e)
        {
            ShoppingItem toAdd = new ShoppingItem(itemCount, $"Item{itemCount++:00}");

            // Let's first Add the item to the database
            Database.Instance.InsertItemAsync(toAdd).Wait();

            this.ShoppingItems.Add(toAdd);

        }

        private void RemoveLastItem(object sender, System.EventArgs e)
        {
            if (itemCount > 0)
            {
                itemCount--;
            }

            if (ShoppingItems.Count > 0)
            {
                ShoppingItem toRemove = ShoppingItems.Last();
                // Let's first remove it from the database
                Database.Instance.DeleteItemAsync(toRemove).Wait();

                this.ShoppingItems.Remove(toRemove);
            }
        }

        private async void ContentListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await App.NavigationMethod.PushAsync(new ItemDescription((ShoppingItem)e.Item));
        }
    }

}