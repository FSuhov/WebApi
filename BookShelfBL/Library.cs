using System;
using System.Collections.Generic;
using System.Text;

namespace BookShelfBL
{
    /// <summary>
    /// Class containing all methods for data exchange with the database.
    /// Creates a temporary set of data to work with.
    /// </summary>
    public class Library : ILibrary
    {
        private List<Book> _books;
        private List<Author> _authors;
        private List<Genre> _genres;

        /// <summary>
        /// Creates new instance of Library, seeding some sample data
        /// </summary>
        public Library()
        {
            _authors = new List<Author>();
            _authors.Add(new Author("Leo Tolstoy"));
            _authors.Add(new Author("Marcel Proust")); 
            _authors.Add(new Author("James Joyce"));
            _authors.Add(new Author("William Shakespeare"));

            this._books = new List<Book>();
            _books.Add(new Book("War and Peace"));
            _books.Add(new Book("Anna Korenina"));
            _books.Add(new Book("Hamlet"));
            _books.Add(new Book("The Odyssey"));
            _books.Add(new Book("Ulysses"));
            _books.Add(new Book("In Search of Lost Time"));
            _books.Add(new Book("The Iliad"));

            this._genres = new List<Genre>();
            _genres.Add(new Genre("Classic"));
            _genres.Add(new Genre("Modern"));
            _genres.Add(new Genre("Ancient"));
        }

        // #####################################
        // ALL METHODS RELATED TO BOOK:
        // #####################################
        #region BOOKS

        /// <summary>
        /// Gets the collection of all Books available in the data source
        /// </summary>
        /// <returns>The collection of Books </returns>
        public List<Book> GetBooks()
        {
            return _books;
        }

        /// <summary>
        /// Adds new book to data source
        /// </summary>
        /// <param name="book">New Book to be added</param>
        /// <returns>Id of added book</returns>
        public int AddBook(Book book)
        {
            _books.Add(book);

            return book.Id;
        }

        /// <summary>
        /// Gets the correct Book instance from the collection
        /// </summary>
        /// <param name="id"> Id of book to look for</param>
        /// <returns> Book instance with specified Id or NULL </returns>
        public Book GetBookById(int id)
        {
            return _books.Find(b => b.Id == id);
        }

        /// <summary>
        /// Updates Book with specified Id in the data source
        /// </summary>
        /// <param name="id"> Id of book to be updated </param>
        /// <param name="book"> Book to copy from </param>
        public void UpdateBook(int id, Book book)
        {
            Book bookToUpdate = _books.Find(b => b.Id == id);

            if (bookToUpdate != null)
            {
                bookToUpdate.Title = book.Title;
                bookToUpdate.AuthorsId = book.AuthorsId;
            }
        }

        /// <summary>
        /// Removes book with specified Id from data source
        /// </summary>
        /// <param name="id">Id of book to look for </param>
        public void DeleteBook(int id)
        {
            Book bookToRemove = _books.Find(b => b.Id == id);
            if (bookToRemove != null)
            {
                _books.Remove(bookToRemove);
            }
        }

