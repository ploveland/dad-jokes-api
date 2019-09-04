using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using dadjokes.Models;
using Newtonsoft.Json.Linq;

namespace dadjokes.Services
{
    public class JokeService
    {
        private const string url = "https://icanhazdadjoke.com";
        HttpClient client = new HttpClient();

        public async Task<Joke> GetJokeAsync()
        {
            Joke joke = null;

            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));


            HttpResponseMessage response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                joke = await response.Content.ReadAsAsync<Joke>();
            }

            return joke;
        }

        public async Task<Joke[]> SearchJokesAsync(int limit, string search)
        {
            Joke[] jokes = null;

            client.BaseAddress = new Uri(url);
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            var searchUrl = url + "/search?page=1&limit=" + limit + "&term=" + search;
            HttpResponseMessage response = await client.GetAsync(searchUrl);

            if (response.IsSuccessStatusCode)
            {
                var msg = response.Content.ReadAsStringAsync();
                JToken token = JObject.Parse(msg.Result);
                jokes = token.SelectToken("results").ToObject<Joke[]>();
            }

            var sortedValues = (jokes
                .Where(x => x.joke.ToLower().Contains(search.ToLower()))
                .OrderBy(x => x.joke.Length).ToArray());

            return jokes;
        }
    }
}