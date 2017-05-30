using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SpiffyGiphy.MobileAppService.Startup))]

namespace SpiffyGiphy.MobileAppService
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureMobileApp(app);
        }
    }
}