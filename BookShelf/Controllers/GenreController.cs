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
    public class GenreController : ControllerBase
    {
        LibraryService _service;

        public GenreController(LibraryContext context)
        {
            _service = new LibraryService(context);
        }

        [HttpGet]
        public ActionResult<List<Genre>> GetAll()
        {
            return _service.GetGenres().ToList();
        }

        [HttpGet("{id}")]
        public ActionResult<Genre> GetById(int id)
        {
            var item = _service.GetGenreById(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }

        [HttpPost]
        public IActionResult Add(Genre genre)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not valid genre");
            }

            if (!_service.AddGenre(genre))
            {
                return BadRequest("Already exist");
            }

            return Created("genre", genre);
        }
    }
}
