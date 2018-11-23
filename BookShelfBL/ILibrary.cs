using System;
using System.Collections.Generic;
using System.Text;

namespace BookShelfBL
{
    /// <summary>
    /// Contains a prototypes of all CRUD methods to be implemented in the business logic
    /// </summary>
    public interface ILibrary
    {
        /// <summary>
        /// Gets the collection of all Books available in the data source
        /// </summary>
        /// <returns>The collection of Books </returns>
        List<Book> GetBooks();

        /// <summary>
        /// Gets the correct Book instance from the collection
        /// </summary>
        /// <param name="id"> Id of book to look for</param>
        /// <returns> Book instance with specified Id or NULL </returns>
        Book GetBookById(int id);

        /// <summary>
        /// Updates Book with specified Id in the data source
        /// </summary>
        /// <param name="id"> Id of book to be updated </param>
        /// <param name="book"> Book to copy from </param>
        void UpdateBook(int id, Book book);

        /// <summary>
        /// Adds new book to data source
        /// </summary>
        /// <param name="book">New Book to be added</param>
        /// <returns>Id of added book</returns>
        int AddBook(Book book);

        /// <summary>
        /// Removes book with specified Id from data source
        /// </summary>
        /// <param name="id">Id of book to look for </param>
        void DeleteBook(int id);

        /// <summary>
        /// Gets collection of Authors available in data source
        /// </summary>
        /// <returns> Collection of authors</returns>
        List<Author> GetAuthors();

        /// <summary>
        /// Gets a correct instance of author with specified Id
        /// </summary>
        /// <param name="id"> Id of author to look for</param>
        /// <returns> Instance of author or NULL </returns>
        Author GetAuthorById(int id);

        /// <summary>
        /// Updates author with specified Id in data source
        /// </summary>
        /// <param name="id"> Id of author to look for</param>
        /// <param name="author"> Sample of author to copy fields from</param>
        void UpdateAuthor(int id, Author author);

        /// <summary>
        /// Adds new Author to data source
        /// </summary>
        /// <param name="author"> Instance of author to be added</param>
        /// <returns> Id of added author</returns>
        int AddAuthor(Author author);

        /// <summary>
        /// Removes author with specified Id from data source
        /// </summary>
        /// <param name="id">Id of author to look for </param>
        void DeleteAuthor(int id);

        /// <summary>
        /// Gets collection of Genres available in data source
        /// </summary>
        /// <returns> Collection of Genres</returns>
        List<Genre> GetGenres();

        /// <summary>
        /// Gets a correct instance of Genre with specified Id
        /// </summary>
        /// <param name="id"> Id of Genre to look for</param>
        /// <returns> Instance of Genre or NULL </returns>
        Genre GetGenreById(int id);

        /// <summary>
        /// Adds new Genre to data source
        /// </summary>
        /// <param name="author"> Instance of genre to be added</param>
        /// <returns> Id of added genre</returns>
        int AddGenre(Genre genre);

        /// <summary>
        /// Tries to remove genre with specified Id from data source
        /// </summary>
        /// <param name="id">Id of author to look for </param>
        /// <returns> True if removed or false if not found</returns>
        bool DeleteGenre(int id);

        /// <summary>
        /// Tries to add author to book
        /// </summary>
        /// <param name="bookId">Id of book to be updated</param>
        /// <param name="authorId">Id of author to be added</param>
        /// <returns> True if updated, false if author or book not found</returns>
        bool AddAuthorToBook(int bookId, int authorId);

        /// <summary>
        /// Tries to add genre to book
        /// </summary>
        /// <param name="bookId">Id of book to be updated</param>
        /// <param name="genreId">Id of genre to be added</param>
        /// <returns> True if updated, false if genre or book not found</returns>
        bool AddGenreToBook(int bookId, int genreId);

        /// <summary>
        /// Selects Books by specified Genre from data source
        /// </summary>
        /// <param name="genreId">Id of Genre to look for</param>
        /// <returns> Collection of books </returns>
        List<Book> GetBooksByGenre(int genreId);

        /// <summary>
        /// Selects Books by specified Author from data source
        /// </summary>
        /// <param name="authorId">Id of Author to look for</param>
        /// <returns> Collection of books </returns>
        List<Book> GetBooksByAuthor(int authorId);
    }
}
