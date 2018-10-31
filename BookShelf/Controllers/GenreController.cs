﻿using System.Collections.Generic;
using System.Linq;
using BookShelfBusinessLogic;
using Microsoft.AspNetCore.Mvc;

namespace BookShelf.Controllers
{
    /// <summary>
    /// Class serving as controller for handling the requests related to Genres
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        /// <summary>
        /// An instance of business logic class LibraryService
        /// </summary>
        private LibraryService _service;

        /// <summary>
        /// Initializes new instance of GenreController
        /// </summary>
        /// <param name="context"> An instance of Business Logic calss</param>
        public GenreController(LibraryContext context)
        {
            _service = new LibraryService(context);
        }

        /// <summary>
        /// Handles GET request: .../api/genre/
        /// </summary>
        /// <returns>Existing collection of Genres</returns>
        [HttpGet]
        public ActionResult<List<Genre>> GetAll()
        {
            return _service.GetGenres().ToList();
        }

        /// <summary>
        /// Handles GET request: .../api/genre/1
        /// </summary>
        /// <returns>The genre with the specified Id or NotFound</returns>
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

        /// <summary>
        /// Handles POST request: .../api/genre/{instance of genre}
        /// Adds new Genre to the collection.
        /// </summary>
        /// <param name="genre">An instance of genre to be added</param>
        /// <returns> An added instance if added, BadRequest if such Genre already exists or not a valid Genre </returns>
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

        /// <summary>
        /// Handles DELETE request: .../api/genre/1
        /// Removes Genre with the specified Id from the collection
        /// </summary>
        /// <param name="id"> Id of genre to be removed </param>
        /// <returns> NoContent if removed or NotFound </returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_service.DeleteGenre(id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}