namespace SpiffyGiphy.Models
{
    public class FavoriteGif : BaseDataObject
    {
        string originalUrl = string.Empty;
        string caption = string.Empty;

        public FavoriteGif()
        {
            // NOTE : GiphyID is also being used for fav Id
        }

        public string OriginalUrl
        {
            get => originalUrl;
            set => SetProperty(ref originalUrl, value);
        }

        public string Caption
        {
            get => caption;
            set => SetProperty(ref caption, value);
        }
    }
}
