using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using NetflixTrackerAPI.Models;

namespace NetflixTrackerAPI.Controllers
{
    public class NetflixMoviesController : ApiController
    {
        // Return every movie in the database
        [HttpGet]
        [Route("api/NetflixMovies")]
        public IEnumerable<Movy> GetAllMovies()
        {
            using (NetflixAPI_DBContext db = new NetflixAPI_DBContext())
            {
                return db.Movies.ToList();
            }
        }

        // Return only a specific movie the user wants by MovieID
        [HttpGet]
        [Route("api/NetflixMovies/{id}")]
        public IHttpActionResult GetMovieById(int id)
        {
            using (NetflixAPI_DBContext db = new NetflixAPI_DBContext())
            {
                var movie = db.Movies.FirstOrDefault(m => m.MovieID == id);

                if (movie == null)
                    return NotFound();

                return Ok(movie);
            }
        }
    }
}
