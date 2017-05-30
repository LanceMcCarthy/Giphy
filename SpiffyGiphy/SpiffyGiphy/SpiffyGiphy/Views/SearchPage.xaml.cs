using System.Linq;
using SpiffyGiphy.Models;
using SpiffyGiphy.ViewModels;
using Telerik.XamarinForms.DataControls.ListView;
using Xamarin.Forms;

namespace SpiffyGiphy.Views
{
    public partial class SearchPage : ContentPage
    {
        private SearchViewModel vm;

        public SearchPage()
        {
            InitializeComponent();

            vm = this.BindingContext as SearchViewModel;
        }

        private async void RadListView_OnItemTapped(object sender, ItemTapEventArgs e)
        {
            var gif = e.Item as Datum;

            if (gif == null)
                return;

            await Navigation.PushAsync(new SaveFavoriteGifPage(gif));

        }
    }
}
