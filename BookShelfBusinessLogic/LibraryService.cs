using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShelfBusinessLogic
{
    /// <summary>
    /// Class containing all methods for data exchange with the database.
    /// Accepts context - either external DB or in memory.
    /// </summary>
    public class LibraryService
    {
        /// <summary>
        /// Context to be working with.
        /// Containes collections of type DbSet for all models.
        /// </summary>
        private LibraryContext _db;

        /// <summary>
        /// Initializes new instance of LibraryService.
        /// </summary>
        /// <param name="context">A data context</param>
        public LibraryService(LibraryContext context)
        {
            _db = context;
        }
                
        #region BOOKS

        /// <summary>
        /// Selects all instances of books from  data context collection
        /// </summary>
        /// <returns>The collection of books </returns>
        public IEnumerable<Book> GetBooks()
        {
            return _db.Books;
        }

        /// <summary>
        /// Looks for an instance of book with the specifies Id
        /// </summary>
        /// <param name="id"> Id to look for </param>
        /// <returns> An instance of book or null if not found </returns>
        public BookView GetBookById(int id)
        {
            Book book =_db.Books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                BookView bookView = new BookView(book, _db);
                return bookView;
            }
            return null;
        }

        public bool UpdateBook(int id, Book book)
        {
            Book bookToUpdate = _db.Books.First(b => b.Id == id);
            if (bookToUpdate != null)
            {
                bookToUpdate.Title = book.Title;
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool AddBook(Book book)
        {
            Book existingBook = _db.Books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook == null)
            {
                _db.Books.Add(book);
                _db.SaveChanges();
                return true;
            }            
            return false;
        }

        public bool DeleteBook(int id)
        {
            Book bookToDelete = _db.Books.FirstOrDefault(b => b.Id == id);
            if (bookToDelete == null)
            {
                return false;
            }
            // TODO: Check are BookGenre and BookAuthor tables entries are cascade deleted.
            _db.Books.Remove(bookToDelete);
            _db.SaveChanges();
            return true;
        }

        public bool AddGenreToBook(int bookId, int genreId)
        {
            BookGenre bookGenre = new BookGenre { BookRefId = bookId, GenreRefId = genreId };
            BookGenre similarEntry = _db.BookGenre.FirstOrDefault(bg => bg.BookRefId == bookId && bg.GenreRefId == genreId);
            if (similarEntry != null)
            {
                return false;
            }
            _db.BookGenre.Add(bookGenre);
            _db.SaveChanges();
            return true;
        }

        public bool AddAuthorToBook(int bookId, int authorId)
        {
            BookAuthor bookAuthor = new BookAuthor { BookRefId = bookId, AuthorRefId = authorId };
            BookAuthor similarEntry = _db.BookAuthor.FirstOrDefault(ba => ba.BookRefId == bookId && ba.AuthorRefId == authorId);
            if (similarEntry != null)
            {
                return false;
            }
            _db.BookAuthor.Add(bookAuthor);
            _db.SaveChanges();
            return true;
        }

        public bool RemoveGenreFromBook(int bookId, int genreId)
        {
            BookGenre bookGenreToRemove = _db.BookGenre.FirstOrDefault(bg => bg.BookRefId == bookId && bg.GenreRefId == genreId);
            if (bookGenreToRemove == null)
            {
                return false;
            }
            _db.BookGenre.Remove(bookGenreToRemove);
            _db.SaveChanges();
            return true;
        }

        public bool RemoveAuthorFromBook(int bookId, int authorId)
        {
            BookAuthor bookAuthorToRemove = _db.BookAuthor.FirstOrDefault(ba => ba.BookRefId == bookId && ba.AuthorRefId == authorId);
            if (bookAuthorToRemove == null)
            {
                return false;
            }
            _db.BookAuthor.Remove(bookAuthorToRemove);
            _db.SaveChanges();
            return true;
        }

        #endregion

        #region GENRES

        public IEnumerable<Genre> GetGenres()
        {
            return _db.Genres;
        }

        public Genre GetGenreById(int id)
        {
            Genre genre = _db.Genres.FirstOrDefault(g => g.Id == id);
            return genre;
        }

        public bool AddGenre(Genre genre)
        {
            Genre existingGenre = _db.Genres.FirstOrDefault(g => g.Name == genre.Name);
            if (existingGenre == null)
            {
                _db.Genres.Add(genre);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        #endregion
    }
}