        /// <summary>
        /// Tries to add author to book
        /// </summary>
        /// <param name="bookId">Id of book to be updated</param>
        /// <param name="authorId">Id of author to be added</param>
        /// <returns> True if updated, false if author or book not found</returns>
        public bool AddAuthorToBook(int bookId, int authorId)
        {
            Book bookToUpdate = _books.Find(b => b.Id == bookId);
            Author author = _authors.Find(a => a.Id == authorId);

            if (bookToUpdate != null && author != null)
            {
                bookToUpdate.AuthorsId.Add(authorId);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Tries to add genre to book
        /// </summary>
        /// <param name="bookId">Id of book to be updated</param>
        /// <param name="genreId">Id of genre to be added</param>
        /// <returns> True if updated, false if genre or book not found</returns>
        public bool AddGenreToBook(int bookId, int genreId)
        {
            Book bookToUpdate = _books.Find(b => b.Id == bookId);
            Genre genre = _genres.Find(g => g.Id == genreId);

            if (bookToUpdate != null && genre != null)
            {
                bookToUpdate.GenresId.Add(genreId);

                return true;
            }

            return false;
        }

        /// <summary>
        /// Selects Books by specified Genre from data source
        /// </summary>
        /// <param name="genreId">Id of Genre to look for</param>
        /// <returns> Collection of books </returns>
        public List<Book> GetBooksByGenre(int genreId)
        {
            return _books.FindAll(b => b.GenresId.Contains(genreId));
        }

        /// <summary>
        /// Selects Books by specified Author from data source
        /// </summary>
        /// <param name="authorId">Id of Author to look for</param>
        /// <returns> Collection of books </returns>
        public List<Book> GetBooksByAuthor(int authorId)
        {
            return _books.FindAll(b => b.AuthorsId.Contains(authorId));
        }

        #endregion
        // #####################################
        // ALL METHODS RELATED TO GENRE:
        // #####################################
        #region GENRES

        /// <summary>
        /// Gets collection of Genres available in data source
        /// </summary>
        /// <returns> Collection of Genres</returns>
        public List<Genre> GetGenres()
        {
            return _genres;
        }

        /// <summary>
        /// Gets a correct instance of Genre with specified Id
        /// </summary>
        /// <param name="id"> Id of Genre to look for</param>
        /// <returns> Instance of Genre or NULL </returns>
        public Genre GetGenreById(int id)
        {
            return _genres.Find(g => g.Id == id);
        }

        /// <summary>
        /// Adds new Genre to data source
        /// </summary>
        /// <param name="author"> Instance of genre to be added</param>
        /// <returns> Id of added genre</returns>
        public int AddGenre(Genre genre)
        {
            _genres.Add(genre);

            return genre.Id;
        }

        /// <summary>
        /// Tries to remove genre with specified Id from data source
        /// </summary>
        /// <param name="id">Id of author to look for </param>
        /// <returns> True if removed or false if not found</returns>
        public bool DeleteGenre(int id)
        {
            var items = _books.FindAll(b => b.GenresId.Contains(id));

            if (items.Count == 0)
            {
                _genres.Remove(_genres.Find(g => g.Id == id));
                return true;
            }

            return false;
        }

        #endregion

        // #####################################
        // ALL METHODS RELATED TO AUTHOR:
        // #####################################

        #region AUTHORS

        /// <summary>
        /// Gets collection of Authors available in data source
        /// </summary>
        /// <returns> Collection of authors</returns>
        public List<Author> GetAuthors()
        {
            return _authors;
        }

        /// <summary>
        /// Gets a correct instance of author with specified Id
        /// </summary>
        /// <param name="id"> Id of author to look for</param>
        /// <returns> Instance of author or NULL </returns>
        public Author GetAuthorById(int id)
        {
            return _authors.Find(a => a.Id == id);
        }

        /// <summary>
        /// Adds new Author to data source
        /// </summary>
        /// <param name="author"> Instance of author to be added</param>
        /// <returns> Id of added author</returns>
        public int AddAuthor(Author author)
        {
            _authors.Add(author);

            return author.Id;
        }
        
        /// <summary>
        /// Removes author with specified Id from data source
        /// </summary>
        /// <param name="id">Id of author to look for </param>
        public void DeleteAuthor(int id)
        {
            // TODO: Think what to do: either remove books or just remove author.
            // Currently - all books where this Author exists will be deleted.
            Author authorToDelete = _authors.Find(a => a.Id == id);
            if (authorToDelete != null)
            {
                foreach (Book item in _books)
                {
                    item.AuthorsId.Remove(id);
                }

                _authors.Remove(authorToDelete);
            }
        } 
        
        /// <summary>
        /// Updates author with specified Id in data source
        /// </summary>
        /// <param name="id"> Id of author to look for</param>
        /// <param name="author"> Sample of author to copy fields from</param>
        public void UpdateAuthor(int id, Author author)
        {
            Author authorToUpdate = _authors.Find(a => a.Id == id);

            if (authorToUpdate != null)
            {
                authorToUpdate.Name = author.Name;
            }
        }

        #endregion
    }
}