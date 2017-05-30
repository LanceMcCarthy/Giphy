
using SpiffyGiphy.ViewModels;

using Xamarin.Forms;

namespace SpiffyGiphy.Views
{
    public partial class FavoriteGifDetailPage : ContentPage
    {
        readonly FavoriteGifDetailViewModel vm;

        // Note - The Xamarin.Forms Previewer requires a default, parameterless constructor to render a page.
        public FavoriteGifDetailPage()
        {
            InitializeComponent();
        }

        public FavoriteGifDetailPage(FavoriteGifDetailViewModel viewModel)
        {
            InitializeComponent();

            vm = viewModel;

            BindingContext = vm;
        }
    }
}
