using System;
using System.Diagnostics;
using System.Threading.Tasks;

using SpiffyGiphy.Helpers;
using SpiffyGiphy.Models;
using SpiffyGiphy.Views;

using Xamarin.Forms;

namespace SpiffyGiphy.ViewModels
{
    public class FavoriteGifsViewModel : BaseViewModel
    {
        public ObservableRangeCollection<FavoriteGif> FavoriteGifs { get; set; }
        public Command LoadItemsCommand { get; set; }

        public FavoriteGifsViewModel()
        {
            Title = "Browse";
            FavoriteGifs = new ObservableRangeCollection<FavoriteGif>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            MessagingCenter.Subscribe<SaveFavoriteGifPage, FavoriteGif>(this, "AddItem", async (obj, item) =>
            {
                var fav = item as FavoriteGif;
                FavoriteGifs.Add(fav);
                await FavoritesDataStore.AddItemAsync(fav);
            });
        }

        async Task ExecuteLoadItemsCommand()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                FavoriteGifs.Clear();
                var items = await FavoritesDataStore.GetItemsAsync(true);
                FavoriteGifs.ReplaceRange(items);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                MessagingCenter.Send(new MessagingCenterAlert
                {
                    Title = "Error",
                    Message = "Unable to load items.",
                    Cancel = "OK"
                }, "message");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}