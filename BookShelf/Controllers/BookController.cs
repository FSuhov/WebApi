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
        private List<Book> books;

        public BookController()
        {
            if (books == null || books.Count == 0)
            {
                books = new List<Book>();
                books.Add(new Book("War and Piece"));
                books.Add(new Book("Anna Korenina"));
            }
        }

        [HttpGet]
        public ActionResult<List<Book>> GetAll()
        {
            return books;
        }

        [HttpGet("{id}", Name = "GetBook")]
        public ActionResult<Book> GetById(int id)
        {
            var item = books.FirstOrDefault(b => b.Id == id);
            if(item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            books.Add(book);

            return CreatedAtRoute("GetBook", new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Book item)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            book.Title = item.Title;
           
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            books.Remove(book);

            return NoContent();
        }
    }
}