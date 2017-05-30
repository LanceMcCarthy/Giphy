using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using SpiffyGiphy.Helpers;
using SpiffyGiphy.Models;

namespace SpiffyGiphy.Services
{
    public class GiphyApiService : IDisposable
    {
        private readonly HttpClient client;
        private readonly HttpClientHandler handler;

        

        //private const string ApiRoot = "http://api.giphy.com";
        private const string GifSearchEndpoint = "http://api.giphy.com/v1/gifs/search";
        private const string GetGifByIdEndpoint = "http://api.giphy.com/v1/gifs/";
        private const string GetRandomGifEndpoint = "http://api.giphy.com/v1/gifs/random";
        private const string GetTrendingGifsEndpoint = "http://api.giphy.com/v1/gifs/trending";

        public GiphyApiService()
        {
            handler = new HttpClientHandler();
            if (handler.SupportsAutomaticDecompression)
                handler.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            client = new HttpClient(handler);
        }

        /// <summary>
        /// Search for GIFs using a set of search terms
        /// </summary>
        /// <param name="searchTerm">a URL encoded string</param>
        /// <returns></returns>
        public async Task<GiphyListResultRoot> SearchGiphyAsync(string searchTerm)
        {
            try
            {
                var uri = new Uri($"{GifSearchEndpoint}?q={searchTerm}&api_key={ApiKeys.GiphyApiKey}");

                using (var request = new HttpRequestMessage(HttpMethod.Get, uri))
                using (var response = await client.SendAsync(request))
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<GiphyListResultRoot>(json);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"SearchGiphyAsync Exception: {ex}");
                return null;
            }
        }

        /// <summary>
        /// Get a single random GIF
        /// </summary>
        /// <returns></returns>
        public async Task<GiphyRandomRoot> GetRandomGifAsync()
        {
            try
            {
                var uri = new Uri($"{GetRandomGifEndpoint}?api_key={ApiKeys.GiphyApiKey}");

                using (var request = new HttpRequestMessage(HttpMethod.Get, uri))
                using (var response = await client.SendAsync(request))
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<GiphyRandomRoot>(json);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"SearchGiphyAsync Exception: {ex}");
                return null;
            }
        }

        /// <summary>
        /// Get a random GIF using a search term that limits the result to the topic
        /// </summary>
        /// <param name="limitTerms"></param>
        /// <returns></returns>
        public async Task<GiphyRandomRoot> GetRandomGifAsync(string limitTerms)
        {
            try
            {
                var uri = new Uri($"{GetRandomGifEndpoint}?tag={limitTerms}&api_key={ApiKeys.GiphyApiKey}");

                using (var request = new HttpRequestMessage(HttpMethod.Get, uri))
                using (var response = await client.SendAsync(request))
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<GiphyRandomRoot>(json);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"SearchGiphyAsync Exception: {ex}");
                return null;
            }
        }

        public async Task<GiphyListResultRoot> GetTrendingGifsAsync()
        {
            try
            {
                var uri = new Uri($"{GetTrendingGifsEndpoint}?api_key={ApiKeys.GiphyApiKey}");

                using (var request = new HttpRequestMessage(HttpMethod.Get, uri))
                using (var response = await client.SendAsync(request))
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<GiphyListResultRoot>(json);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"SearchGiphyAsync Exception: {ex}");
                return null;
            }
        }

        public async Task<GiphyListResultRoot> SearchGiphyAsync(int id)
        {
            try
            {
                var uri = new Uri($"{GetGifByIdEndpoint}?id={id}&api_key={ApiKeys.GiphyApiKey}");

                using (var request = new HttpRequestMessage(HttpMethod.Get, uri))
                using (var response = await client.SendAsync(request))
                {
                    var json = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<GiphyListResultRoot>(json);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"SearchGiphyAsync Exception: {ex}");
                return null;
            }
        }

        public void Dispose()
        {
            client?.Dispose();
        }
    }
}
