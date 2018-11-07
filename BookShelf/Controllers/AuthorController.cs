using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BookShelf.Models;
using BookShelf.LibraryService;

namespace BookShelf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly ILibrary _library;

        public AuthorController(ILibrary library)
        {
            this._library = library;
        }

        [HttpGet]
        public ActionResult<List<Author>> GetAll()
        {
            return _library.GetAuthors();
        }

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

        [HttpPost]
        public IActionResult Create(Author item)
        {
            _library.AddAuthor(item);

            return CreatedAtRoute("GetAuthor", new { id = item.Id }, item);
        }

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
