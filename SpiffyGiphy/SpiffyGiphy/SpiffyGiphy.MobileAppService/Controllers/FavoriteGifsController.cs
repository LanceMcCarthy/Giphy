using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.OData;
using Microsoft.Azure.Mobile.Server;

using SpiffyGiphy.MobileAppService.DataObjects;
using SpiffyGiphy.MobileAppService.Models;

namespace SpiffyGiphy.MobileAppService.Controllers
{
    // TODO: Uncomment [Authorize] attribute to require user be authenticated to access FavoriteGif(s).
    [Authorize]
    public class FavoriteGifsController : TableController<FavoriteGif>
    {
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            SpiffyGiphyContext context = new SpiffyGiphyContext();
            DomainManager = new EntityDomainManager<FavoriteGif>(context, Request);
        }

        // GET tables/FavoriteGif
        public IQueryable<FavoriteGif> GetAllItems()
        {
            return Query();
        }

        // GET tables/FavoriteGif/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public SingleResult<FavoriteGif> GetItem(string id)
        {
            return Lookup(id);
        }

        // PATCH tables/FavoriteGif/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task<FavoriteGif> PatchItem(string id, Delta<FavoriteGif> patch)
        {
            return UpdateAsync(id, patch);
        }

        // POST tables/FavoriteGif
        public async Task<IHttpActionResult> PostItem(FavoriteGif favoriteGif)
        {
            FavoriteGif current = await InsertAsync(favoriteGif);
            return CreatedAtRoute("Tables", new { id = current.Id }, current);
        }

        // DELETE tables/FavoriteGif/48D68C86-6EA6-4C25-AA33-223FC9A27959
        public Task DeleteItem(string id)
        {
            return DeleteAsync(id);
        }
    }
}