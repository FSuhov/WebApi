using System;
using System.Collections.Generic;
using System.Text;

namespace BookShelfBusinessLogic.Services
{
    public interface IAuthorService
    {
        /// <summary>
        /// Gets the collection of Authors existing in the database. 
        /// </summary>
        /// <returns> The collection of Authors. </returns>
        IEnumerable<Author> GetAllAuthors();

        /// <summary>
        /// Looks for instance of Author with the specified Id in the collection.
        /// </summary>
        /// <param name="id"> Id of Author to look for. </param>
        /// <returns> An instance of Genre or null if not found. </returns>
        Author GetAuthorById(int id);

        /// <summary>
        /// Tries to update Author with specified Id in the collection.
        /// </summary>
        /// <param name="id"> Id of Author to look for. </param>
        /// <param name="author"> Instance of Author to copy from. </param>
        /// <returns> True if removed, false if not found. </returns>
        bool UpdateAuthor(int id, Author author);

        /// <summary>
        /// Tries to add new Author to the collection.
        /// </summary>
        /// <param name="author"> Instance of new author. </param>
        /// <returns> True if added, false if such author already exists in the collection. </returns>
        bool AddNewAuthor(Author author);

        /// <summary>
        /// Tries to remove Author with specified Id from the collection.
        /// </summary>
        /// <param name="id"> Id of Author to look for. </param>
        /// <returns> True if removed, false if not found. </returns>
        bool DeleteAuthor(int id);

        /// <summary>
        /// Selects all Books by specified author
        /// </summary>
        /// <param name="authorId">Id of author</param>
        /// <returns>The collection of Books </returns>
        IEnumerable<Book> GetBooksByAuthor(int id);
    }
}
