using MonkeyCache.FileStore;
using MyDotnetPodcasts.Models;
using MyDotnetPodcasts.Models.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace MyDotnetPodcasts.Services
{
    public class ShowsService
    {
        private readonly HttpClient _httpClient;
        private readonly ListenLaterService _listenLaterService;

        public ShowsService(HttpClient httpClient, ListenLaterService listenLaterService)
        {
            _httpClient=httpClient;
            _listenLaterService=listenLaterService;
        }

        public Task<IEnumerable<Show>> GetShowsAsync()
        {
            return SearchShowsAsync(string.Empty);
        }

        private async Task<IEnumerable<Show>> SearchShowsAsync(string empty)
        {
            var showsResponse = await TryGetAsync<IEnumerable<ShowResponse>>($"shows?limit=10&term={empty}");

            return showsResponse?.Select(r => GetShow(r));
        }

        private Show GetShow(ShowResponse response) => new(response, _listenLaterService);

        private async Task<T> TryGetAsync<T>(string path)
        {
            var json = string.Empty;

#if !MACCATALYST
            if (Connectivity.NetworkAccess == NetworkAccess.None)
                json = Barrel.Current.Get<string>(path);
#endif
            if (!Barrel.Current.IsExpired(path))
                json = Barrel.Current.Get<string>(path);

            T responseData = default;


            try
            {
                if (string.IsNullOrWhiteSpace(json))
                {
                    var response = await _httpClient.GetAsync(path);
                    if (response.IsSuccessStatusCode)
                    {
                        responseData = await response.Content.ReadFromJsonAsync<T>();
                    }
                }
                else
                {
                    responseData = JsonConvert.DeserializeObject<T>(json);
                }

                if (responseData!=null)
                {
                    Barrel.Current.Add(path, responseData, TimeSpan.FromMinutes(10));
                }
            }
            catch (Exception exception)
            {

                Debug.WriteLine(exception);
            }

            return responseData;
        }
    }
}
