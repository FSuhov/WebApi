using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BookShelfBL;

namespace BookShelf.Controllers
{
    /// <summary>
    /// Class serving as controller for handling the requests related to Genres
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        /// <summary>
        /// An instance of business logic class
        /// </summary>
        private readonly ILibrary _library;

        /// <summary>
        /// Initializes new instance of AuthorController
        /// </summary>
        /// <param name="context"> An instance of Business Logic calss</param>
        public AuthorController(ILibrary library)
        {
            this._library = library;
        }

        // <summary>
        /// Handles GET request: .../api/author/
        /// </summary>
        /// <returns>Existing collection of Authors</returns>
        [HttpGet]
        public ActionResult<List<Author>> GetAll()
        {
            return _library.GetAuthors();
        }

        /// <summary>
        /// Handles GET request: .../api/author/1
        /// </summary>
        /// <returns>The authore with the specified Id or NotFound</returns>
        [HttpGet("{id}", Name = "GetAuthor")]
        public ActionResult<Author> GetById(int id)
        {
            var item = _library.GetAuthorById(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        /// <summary>
        /// Handles POST request: .../api/author/{instance of author}
        /// Adds new Author to the collection.
        /// </summary>
        /// <param name="author">An instance of author to be added</param>
        /// <returns> An added instance if added, BadRequest if such Author already exists or not a valid Author </returns>
        [HttpPost]
        public IActionResult Create(Author item)
        {
            _library.AddAuthor(item);

            return CreatedAtRoute("GetAuthor", new { id = item.Id }, item);
        }

        /// <summary>
        /// Handles PUT request: .../api/1+{auhtor}
        /// </summary>
        /// <param name="id">Id of author to look for</param>
        /// <param name="item">Sample of author to be copied</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Update(int id, Author item)
        {
            var author = _library.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }
            else _library.UpdateAuthor(id, item);

            return NoContent();
        }

        /// <summary>
        /// Handles DELETE request: .../api/author/1
        /// Removes author with the specified Id.
        /// </summary>
        /// <param name="id"> Id of author to be removed </param>
        /// <returns> NoContent if removed or NotFound </returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var author = _library.GetAuthorById(id);
            if (author == null)
            {
                return NotFound();
            }
            else _library.DeleteAuthor(id);

            return NoContent();
        }
    }
}
