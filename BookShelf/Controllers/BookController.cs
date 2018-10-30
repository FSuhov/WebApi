using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShelfBusinessLogic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShelf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        LibraryService _service;

        public BookController(LibraryContext context)
        {
            _service = new LibraryService(context);
        }

        [HttpGet]
        public ActionResult<List<Book>> GetAll()
        {
            return _service.GetBooks().ToList();
        }

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

            return CreatedAtRoute("GetBook", new { id = book.Id }, book);
        }

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
        /// Adds Genre to Book
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
        /// Removes Genre from Book
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
        /// Adds Author to Book
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