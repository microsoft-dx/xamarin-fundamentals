using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using MobileDemo.DataAccess;
using MobileDemo.Helpers;
using MobileDemo.Models;
using Xamarin.Forms;

namespace MobileDemo
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<ShoppingItem> ShoppingItems { get; set; }

        public MainPage()
        {
            InitializeComponent();
            InitializeItems();

            contentListView.ItemsSource = ShoppingItems;
        }

        private void InitializeItems()
        {
            var data = Database.Instance.LoadItems()
                .Select(x => x.ToModel());

            this.ShoppingItems = new ObservableCollection<ShoppingItem>(data);
        }

        private async void contentListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var alertResult = await DisplayAlert("Delete warning", "Do you really want to delete?", "YES", "NO");

            if (!alertResult)
            {
                return;
            }

            var item = (sender as ListView).SelectedItem as ShoppingItem;

            Database.Instance.DeleteItemById(item.ItemId);

            this.ShoppingItems.RemoveAt(this.ShoppingItems.IndexOf(item));
        }

        private void addNewItem_button_Clicked(object sender, System.EventArgs e)
        {
            Navigation.PushAsync(new NewItem());
        }

        protected override void OnAppearing()
        {
            InitializeItems();

            contentListView.ItemsSource = ShoppingItems;

            base.OnAppearing();
        }
    }
}
