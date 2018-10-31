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
    public class AuthorController : ControllerBase
    {
        /// <summary>
        /// An instance of business logic class LibraryService
        /// </summary>
        private LibraryService _service;

        /// <summary>
        /// Initializes new instance of AuthorController
        /// </summary>
        /// <param name="context"> An instance of Business Logic calss</param>
        public AuthorController(LibraryContext context)
        {
            _service = new LibraryService(context);
        }

        // <summary>
        /// Handles GET request: .../api/author/
        /// </summary>
        /// <returns>Existing collection of Authors</returns>
        [HttpGet]
        public ActionResult<List<Author>> GetAll()
        {
            return _service.GetAuthors().ToList();
        }

        /// <summary>
        /// Handles GET request: .../api/author/1
        /// </summary>
        /// <returns>The authore with the specified Id or NotFound</returns>
        [HttpGet("{id}")]
        public ActionResult<Author> GetById(int id)
        {
            var item = _service.GetAuthorById(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        /// <summary>
        /// Handles POST request: .../api/author/{instance of genre}
        /// Adds new Author to the collection.
        /// </summary>
        /// <param name="author">An instance of author to be added</param>
        /// <returns> An added instance if added, BadRequest if such Author already exists or not a valid Genre </returns>
        [HttpPost]
        public IActionResult Add(Author author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Not valid genre");
            }

            if (!_service.AddAuthor(author))
            {
                return BadRequest("Already exist");
            }

            return Created("author", author);
        }

        /// <summary>
        /// Handles DELETE request: .../api/author/1
        /// Removes author with the specified Id.
        /// </summary>
        /// <param name="id"> Id of author to be removed </param>
        /// <returns> NoContent if removed or NotFound </returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            if (!_service.DeleteAuthor(id))
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}