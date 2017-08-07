using System.Collections.Generic;
using System.Collections.ObjectModel;
using MobileDemo.Models;
using Xamarin.Forms;

namespace MobileDemo
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<ShoppingItem> ShoppingItems { get; set; }

        //public List<ShoppingItem> ShoppingItemsList { get; set; }

        public MainPage()
        {
            InitializeComponent();
            InitializeItems();

            contentListView.ItemsSource = ShoppingItems;
            //contentListView.ItemsSource = ShoppingItemsList;
        }

        private void InitializeItems()
        {
            //TODO This will be populated from the database
            var contentForCollection = new List<ShoppingItem>
            {
                new ShoppingItem { ItemId = 1, ItemName = "item1"},
                new ShoppingItem { ItemId = 2, ItemName = "item2"},
                new ShoppingItem { ItemId = 3, ItemName = "item3"},
                new ShoppingItem { ItemId = 4, ItemName = "item4"}
            };

            //var contentForList = new List<ShoppingItem>
            //{
            //    new ShoppingItem { ItemId = 1, ItemName = "item1"},
            //    new ShoppingItem { ItemId = 2, ItemName = "item2"},
            //    new ShoppingItem { ItemId = 3, ItemName = "item3"},
            //    new ShoppingItem { ItemId = 4, ItemName = "item4"}
            //};

            this.ShoppingItems = new ObservableCollection<ShoppingItem>(contentForCollection);
            //this.ShoppingItemsList = contentForList;
        }

        private void contentListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var item = (sender as ListView).SelectedItem as ShoppingItem;

            this.ShoppingItems.RemoveAt(this.ShoppingItems.IndexOf(item));
            //this.ShoppingItemsList.RemoveAt(this.ShoppingItemsList.IndexOf(item));
        }
    }
}
