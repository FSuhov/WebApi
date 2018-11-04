using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BookShelf.Models;
using BookShelf.BookService;

namespace BookShelf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBook _books;

        public BookController(IBook booklist)
        {
            _books = booklist;
        }

        [HttpGet]
        public ActionResult<List<Book>> GetAll()
        {
            return _books.getAll();
        }

        [HttpGet("{id}", Name = "GetBook")]
        public ActionResult<Book> GetById(int id)
        {
            var item = _books.getOne(id);
            if(item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(Book book)
        {
            int id = _books.Add(book);

            return CreatedAtRoute("GetBook", new { id }, book);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, Book item)
        {
            _books.UpdateBook(id, item);
           
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            
            _books.Delete(id);

            return NoContent();
        }
    }
}