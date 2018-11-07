using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShelfBusinessLogic.Services
{
    public class BookService : IBookService
    {
        /// <summary>
        /// Object containing properties for data in database and basic methods for add and delete.
        /// Containes collections of type DbSet and Lists for all models.
        /// </summary>
        private IDataProvider _data;

        /// <summary>
        /// Initializes new instance of BookService.
        /// </summary>
        public BookService()
        {
        }

        /// <summary>
        /// Initializes new instance of BookService.
        /// </summary>
        /// <param name="dataProvider"> Dataprovider. </param>
        public BookService(IDataProvider dataProvider)
        {
            _data = dataProvider;
        }


        /// <summary>
        /// Selects all instances of books from  data context collection.
        /// </summary>
        /// <returns>The collection of books. </returns>
        public IEnumerable<Book> GetBooks()
        {
            return _data.BooksList;
        }

        /// <summary>
        /// Looks for an instance of book with the specifies Id.
        /// Creates a BookView instance for full representation (includes genres and authors of this book).
        /// </summary>
        /// <param name="id"> Id to look for. </param>
        /// <returns> An instance of BookView or null if not found. </returns>
        public BookView GetBookById(int id)
        {
            Book book = _data.BooksList.FirstOrDefault(b => b.Id == id);

            if (book != null)
            {
                BookView bookView = new BookView(book, _data);

                return bookView;
            }

            return null;
        }

        /// <summary>
        /// Looks for an instance of book with the specifies Id
        /// and tries to set its properties equal to the book passed as argument, if found.
        /// </summary>
        /// <param name="id"> Id to look for. </param>
        /// <param name="book"> An instance of book  to be copied. </param>
        /// <returns> True if such book found and updated, false - if not found. </returns>
        public bool UpdateBook(int id, Book book)
        {
            Book bookToUpdate = _data.BooksList.First(b => b.Id == id);

            if (bookToUpdate != null)
            {
                bookToUpdate.Title = book.Title;
                _data.Save();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Tries to add new book to the collection.
        /// </summary>
        /// <param name="book"> An instace of book to be added. </param>
        /// <returns> True if added, false if such book already exists. </returns>
        public bool AddBook(Book book)
        {
            Book existingBook = _data.BooksList.FirstOrDefault(b => b.Id == book.Id);

            if (existingBook == null)
            {
                _data.AddBook(book);
                _data.Save();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Tries to remove the book with the specified Id from the collection.
        /// Cascade deletes also an entries in BookGenre and BookAuthor tables.
        /// </summary>
        /// <param name="book"> An id of book to be removed. </param>
        /// <returns> True if removed, false if such book not found. </returns>
        public bool DeleteBook(int id)
        {
            Book bookToDelete = _data.BooksList.FirstOrDefault(b => b.Id == id);

            if (bookToDelete == null)
            {
                return false;
            }

            _data.DeleteBook(bookToDelete);
            _data.Save();

            return true;
        }

        /// <summary>
        /// Tries to add genre to the specified book.
        /// </summary>
        /// <param name="bookId"> Id of book to be updated. </param>
        /// <param name="genreId"> Id of genre to be added. </param>
        /// <returns> True if updated, false if such genre already added to this book. </returns>
        public bool AddGenreToBook(int bookId, int genreId)
        {
            BookGenre bookGenre = new BookGenre { BookRefId = bookId, GenreRefId = genreId };
            BookGenre similarEntry = _data.BooksGenresList.FirstOrDefault(bg => bg.BookRefId == bookId && bg.GenreRefId == genreId);

            if (similarEntry != null)
            {
                return false;
            }

            _data.AddBookGenre(bookGenre);
            _data.Save();

            return true;
        }

        /// <summary>
        /// Tries to add author to the specified book.
        /// </summary>
        /// <param name="bookId"> Id of book to be updated </param>
        /// <param name="authorId"> Id of author to be added </param>
        /// <returns> True if updated, false if such author already added to this book or such author or book does not exists </returns>
        public bool AddAuthorToBook(int bookId, int authorId)
        {
            BookAuthor bookAuthor = new BookAuthor { BookRefId = bookId, AuthorRefId = authorId };
            BookAuthor similarEntry = _data.BooksAuthorsList.FirstOrDefault(ba => ba.BookRefId == bookId && ba.AuthorRefId == authorId);
            if (similarEntry != null)
            {
                return false;
            }

            _data.AddBookAuthor(bookAuthor);
            _data.Save();

            return true;
        }

        /// <summary>
        /// Tries to remove genre from the specified book.
        /// </summary>
        /// <param name="bookId"> Id of book to be updated </param>
        /// <param name="genreId"> Id of genre to be removed </param>
        /// <returns> True if updated, false if such genre has not been added to this book previously </returns>
        public bool RemoveGenreFromBook(int bookId, int genreId)
        {
            BookGenre bookGenreToRemove = _data.BooksGenresList.FirstOrDefault(bg => bg.BookRefId == bookId && bg.GenreRefId == genreId);

            if (bookGenreToRemove == null)
            {
                return false;
            }

            _data.DeleteBookGenre(bookGenreToRemove);
            _data.Save();

            return true;
        }


        /// <summary>
        /// Tries to remove author from the specified book.
        /// </summary>
        /// <param name="bookId"> Id of book to be updated </param>
        /// <param name="authorId"> Id of author to be removed </param>
        /// <returns> True if updated, false if such author has not been added to this book previously </returns>
        public bool RemoveAuthorFromBook(int bookId, int authorId)
        {
            BookAuthor bookAuthorToRemove = _data.BooksAuthorsList.FirstOrDefault(ba => ba.BookRefId == bookId && ba.AuthorRefId == authorId);

            if (bookAuthorToRemove == null)
            {
                return false;
            }

            _data.DeleteBookAuthor(bookAuthorToRemove);
            _data.Save();

            return true;
        }
    }
}
