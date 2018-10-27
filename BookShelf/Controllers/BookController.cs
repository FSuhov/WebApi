using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BookShelf.Models;
using BookShelf.LibraryService;

namespace BookShelf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly ILibrary _library;

        public BookController(ILibrary library)
        {
            this._library = library;
        }

        [HttpGet]
        public ActionResult<List<Book>> GetAll()
        {
            return _library.GetBooks();
        }

        [HttpGet("{id}", Name = "GetBook")]
        public ActionResult<Book> GetById(int id)
        {
            var item = _library.GetBookById(id);
            if(item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(Book item)
        {
            _library.AddBook(item);

            return CreatedAtRoute("GetBook", new { id = item.Id }, item);
        }

        [HttpPut("{bookId}/{authorId}")]
        public IActionResult Update(int bookId, int authorId)
        {
            var book = _library.GetBookById(bookId);
            var author = _library.GetAuthorById(authorId);
            if (book == null || author == null)
            {
                return NotFound();
            }
            else _library.UpdateBook(bookId, authorId);

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Book item)
        {
            var book = _library.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            else _library.UpdateBook(id, item);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _library.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            else _library.DeleteBook(id);

            return NoContent();
        }
    }
}