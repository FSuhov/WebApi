using System;
using System.Collections.Generic;
using System.Text;

namespace BookShelfBusinessLogic.Services
{
    public interface IBookService
    {
        /// <summary>
        /// Selects all instances of books from  data context collection.
        /// </summary>
        /// <returns>The collection of books. </returns>
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
        /// <param name="id"> Id to look for. </param>
        /// <param name="book"> An instance of book  to be copied. </param>
        /// <returns> True if such book found and updated, false - if not found. </returns>
        bool UpdateBook(int id, Book book);

        /// <summary>
        /// Tries to add new book to the collection.
        /// </summary>
        /// <param name="book"> An instace of book to be added. </param>
        /// <returns> True if added, false if such book already exists. </returns>
        bool AddBook(Book book);

        /// <summary>
        /// Tries to remove the book with the specified Id from the collection.
        /// Cascade deletes also an entries in BookGenre and BookAuthor tables.
        /// </summary>
        /// <param name="book"> An id of book to be removed. </param>
        /// <returns> True if removed, false if such book not found. </returns>
        bool DeleteBook(int id);

        /// <summary>
        /// Tries to add genre to the specified book.
        /// </summary>
        /// <param name="bookId"> Id of book to be updated. </param>
        /// <param name="genreId"> Id of genre to be added. </param>
        /// <returns> True if updated, false if such genre already added to this book. </returns>
        bool AddGenreToBook(int bookId, int genreId);

        /// <summary>
        /// Tries to add author to the specified book.
        /// </summary>
        /// <param name="bookId"> Id of book to be updated. </param>
        /// <param name="authorId"> Id of author to be added. </param>
        /// <returns> True if updated, false if such author already added to this book or such author or book does not exists. </returns>
        bool AddAuthorToBook(int bookId, int authorId);

        /// <summary>
        /// Tries to remove genre from the specified book.
        /// </summary>
        /// <param name="bookId"> Id of book to be updated. </param>
        /// <param name="genreId"> Id of genre to be removed. </param>
        /// <returns> True if updated, false if such genre has not been added to this book previously. </returns>
        bool RemoveGenreFromBook(int bookId, int genreId);

        /// <summary>
        /// Tries to remove author from the specified book.
        /// </summary>
        /// <param name="bookId"> Id of book to be updated. </param>
        /// <param name="authorId"> Id of author to be removed. </param>
        /// <returns> True if updated, false if such author has not been added to this book previously. </returns>
        bool RemoveAuthorFromBook(int bookId, int authorId);
    }
}
