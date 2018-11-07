using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using BookShelfBL;

namespace BookShelf.Controllers
{
    /// <summary>
    /// Class serving as controller for handling the requests related to Books
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        /// <summary>
        /// An instance of business logic class
        /// </summary>
        private readonly ILibrary _library;

        // <summary>
        /// Initializes new instance of BookController
        /// </summary>
        /// <param name="context"> An instance Business Logic class</param>
        public BookController(ILibrary library)
        {
            this._library = library;
        }

        /// <summary>
        /// Handles GET request: .../api/book/
        /// </summary>
        /// <returns>Existing collection of Books</returns>
        [HttpGet]
        public ActionResult<List<Book>> GetAll()
        {
            return _library.GetBooks();
        }

        /// <summary>
        /// Handles GET request: .../api/book/1
        /// </summary>
        /// <returns>The book with the specified Id or NotFound</returns>
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

        /// <summary>
        /// Handles POST request: .../api/book/{instance of book}
        /// </summary>
        /// <param name="book"> Instance of book to be added to the collection </param>
        /// <returns> Id of added Book and instance of that book, or BadRequest if model is not valid </returns>
        [HttpPost]
        public IActionResult Create(Book item)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not valid book");
            }

            _library.AddBook(item);

            return CreatedAtRoute("GetBook", new { id = item.Id }, item);
        }

        /// <summary>
        /// Handles PUT request: .../api/book/1/author/1
        /// Adds Author to Book.
        /// </summary>
        /// <param name="bookId">Id of book to be updated </param>
        /// <param name="authorId">Id of author to be added </param>
        /// <returns> Request result - no content or NotFound</returns>
        [HttpPut("{bookId}/author/{authorId}")]
        public IActionResult Update(int bookId, int authorId)
        {
            var book = _library.GetBookById(bookId);
            var author = _library.GetAuthorById(authorId);

            if (book == null || author == null)
            {
                return NotFound();
            }
            else
            {
                _library.AddAuthorToBook(bookId, authorId);
            }

            return NoContent();
        }

        /// <summary>
        /// Handles PUT request: .../api/book/1/genre/1
        /// Adds Genre to book.
        /// </summary>
        /// <param name="bookId">Id of book to be updated </param>
        /// <param name="genreId">Id of genre to be added </param>
        /// <returns> Request result - no content or NotFound</returns>
        [HttpPut("{bookId}/genre/{genreId}")]
        public IActionResult UpdateGenre(int bookId, int genreId)
        {
            var book = _library.GetBookById(bookId);
            var genre = _library.GetAuthorById(genreId);

            if (book == null || genre == null)
            {
                return NotFound();
            }
            else
            {
                _library.AddGenreToBook(bookId, genreId);
            }

            return NoContent();
        }

        /// <summary>
        /// Handles PUT request: .../api/book/1 + {instance of book}
        /// </summary>
        /// <param name="id">Id of book to be updated </param>
        /// <param name="book">A sample of book to copy the fields to updating one</param>
        /// <returns> NoContent if updated, NotFound if such book does not exist in data source </returns>
        [HttpPut("{id}")]
        public IActionResult Update(int id, Book item)
        {
            var book = _library.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }
            else
            {
                _library.UpdateBook(id, item);
            }

            return NoContent();
        }

        /// <summary>
        /// Handles DELETE request: .../api/book/1
        /// </summary>
        /// <param name="id"> Id of book to be removed </param>
        /// <returns> NoContent if removed or NotFound </returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _library.GetBookById(id);
            if (book == null)
            {
                return NotFound();
            }
            else _library.DeleteBook(id);
        }

        /// <summary>
        /// Handles GET request: .../api/book/1/genre
        /// Gets all books by specified genre
        /// </summary>
        /// <param name="id">Id of genre</param>
        /// <returns>Collection of Books or NotFOund</returns>
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

        /// <summary>
        /// Handles GET request: .../api/book/1/author
        /// Gets all books by specified author
        /// </summary>
        /// <param name="id">Id of author</param>
        /// <returns>Collection of Books or NotFOund</returns>
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