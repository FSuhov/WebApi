using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BookShelf.Models;
using BookShelf.LibraryService;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(Book item)
        {
            // TODO: Add model validation

            _library.AddBook(item);
            return CreatedAtRoute("GetBook", new { id = item.Id }, item);
        }

        // ADD AUTHOR TO BOOK
        [HttpPut("{bookId}/author/{authorId}")]
        public IActionResult Update(int bookId, int authorId)
        {
            var book = _library.GetBookById(bookId);
            var author = _library.GetAuthorById(authorId);
            if (book == null || author == null)
            {
                return NotFound();
            }
            else _library.AddAuthorToBook(bookId, authorId);

            return NoContent();
        }

        // ADD GENRE TO BOOK
        [HttpPut("{bookId}/genre/{genreId}")]
        public IActionResult UpdateGenre(int bookId, int genreId)
        {
            var book = _library.GetBookById(bookId);
            var genre = _library.GetAuthorById(genreId);
            if (book == null || genre == null)
            {
                return NotFound();
            }
            else _library.AddGenreToBook(bookId, genreId);

            return NoContent();
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Book item)
        {
            // TODO: Add model validation

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

        [HttpGet("{genreId}/genre", Name = "BooksByGenre")]
        public ActionResult<List<Book>> GetByGenre(int genreId)
        {
            var items = _library.GetBooksByGenre(genreId);
            if (items.Count == 0)
            {
                return NotFound();
            }
            return items;
        }

        [HttpGet("{authorId}/author", Name = "BooksByAuthor")]
        public ActionResult<List<Book>> GetByAuthor(int authorId)
        {
            var items = _library.GetBooksByAuthor(authorId);
            if (items.Count == 0)
            {
                return NotFound();
            }
            return items;
        }
    }
}