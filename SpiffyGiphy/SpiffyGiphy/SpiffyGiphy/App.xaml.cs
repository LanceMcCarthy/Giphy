using System.Collections.Generic;

using SpiffyGiphy.Helpers;
using SpiffyGiphy.Services;
using SpiffyGiphy.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace SpiffyGiphy
{
    public partial class App : Application
    {
        //MUST use HTTPS, neglecting to do so will result in runtime errors on iOS
        public static bool AzureNeedsSetup => AzureMobileAppUrl == "https://CONFIGURE-THIS-URL.azurewebsites.net";
        public static string AzureMobileAppUrl = "https://SpiffyGiphy.azurewebsites.net";
        public static IDictionary<string, string> LoginParameters => null;

        public static TabbedPage RootTabbedPage;

        public App()
        {
            InitializeComponent();

            if (AzureNeedsSetup)
                DependencyService.Register<MockDataStore>();
            else
                DependencyService.Register<AzureDataStore>();

            SetMainPage();
        }

        public static void SetMainPage()
        {
            if (!AzureNeedsSetup && !Settings.IsLoggedIn)
            {
                Current.MainPage = new NavigationPage(new LoginPage())
                {
                    BarBackgroundColor = (Color)Current.Resources["Primary"],
                    BarTextColor = Color.White
                };
            }
            else
            {
                GoToMainPage();
            }
        }

        public static void GoToMainPage()
        {
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new SearchPage())
                    {
                        Title = "Search",
                        Icon = "tab_feed.png"
                    },
                    //new NavigationPage(new FavoriteGifsPage())
                    //{
                    //    Title = "Browse",
                    //    Icon = "tab_feed.png"
                    //}
                    new NavigationPage(new AboutPage())
                    {
                        Title = "About",
                        Icon = Device.OnPlatform("tab_about.png",null,null)
                    },
                }
            };

            RootTabbedPage = Current.MainPage as TabbedPage;
        }
    }
}
