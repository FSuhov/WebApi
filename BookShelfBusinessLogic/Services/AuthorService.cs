using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShelfBusinessLogic.Services
{
    /// <summary>
    /// Class containing all methods for data exchange with the database.
    /// Accepts DataProvider - an object interacting with external DB or with data in memory.
    /// </summary>
    public class AuthorService : IAuthorService
    {
        /// <summary>
        /// Object containing properties for data in database and basic methods for add and delete.
        /// Containes collections of type DbSet and Lists for all models.
        /// </summary>
        private IDataProvider _data;

        /// <summary>
        /// Initializes new instance of AuthorService.
        /// </summary>
        public AuthorService()
        {
        }

        /// <summary>
        /// Initializes new instance of AuthorService.
        /// </summary>
        /// <param name="dataProvider"> Dataprovider. </param>
        public AuthorService(IDataProvider dataProvider)
        {
            _data = dataProvider;
        }

        /// <summary>
        /// Gets the collection of Authors existing in the database.
        /// </summary>
        /// <returns> The collection of Authors (might be empty). </returns>
        public IEnumerable<Author> GetAllAuthors()
        {
            return _data.AuthorsList;
        }

        /// <summary>
        /// Looks for instance of Author with the specified Id in the collection.
        /// </summary>
        /// <param name="id"> Id of Author to look for. </param>
        /// <returns> An instance of Genre or null if not found. </returns>
        public Author GetAuthorById(int id)
        {
            return _data.AuthorsList.FirstOrDefault(a => a.Id == id);
        }

        /// <summary>
        /// Tries to add new Author to the collection.
        /// </summary>
        /// <param name="author"> Instance of new author. </param>
        /// <returns> True if added, false if such author already exists in the collection. </returns>
        public bool AddNewAuthor(Author author)
        {
            Author existingAuthor = _data.AuthorsList.FirstOrDefault(a => a.Name == author.Name);

            if (existingAuthor == null)
            {
                _data.AddAuthor(author);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Tries to update Author with specified Id in the collection.
        /// </summary>
        /// <param name="id"> Id of Author to look for. </param>
        /// <param name="author"> Instance of Author to copy from. </param>
        /// <returns> True if removed, false if not found. </returns>
        public bool UpdateAuthor(int id, Author author)
        {
            Author authorToUpdate = _data.AuthorsList.FirstOrDefault(a => a.Id == id);

            if (authorToUpdate == null)
            {
                return false;
            }

            authorToUpdate.Id = author.Id;
            authorToUpdate.Name = author.Name;
            _data.Save();

            return true;
        }

        /// <summary>
        /// Tries to remove Author with specified Id from the collection.
        /// </summary>
        /// <param name="id"> Id of Author to look for. </param>
        /// <returns> True if removed, false if not found. </returns>
        public bool DeleteAuthor(int id)
        {
            Author authorToRemove = _data.AuthorsList.FirstOrDefault(a => a.Id == id);

            if (authorToRemove == null)
            {
                return false;
            }

            _data.DeleteAuthor(authorToRemove);
            _data.Save();
            return true;
        }

        /// <summary>
        /// Selects all Books by specified author.
        /// </summary>
        /// <param name="authorId">Id of author. </param>
        /// <returns>The collection of Books. </returns>
        public IEnumerable<Book> GetBooksByAuthor(int authorId)
        {
            IEnumerable<Book> booksByAuthor = from book in _data.BooksList
                                              join entry in _data.BooksAuthorsList on book.Id equals entry.BookRefId
                                              where entry.AuthorRefId == authorId
                                              select book;

            return booksByAuthor;
        }        
    }
}
