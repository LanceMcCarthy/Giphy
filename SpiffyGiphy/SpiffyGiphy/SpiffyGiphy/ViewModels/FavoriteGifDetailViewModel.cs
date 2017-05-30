using SpiffyGiphy.Models;

namespace SpiffyGiphy.ViewModels
{
    public class FavoriteGifDetailViewModel : BaseViewModel
    {
        public FavoriteGif FavoriteGif { get; set; }

        public FavoriteGifDetailViewModel(FavoriteGif favoriteGif = null)
        {
            Title = favoriteGif?.Caption ?? "Null";
            FavoriteGif = favoriteGif;
        }
        
    }
}