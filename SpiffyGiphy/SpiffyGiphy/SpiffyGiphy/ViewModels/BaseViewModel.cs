using SpiffyGiphy.Helpers;
using SpiffyGiphy.Models;
using SpiffyGiphy.Services;

using Xamarin.Forms;

namespace SpiffyGiphy.ViewModels
{
    public class BaseViewModel : ObservableObject
    {
        private bool isBusy = false;
        private string title = string.Empty;
        private GiphyApiService giphyApiService;
        
        public bool IsBusy
        {
            get => isBusy;
            set => SetProperty(ref isBusy, value);
        }

        public string Title
        {
            get => title;
            set => SetProperty(ref title, value);
        }

        public IDataStore<FavoriteGif> FavoritesDataStore => DependencyService.Get<IDataStore<FavoriteGif>>();

        public GiphyApiService GiphyApiService => giphyApiService ?? (giphyApiService = new GiphyApiService());
    }
}

