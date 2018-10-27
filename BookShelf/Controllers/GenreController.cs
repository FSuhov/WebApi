using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShelf.LibraryService;
using BookShelf.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookShelf.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly ILibrary _library;

        public GenreController(ILibrary library)
        {
            this._library = library;
        }

        [HttpGet]
        public ActionResult<List<Genre>> GetAll()
        {
            return _library.GetGenres();
        }

        [HttpGet("{id}", Name = "GetGenre")]
        public ActionResult<Genre> GetById(int id)
        {
            var item = _library.GetGenreById(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Create(Genre item)
        {
            _library.AddGenre(item);
            return CreatedAtRoute("GetGenre", new { id = item.Id }, item);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var genre = _library.GetGenreById(id);
            if (genre == null)
            {
                return NotFound();
            }
            else
            {
                var result = _library.DeleteGenre(id);
                if (!result)
                {
                    return BadRequest();
                }
            }

            return NoContent();
        }
    }
}