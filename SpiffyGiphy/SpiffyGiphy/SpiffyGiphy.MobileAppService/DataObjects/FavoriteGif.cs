using Microsoft.Azure.Mobile.Server;

namespace SpiffyGiphy.MobileAppService.DataObjects
{
    public class FavoriteGif : EntityData
    {
        public string OriginalUrl { get; set; }
        public string Caption { get; set; }
    }
}