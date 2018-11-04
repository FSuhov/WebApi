using System;
using System.Collections.Generic;
using System.Text;

namespace BookShelfBusinessLogic
{
    public interface ILibraryService
    {
        IEnumerable<Book> GetBooks();

        /// <summary>
        /// Looks for an instance of book with the specifies Id.
        /// Creates a BookView instance for full representation (includes genres and authors of this book).
        /// </summary>
        /// <param name="id"> Id to look for </param>
        /// <returns> An instance of BookView or null if not found </returns>
        BookView GetBookById(int id);

        /// <summary>
        /// Looks for an instance of book with the specifies Id
        /// and tries to set its properties equal to the book passed as argument, if found.
        /// </summary>
        /// <param name="id"> Id to look for</param>
        /// <param name="book"> An instance of book  to be copied</param>
        /// <returns> True if such book found and updated, false - if not found </returns>
        bool IsBookUpdated(int id, Book book);

        /// <summary>
        /// Tries to add new book to the collection
        /// </summary>
        /// <param name="book"> An instace of book to be added </param>
        /// <returns> True if added, false if such book already exists </returns>
        bool IsBookAdded(Book book);

        /// <summary>
        /// Tries to remove the book with the specified Id from the collection.
        /// Cascade deletes also an entries in BookGenre and BookAuthor tables.
        /// </summary>
        /// <param name="book"> An id of book to be removed </param>
        /// <returns> True if removed, false if such book not found </returns>
        bool IsBookDeleted(int id);

        /// <summary>
        /// Tries to add genre to the specified book.
        /// </summary>
        /// <param name="bookId"> Id of book to be updated </param>
        /// <param name="genreId"> Id of genre to be added </param>
        /// <returns> True if updated, false if such genre already added to this book </returns>
        bool IsGenreToBookAdded(int bookId, int genreId);

        /// <summary>
        /// Tries to add author to the specified book.
        /// </summary>
        /// <param name="bookId"> Id of book to be updated </param>
        /// <param name="authorId"> Id of author to be added </param>
        /// <returns> True if updated, false if such author already added to this book or such author or book does not exists </returns>
        bool IsAuthorToBookAdded(int bookId, int authorId);

        /// <summary>
        /// Tries to remove genre from the specified book.
        /// </summary>
        /// <param name="bookId"> Id of book to be updated </param>
        /// <param name="genreId"> Id of genre to be removed </param>
        /// <returns> True if updated, false if such genre has not been added to this book previously </returns>
        bool IsGenreFromBookRemoved(int bookId, int genreId);

        /// <summary>
        /// Tries to remove author from the specified book.
        /// </summary>
        /// <param name="bookId"> Id of book to be updated </param>
        /// <param name="authorId"> Id of author to be removed </param>
        /// <returns> True if updated, false if such author has not been added to this book previously </returns>
        bool IsAuthorFromBookRemoved(int bookId, int authorId);

        /// <summary>
        /// Selects all Books by specified author
        /// </summary>
        /// <param name="authorId">Id of author</param>
        /// <returns>The collection of Books </returns>
        IEnumerable<Book> GetBooksByAuthor(int authorId);

        /// <summary>
        /// Selects all Books by specified genre
        /// </summary>
        /// <param name="genreId">Id of genre</param>
        /// <returns>The collection of Books </returns>
        IEnumerable<Book> GetBooksByGenre(int genreId);

        // #####################################
        // ALL METHODS RELATED TO GENRE:
        // #####################################

        /// <summary>
        /// Gets the collection of Genres existing in the database
        /// </summary>
        /// <returns> The collection of Genres (might be empty)</returns>
        IEnumerable<Genre> GetGenres();

        /// <summary>
        /// Looks for instance of Genre with the specified Id in the collection
        /// </summary>
        /// <param name="id"> Id of Genre to look for </param>
        /// <returns> An instance of Genre or null if not found </returns>
        Genre GetGenreById(int id);

        /// <summary>
        /// Adds new Genre to the collection
        /// </summary>
        /// <param name="genre"> Instance of new genre </param>
        /// <returns> True if added, false if such genre already exists in the collection </returns>
        bool AddGenre(Genre genre);

        /// <summary>
        /// Removes the Genre with specified Id from the collection.
        /// </summary>
        /// <param name="id"> Id of Genre to look for </param>
        /// <returns> True if removed, false if not found </returns>
        bool DeleteGenre(int id);

        // #####################################
        // ALL METHODS RELATED TO AUTHOR:
        // #####################################

        /// <summary>
        /// Gets the collection of Authors existing in the database
        /// </summary>
        /// <returns> The collection of Authors (might be empty)</returns>
        IEnumerable<Author> GetAuthors();

        /// <summary>
        /// Looks for instance of Author with the specified Id in the collection
        /// </summary>
        /// <param name="id"> Id of Author to look for </param>
        /// <returns> An instance of Genre or null if not found </returns>
        Author GetAuthorById(int id);

        /// <summary>
        /// Adds new Author to the collection
        /// </summary>
        /// <param name="author"> Instance of new author </param>
        /// <returns> True if added, false if such author already exists in the collection </returns>
        bool AddAuthor(Author author);

        /// <summary>
        /// Removes the Author with specified Id from the collection.
        /// </summary>
        /// <param name="id"> Id of Author to look for </param>
        /// <returns> True if removed, false if not found </returns>
        bool DeleteAuthor(int id);
    }
}
