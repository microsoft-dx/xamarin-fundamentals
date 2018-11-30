using DataAccessLayer.Entities;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MD._05
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemDescription : ContentPage
    {
        public ItemDescription(ShoppingItem itemToPresent)
        {
            InitializeComponent();

            ItemStack.Children.Add(new Label { Text = $"My id is {itemToPresent.ItemId: 00}" });
            ItemStack.Children.Add(new Label { Text = $"My description is {itemToPresent.ItemName}" });
        }

        private async void GoBack(object sender, System.EventArgs e)
        {
            await App.NavigationMethod.PopAsync();
        }
    }
}