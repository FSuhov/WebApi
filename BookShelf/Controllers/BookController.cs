using System.Collections.Generic;
using System.Linq;
using BookShelfBusinessLogic;
using BookShelfBusinessLogic.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
        /// An instance of business logic class BookService
        /// </summary>
        private IBookService _service;

        /// <summary>
        /// Initializes new instance of BookController
        /// </summary>
        /// <param name="context"> An instance Business Logic class</param>
        public BookController(IBookService service)
        {
            _service = service;
        }

        /// <summary>
        /// Handles GET request: .../api/book/
        /// </summary>
        /// <returns>Existing collection of Books</returns>
        [Authorize]
        [HttpGet]
        public ActionResult<List<Book>> GetAll()
        {
            return _service.GetBooks().ToList();
        }

        /// <summary>
        /// Handles GET request: .../api/book/1
        /// </summary>
        /// <returns>The book with the specified Id or NotFound</returns>
        [HttpGet("{id}", Name = "GetBook")]
        public ActionResult<BookView> GetById(int id)
        {
            var item = _service.GetBookById(id);
            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        /// <summary>
        /// Handles PUT request: .../api/book/1 + {instance of book - in Body}
        /// </summary>
        /// <param name="id">Id of book to be updated </param>
        /// <param name="book">A sample of book to copy the fields to updating one</param>
        /// <returns> Ok if updated, BadRequest if not valid instance or NotFound </returns>
        [HttpPut("{id}")]
        public IActionResult Update(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not valid book");
            }

            if (!_service.UpdateBook(id, book))
            {
                return NotFound();
            }

            return Ok();
        }

        /// <summary>
        /// Handles POST request: .../api/book/{instance of book}
        /// </summary>
        /// <param name="book"> Instance of book to be added to the collection </param>
        /// <returns> Id of added Book and instance of that book, or BadRequest if model is not valid or if such book already exists </returns>
        [HttpPost]
        public IActionResult Add(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not valid book");
            }

            if (!_service.AddBook(book))
            {
                return BadRequest("Already exist");
            }

            return Created("GetBook", book.Id);
        }

        /// <summary>
        /// Handles DELETE request: .../api/book/1
        /// </summary>
        /// <param name="id"> Id of book to be removed </param>
        /// <returns> NoContent if removed or NotFound </returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_service.DeleteBook(id))
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Handles PUT request: .../api/book/1/genre/1
        /// Adds Genre to book.
        /// </summary>
        /// <param name="bookId">Id of book to be updated </param>
        /// <param name="genreId">Id of genre to be added </param>
        /// <returns> Request result - no content or bad request</returns>
        [HttpPut("{bookId}/genre/{genreId}")]
        public IActionResult AddGenreToBook(int bookId, int genreId)
        {
            if (!_service.AddGenreToBook(bookId, genreId))
            {
                return BadRequest("Invalid data");
            }

            return NoContent();
        }

        /// <summary>
        /// Handles PUT request: .../api/book/1/genre/1/remove
        /// Removes Genre from specified book.
        /// </summary>
        /// <param name="bookId">Id of book to be updated </param>
        /// <param name="genreId">Id of genre to be removed </param>
        /// <returns> Request result - no content or not found</returns>
        [HttpPut("{bookId}/genre/{genreId}/remove")]
        public IActionResult RemoveGenreFromBook(int bookId, int genreId)
        {
            if (!_service.RemoveGenreFromBook(bookId, genreId))
            {
                return NotFound();
            }

            return NoContent();
        }

        /// <summary>
        /// Handles PUT request: .../api/book/1/author/1
        /// Adds Author to Book.
        /// </summary>
        /// <param name="bookId">Id of book to be updated </param>
        /// <param name="authorId">Id of author to be added </param>
        /// <returns> Request result - no content or bad request</returns>
        [HttpPut("{bookId}/author/{authorId}")]
        public IActionResult AddAuthorToBook(int bookId, int authorId)
        {
            if (!_service.AddAuthorToBook(bookId, authorId))
            {
                return BadRequest("Invalid data");
            }

            return NoContent();
        }

        /// <summary>
        /// Handles PUT request: .../api/book/1/author/1/remove
        /// Removes Author from Book
        /// </summary>
        /// <param name="bookId">Id of book to be updated </param>
        /// <param name="authorId">Id of author to be removed </param>
        /// <returns> Request result - no content or not found</returns>
        [HttpPut("{bookId}/author/{genreId}/remove")]
        public IActionResult RemoveAuthorFromBook(int bookId, int authorId)
        {
            if (!_service.RemoveAuthorFromBook(bookId, authorId))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}