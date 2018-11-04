using System.Collections.Generic;
using System.Linq;

namespace BookShelfBusinessLogic
{
    /// <summary>
    /// Class containing all methods for data exchange with the database.
    /// Accepts context - either external DB or in memory.
    /// </summary>
    public class LibraryService : ILibraryService
    {
        /// <summary>
        /// Context to be working with.
        /// Containes collections of type DbSet for all models.
        /// </summary>
        private ILibraryContext _db;

        public LibraryService()
        {
        }

        /// <summary>
        /// Initializes new instance of LibraryService.
        /// </summary>
        /// <param name="context">A data context</param>
        public LibraryService(ILibraryContext context)
        {
            _db = context;
        }

        // #####################################
        // ALL METHODS RELATED TO BOOK:
        // #####################################
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
        /// Looks for an instance of book with the specifies Id.
        /// Creates a BookView instance for full representation (includes genres and authors of this book).
        /// </summary>
        /// <param name="id"> Id to look for </param>
        /// <returns> An instance of BookView or null if not found </returns>
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

        /// <summary>
        /// Looks for an instance of book with the specifies Id
        /// and tries to set its properties equal to the book passed as argument, if found.
        /// </summary>
        /// <param name="id"> Id to look for</param>
        /// <param name="book"> An instance of book  to be copied</param>
        /// <returns> True if such book found and updated, false - if not found </returns>
        public bool IsBookUpdated(int id, Book book)
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

        /// <summary>
        /// Tries to add new book to the collection
        /// </summary>
        /// <param name="book"> An instace of book to be added </param>
        /// <returns> True if added, false if such book already exists </returns>
        public bool IsBookAdded(Book book)
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

        /// <summary>
        /// Tries to remove the book with the specified Id from the collection.
        /// Cascade deletes also an entries in BookGenre and BookAuthor tables.
        /// </summary>
        /// <param name="book"> An id of book to be removed </param>
        /// <returns> True if removed, false if such book not found </returns>
        public bool IsBookDeleted(int id)
        {
            Book bookToDelete = _db.Books.FirstOrDefault(b => b.Id == id);

            if (bookToDelete == null)
            {
                return false;
            }
            
            _db.Books.Remove(bookToDelete);
            _db.SaveChanges();

            return true;
        }

        /// <summary>
        /// Tries to add genre to the specified book.
        /// </summary>
        /// <param name="bookId"> Id of book to be updated </param>
        /// <param name="genreId"> Id of genre to be added </param>
        /// <returns> True if updated, false if such genre already added to this book </returns>
        public bool IsGenreToBookAdded(int bookId, int genreId)
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

        /// <summary>
        /// Tries to add author to the specified book.
        /// </summary>
        /// <param name="bookId"> Id of book to be updated </param>
        /// <param name="authorId"> Id of author to be added </param>
        /// <returns> True if updated, false if such author already added to this book or such author or book does not exists </returns>
        public bool IsAuthorToBookAdded(int bookId, int authorId)
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

        /// <summary>
        /// Tries to remove genre from the specified book.
        /// </summary>
        /// <param name="bookId"> Id of book to be updated </param>
        /// <param name="genreId"> Id of genre to be removed </param>
        /// <returns> True if updated, false if such genre has not been added to this book previously </returns>
        public bool IsGenreFromBookRemoved(int bookId, int genreId)
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


        /// <summary>
        /// Tries to remove author from the specified book.
        /// </summary>
        /// <param name="bookId"> Id of book to be updated </param>
        /// <param name="authorId"> Id of author to be removed </param>
        /// <returns> True if updated, false if such author has not been added to this book previously </returns>
        public bool IsAuthorFromBookRemoved(int bookId, int authorId)
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

