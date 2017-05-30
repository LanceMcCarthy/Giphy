using System.Diagnostics;
using System.Threading.Tasks;
using SpiffyGiphy.Models;
using Xamarin.Forms;

namespace SpiffyGiphy.ViewModels
{
    public class SearchViewModel : BaseViewModel
    {
        private string selectedGifVideoUrl;
        private GiphyListResultRoot searchResult;
        private string searchTerms;
        private Command getTrendingCommand;
        private Command searchGifsCommand;
        private bool isGifLoading;
        private Command getRandomCommand;

        public SearchViewModel()
        {
            this.Title = "Search GIFs";
        }

        #region props

        public GiphyListResultRoot SearchResult
        {
            get => searchResult;
            set => SetProperty(ref searchResult, value);
        }

        public string SelectedGifVideoUrl
        {
            get => selectedGifVideoUrl;
            set => SetProperty(ref selectedGifVideoUrl, value);
        }

        public string SearchTerms
        {
            get => searchTerms;
            set => SetProperty(ref searchTerms, value);
        }
        

        public bool IsGifLoading
        {
            get => isGifLoading;
            set => SetProperty(ref isGifLoading, value);
        }

        #endregion

        #region commands
        public Command SearchGifsCommand => searchGifsCommand ?? (searchGifsCommand = new Command(async () =>
        {
            SearchResult = null;
            SelectedGifVideoUrl = null;
            await SearchGiphy(SearchTerms);
        }));

        public Command GetTrendingCommand => getTrendingCommand ?? (getTrendingCommand = new Command(async () =>
        {
            SearchResult = null;
            SelectedGifVideoUrl = null;
            await GetTrendingGifs();
        }));

        public Command GetRandomCommand => getRandomCommand ?? (getRandomCommand = new Command(async () =>
        {
            SearchResult = null;
            SelectedGifVideoUrl = null;
            await GetRandomGif(SearchTerms);
        }));

        #endregion

        #region methods

        public async Task SearchGiphy(string searchTerm)
        {
            IsBusy = true;
            var encodedSearchTerms = System.Net.WebUtility.UrlEncode(searchTerm);
            Debug.WriteLine($"Encoded search term: {encodedSearchTerms}");
            SearchResult = await GiphyApiService.SearchGiphyAsync(encodedSearchTerms);
            IsBusy = false;
        }

        public async Task GetRandomGif(string limitingTerms = "")
        {
            IsBusy = true;
            GiphyRandomRoot root;

            if (string.IsNullOrEmpty(limitingTerms))
            {
                root = await GiphyApiService.GetRandomGifAsync();
            }
            else
            {
                root = await GiphyApiService.GetRandomGifAsync(limitingTerms);
            }

            SelectedGifVideoUrl = root?.Data?.ImageMp4Url;
            IsBusy = false;

            //because there's no list selection handler for a single GIf, I need to trip this now
            IsGifLoading = true;
        }

        public async Task GetTrendingGifs()
        {
            IsBusy = true;
            SearchResult = await GiphyApiService.GetTrendingGifsAsync();
            IsBusy = false;
        }

        #endregion
    }
}
