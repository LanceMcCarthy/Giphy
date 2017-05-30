using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Web.Http;
using Microsoft.Azure.Mobile.Server;
using Microsoft.Azure.Mobile.Server.Authentication;
using Microsoft.Azure.Mobile.Server.Config;
using Owin;

using SpiffyGiphy.MobileAppService.DataObjects;
using SpiffyGiphy.MobileAppService.Models;

namespace SpiffyGiphy.MobileAppService
{
    public partial class Startup
    {
        public static void ConfigureMobileApp(IAppBuilder app)
        {
            HttpConfiguration config = new HttpConfiguration();

            //For more information on Web API tracing, see http://go.microsoft.com/fwlink/?LinkId=620686 
            config.EnableSystemDiagnosticsTracing();

            new MobileAppConfiguration()
                .UseDefaultConfiguration()
                .ApplyTo(config);

            // Use Entity Framework Code First to create database tables based on your DbContext
            Database.SetInitializer(new DatabaseInitializer());

            // To prevent Entity Framework from modifying your database schema, use a null database initializer
            // Database.SetInitializer<templateitemsContext>(null);

            MobileAppSettingsDictionary settings = config.GetMobileAppSettingsProvider().GetMobileAppSettings();

            if (string.IsNullOrEmpty(settings.HostName))
            {
                // This middleware is intended to be used locally for debugging. By default, HostName will
                // only have a value when running in an App Service application.
                app.UseAppServiceAuthentication(new AppServiceAuthenticationOptions
                {
                    SigningKey = ConfigurationManager.AppSettings["SigningKey"],
                    ValidAudiences = new[] { ConfigurationManager.AppSettings["ValidAudience"] },
                    ValidIssuers = new[] { ConfigurationManager.AppSettings["ValidIssuer"] },
                    TokenHandler = config.GetAppServiceTokenHandler()
                });
            }
            app.UseWebApi(config);

        }
    }

    public class DatabaseInitializer : CreateDatabaseIfNotExists<SpiffyGiphyContext>
    {
        protected override void Seed(SpiffyGiphyContext context)
        {
            List<FavoriteGif> items = new List<FavoriteGif>
            {
                new FavoriteGif { Id = Guid.NewGuid().ToString(), OriginalUrl = "First item", Caption="This is a nice description" },
                new FavoriteGif { Id = Guid.NewGuid().ToString(), OriginalUrl = "Second item", Caption="This is a nice description" },
                new FavoriteGif { Id = Guid.NewGuid().ToString(), OriginalUrl = "Third item", Caption="This is a nice description" },
                new FavoriteGif { Id = Guid.NewGuid().ToString(), OriginalUrl = "Fourth item", Caption="This is a nice description" },
                new FavoriteGif { Id = Guid.NewGuid().ToString(), OriginalUrl = "Fifth item", Caption="This is a nice description" },
                new FavoriteGif { Id = Guid.NewGuid().ToString(), OriginalUrl = "Sixth item", Caption="This is a nice description" },
            };

            foreach (FavoriteGif item in items)
            {
                context.Set<FavoriteGif>().Add(item);
            }

            base.Seed(context);
        }
    }
}