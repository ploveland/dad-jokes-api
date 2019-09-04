using System.Threading.Tasks;
using System.Web.Http;
using dadjokes.Models;
using dadjokes.Services;
using Microsoft.AspNetCore.Mvc;

namespace DadJokes.Controllers
{
    [RoutePrefix("api/joke")]
    public class JokeController : ApiController
    {
        // api/joke
        public JokeController()
        {
        }

        JokeService jokeService = new JokeService();

        // GET: get jokes (api/joke)
        [System.Web.Http.HttpGet]
        public async Task<Joke> Get()
        {
            return await jokeService.GetJokeAsync();
        }

        // GET: search for jokes (api/joke/search)
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("search")]
        public async Task<Joke[]> JokeSearch([FromQuery] int pageSize, [FromQuery] string search)
        {
            return await jokeService.SearchJokesAsync(pageSize, search);
        }

        //// GET: api/Jokes/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Jokes
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Jokes/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Jokes/5
        //public void Delete(int id)
        //{
        //}
    }
}