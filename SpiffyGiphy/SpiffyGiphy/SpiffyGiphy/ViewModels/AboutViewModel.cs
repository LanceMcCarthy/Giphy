using System;
using System.Windows.Input;
using Xamarin.Forms;

namespace SpiffyGiphy.ViewModels
{
    public class AboutViewModel : BaseViewModel
    {
        public AboutViewModel()
        {
            Title = "About";

            OpenWebCommand = new Command(() => Device.OpenUri(new Uri("https://winplatform.wordpress.com/")));
        }

        /// <summary>
        /// Command to open browser to xamarin.com
        /// </summary>
        public ICommand OpenWebCommand { get; }
    }
}
