using System;
using Xamarin.Forms;

namespace MD._01
{
    public partial class MainPage : ContentPage
    {
        // This one of the easiest UX topic
        // We need to think our design to accomodate both left-handed people and right-handed
        // Now think about a design for this page and update the buttons to adapt the UI
        // Adapting the UI to the user means enchanting the UX
        private bool _userIsLeftHanded;

        public MainPage()
        {
            InitializeComponent();
            // We can also add UI elements here
        }

        // WE can do so many thins
        private void ChangeButtonPosition(object sender, EventArgs e)
        {
            _userIsLeftHanded = !_userIsLeftHanded;

            ButtonForEverybody.HorizontalOptions = _userIsLeftHanded ? LayoutOptions.Start : LayoutOptions.End;
        }

        private void ChangeText(object sender, EventArgs e)
        {
            DisplayMessage.Text = _userIsLeftHanded ? "Hi, I have more dexterity in my left hand!" : "Hi, I have more dexterity in my right hand!";
        }
    }
}
