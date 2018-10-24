using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BookShelf.Models;

namespace BookShelf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly BookContext _context;

        public BookController(BookContext context)
        {
            _context = context;

            if(_context.Books.Count() == 0)
            {
                _context.Books.Add(new Book
                {
                    Title = TestBook.TITLE,
                    Author = TestBook.AUTHOR,
                    Publisher = TestBook.PUBLISHER,
                    Pages = TestBook.PAGES,
                    Year = TestBook.YEAR,
                    ISBN = TestBook.ISBN
                });
                _context.SaveChanges();
            }
        }

        [HttpGet]
        public ActionResult<List<Book>> GetAll()
        {
            return _context.Books.ToList();
        }

        [HttpGet("{id}", Name = "GetBook")]
        public ActionResult<Book> GetById(int id)
        {
            var item = _context.Books.Find(id);
            if(item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();

            return CreatedAtRoute("GetBook", new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Book item)
        {
            var book = _context.Books.Find(id);
            if(book == null)
            {
                return NotFound();
            }

            book.Title = item.Title;
            book.Author = item.Author;
            book.Pages = item.Pages;
            book.Publisher = item.Publisher;
            book.Year = item.Year;
            book.ISBN = item.ISBN;

            _context.Books.Update(book);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = _context.Books.Find(id);
            if(book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            _context.SaveChanges();
            return NoContent();
        }
    }

    public static class TestBook
    {
        public const string TITLE = "War and piece";
        public const string AUTHOR = "Leo Tolstoy";
        public const string PUBLISHER = "PITER LTD";
        public const int PAGES = 1920;
        public const int YEAR = 2010;
        public const string ISBN = "111-2450-9011";
    }
}