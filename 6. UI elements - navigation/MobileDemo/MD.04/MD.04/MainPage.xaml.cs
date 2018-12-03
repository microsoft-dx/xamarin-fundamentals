using MD._04.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace MD._04
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<ShoppingItem> ShoppingItems { get; set; }
        private int itemCount;

        //public List<ShoppingItem> ShoppingItemsList { get; set; }

        public MainPage()
        {
            // The source depends on the Platforms
            string imageSource = Device.RuntimePlatform == Device.UWP ? "Assets\\glossy-black-circle-button-md.png" : "glossyblackcirclebuttonmd.png";
            InitializeComponent();

            MainStack.Children.Add(new Image { Source = imageSource });

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

        private async void ContentListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            await App.NavigationMethod.PushAsync(new ItemDescription((ShoppingItem)e.Item));
        }
    }

}