using System;

using SpiffyGiphy.Models;

using Xamarin.Forms;

namespace SpiffyGiphy.Views
{
    public partial class SaveFavoriteGifPage : ContentPage
    {
        public Datum SelectedGif { get; set; }
        
        public SaveFavoriteGifPage(Datum selectedGif)
        {
            InitializeComponent();

            SelectedGif = selectedGif;
            
            BindingContext = this;
        }

        async void Save_Clicked(object sender, EventArgs e)
        {

            var gifToSave = new FavoriteGif
            {
                Id = SelectedGif.Id,
                OriginalUrl = SelectedGif.Url,
                Caption = SelectedGif.Caption
            };

            MessagingCenter.Send(this, "AddItem", gifToSave);
            await Navigation.PopToRootAsync();
        }
    }
}