        /// <summary>
        /// Selects all Books by specified author
        /// </summary>
        /// <param name="authorId">Id of author</param>
        /// <returns>The collection of Books </returns>
        public IEnumerable<Book> GetBooksByAuthor(int authorId)
        {
            IEnumerable<Book> booksByAuthor = from book in _db.Books
                                              join entry in _db.BookAuthor on book.Id equals entry.BookRefId
                                              where entry.AuthorRefId == authorId
                                              select book;

            return booksByAuthor;
        }

        /// <summary>
        /// Selects all Books by specified genre
        /// </summary>
        /// <param name="genreId">Id of genre</param>
        /// <returns>The collection of Books </returns>
        public IEnumerable<Book> GetBooksByGenre(int genreId)
        {
            IEnumerable<Book> booksByGenre = from book in _db.Books
                                             join entry in _db.BookGenre on book.Id equals entry.BookRefId
                                             where entry.GenreRefId == genreId
                                             select book;

            return booksByGenre;
        }

        #endregion
        // #####################################
        // ALL METHODS RELATED TO GENRE:
        // #####################################
        #region GENRES

        /// <summary>
        /// Gets the collection of Genres existing in the database
        /// </summary>
        /// <returns> The collection of Genres (might be empty)</returns>
        public IEnumerable<Genre> GetGenres()
        {
            return _db.Genres;
        }

        /// <summary>
        /// Looks for instance of Genre with the specified Id in the collection
        /// </summary>
        /// <param name="id"> Id of Genre to look for </param>
        /// <returns> An instance of Genre or null if not found </returns>
        public Genre GetGenreById(int id)
        {
            Genre genre = _db.Genres.FirstOrDefault(g => g.Id == id);

            return genre;
        }

        /// <summary>
        /// Adds new Genre to the collection
        /// </summary>
        /// <param name="genre"> Instance of new genre </param>
        /// <returns> True if added, false if such genre already exists in the collection </returns>
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

        /// <summary>
        /// Removes the Genre with specified Id from the collection.
        /// </summary>
        /// <param name="id"> Id of Genre to look for </param>
        /// <returns> True if removed, false if not found </returns>
        public bool DeleteGenre(int id)
        {
            Genre genreToDelete = _db.Genres.FirstOrDefault(g => g.Id == id);
            if (genreToDelete == null)
            {
                return false;
            }

            _db.Genres.Remove(genreToDelete);
            _db.SaveChanges();
            return true;
        }

        #endregion

        // #####################################
        // ALL METHODS RELATED TO AUTHOR:
        // #####################################

        #region AUTHORS

        /// <summary>
        /// Gets the collection of Authors existing in the database
        /// </summary>
        /// <returns> The collection of Authors (might be empty)</returns>
        public IEnumerable<Author> GetAuthors()
        {
            return _db.Authors;
        }

        /// <summary>
        /// Looks for instance of Author with the specified Id in the collection
        /// </summary>
        /// <param name="id"> Id of Author to look for </param>
        /// <returns> An instance of Genre or null if not found </returns>
        public Author GetAuthorById(int id)
        {
            Author author = _db.Authors.FirstOrDefault(a => a.Id == id);

            return author;
        }

        /// <summary>
        /// Adds new Author to the collection
        /// </summary>
        /// <param name="author"> Instance of new author </param>
        /// <returns> True if added, false if such author already exists in the collection </returns>
        public bool AddAuthor(Author author)
        {
            Author existingAuthor = _db.Authors.FirstOrDefault(a => a.Name == author.Name);

            if (existingAuthor == null)
            {
                _db.Authors.Add(author);
                _db.SaveChanges();

                return true;
            }
            return false;
        }

        /// <summary>
        /// Removes the Author with specified Id from the collection.
        /// </summary>
        /// <param name="id"> Id of Author to look for </param>
        /// <returns> True if removed, false if not found </returns>
        public bool DeleteAuthor(int id)
        {
            Author authorToDelete = _db.Authors.FirstOrDefault(a => a.Id == id);

            if (authorToDelete == null)
            {
                return false;
            }

            _db.Authors.Remove(authorToDelete);
            _db.SaveChanges();

            return true;
        }

        #endregion
    }
}