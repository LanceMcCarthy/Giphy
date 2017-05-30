using System;

using SpiffyGiphy.Models;
using SpiffyGiphy.ViewModels;

using Xamarin.Forms;

namespace SpiffyGiphy.Views
{
    public partial class FavoriteGifsPage : ContentPage
    {
        FavoriteGifsViewModel vm;

        public FavoriteGifsPage()
        {
            InitializeComponent();

            vm = new FavoriteGifsViewModel();

            BindingContext = vm;
        }

        async void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as FavoriteGif;
            if (item == null)
                return;

            await Navigation.PushAsync(new FavoriteGifDetailPage(new FavoriteGifDetailViewModel(item)));

            // Manually deselect item
            ItemsListView.SelectedItem = null;
        }

        async void AddItem_Clicked(object sender, EventArgs e)
        {
            //await Navigation.PushAsync(new SaveFavoriteGifPage());
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (vm.FavoriteGifs.Count == 0)
                vm.LoadItemsCommand.Execute(null);
        }
    }
}
