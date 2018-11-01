using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShelfBL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShelf.Controllers
{
    /// <summary>
    /// Class serving as controller for handling the requests related to Genres
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        /// <summary>
        /// An instance of business logic class
        /// </summary>
        private readonly ILibrary _library;

        /// <summary>
        /// Initializes new instance of GenreController
        /// </summary>
        /// <param name="context"> An instance of Business Logic class</param>
        public GenreController(ILibrary library)
        {
            this._library = library;
        }

        /// <summary>
        /// Handles GET request: .../api/genre/
        /// </summary>
        /// <returns>Existing collection of Genres</returns>
        [HttpGet]
        public ActionResult<List<Genre>> GetAll()
        {
            return _library.GetGenres();
        }

        /// <summary>
        /// Handles GET request: .../api/genre/1
        /// </summary>
        /// <returns>The genre with the specified Id or NotFound</returns>
        [HttpGet("{id}", Name = "GetGenre")]
        public ActionResult<Genre> GetById(int id)
        {
            var item = _library.GetGenreById(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        /// <summary>
        /// Handles POST request: .../api/genre/{instance of genre}
        /// Adds new Genre to the collection.
        /// </summary>
        /// <param name="genre">An instance of genre to be added</param>
        /// <returns> An added instance id </returns>
        [HttpPost]
        public IActionResult Create(Genre item)
        {
            _library.AddGenre(item);

            return CreatedAtRoute("GetGenre", new { id = item.Id }, item);
        }

        /// <summary>
        /// Handles DELETE request: .../api/genre/1
        /// Removes Genre with the specified Id from the collection
        /// </summary>
        /// <param name="id"> Id of genre to be removed </param>
        /// <returns> NoContent if removed, NotFound or BadRequest </returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var genre = _library.GetGenreById(id);

            if (genre == null)
            {
                return NotFound();
            }
            else
            {
                var result = _library.DeleteGenre(id);
                if (!result)
                {
                    return BadRequest();
                }
            }

            return NoContent();
        }
    }
}