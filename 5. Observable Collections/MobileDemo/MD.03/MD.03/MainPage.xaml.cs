using MD._03.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MD._03
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
            //TODO This will be populated from the database
            List<ShoppingItem> contentForCollection = new List<ShoppingItem>();

            for (int i = 0; i < 5; i++)
            {
                contentForCollection.Add(new ShoppingItem(itemCount, $"Item{itemCount++:00}"));
            }

            this.ShoppingItems = new ObservableCollection<ShoppingItem>(contentForCollection);
        }

        private void AddNewItem(object sender, System.EventArgs e)
        {
            this.ShoppingItems.Add(new ShoppingItem(itemCount, $"Item{itemCount++:00}"));
        }

        private void RemoveLastItem(object sender, System.EventArgs e)
        {
            if (itemCount > 0)
            {
                this.ShoppingItems.RemoveAt(--itemCount);
            }
        }
    }
}
