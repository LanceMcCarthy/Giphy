using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using SpiffyGiphy.Models;

namespace SpiffyGiphy.Services
{
    public class MockDataStore : IDataStore<FavoriteGif>
    {
        bool isInitialized;
        List<FavoriteGif> favoriteGifs;

        public async Task<bool> AddItemAsync(FavoriteGif favoriteGif)
        {
            await InitializeAsync();

            favoriteGifs.Add(favoriteGif);

            return await Task.FromResult(true);
        }

        public async Task<bool> UpdateItemAsync(FavoriteGif favoriteGif)
        {
            await InitializeAsync();

            var item = favoriteGifs.FirstOrDefault(arg => arg.Id == favoriteGif.Id);
            favoriteGifs.Remove(item);
            favoriteGifs.Add(favoriteGif);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteItemAsync(FavoriteGif favoriteGif)
        {
            await InitializeAsync();

            var fav = favoriteGifs.FirstOrDefault(arg => arg.Id == favoriteGif.Id);
            favoriteGifs.Remove(fav);

            return await Task.FromResult(true);
        }

        public async Task<FavoriteGif> GetItemAsync(string id)
        {
            await InitializeAsync();

            return await Task.FromResult(favoriteGifs.FirstOrDefault(s => s.Id == id));
        }

        public async Task<IEnumerable<FavoriteGif>> GetItemsAsync(bool forceRefresh = false)
        {
            await InitializeAsync();

            return await Task.FromResult(favoriteGifs);
        }

        public Task<bool> PullLatestAsync()
        {
            return Task.FromResult(true);
        }


        public Task<bool> SyncAsync()
        {
            return Task.FromResult(true);
        }

        public async Task InitializeAsync()
        {
            if (isInitialized)
                return;

            favoriteGifs = new List<FavoriteGif>();

            var sampleFavs = new List<FavoriteGif>
            {
                new FavoriteGif { Id = "kqtYBttNBE0KI", OriginalUrl = "https://giphy.com/gifs/animation-art-reaction-kqtYBttNBE0KI", Caption=""},
                new FavoriteGif { Id = "3iVCJavgXGpXO", OriginalUrl = "https://giphy.com/gifs/animation-art-design-3iVCJavgXGpXO", Caption=""},
                new FavoriteGif { Id = "3oKIPi0sqqBWi5IR68", OriginalUrl = "https://giphy.com/gifs/love-art-happy-3oKIPi0sqqBWi5IR68", Caption=""}
            };

            foreach (FavoriteGif fav in sampleFavs)
            {
                favoriteGifs.Add(fav);
            }

            isInitialized = true;
        }
    }
}
