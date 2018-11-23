using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BookShelfBusinessLogic
{
    /// <summary>
    /// Represents a data context for exchanging the data between user and database
    /// </summary>
    public class LibraryContext : DbContext, IDataProvider
    {
        /// <summary>
        /// Initializes new instance of LibraryContext
        /// </summary>
        public LibraryContext()
        { }

        /// <summary>
        /// Initializes new instance of LibraryContext using options passed on application launch
        /// in the file Startup.cs
        /// </summary>
        /// /// <param name="options"> An options for connecting to data source </param>
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the collection of Authors using EF models
        /// </summary>
        public DbSet<Author> Authors { get; set; }

        /// <summary>
        /// Gets or sets the collection of Genres using EF models
        /// </summary>
        public DbSet<Genre> Genres { get; set; }

        /// <summary>
        /// Gets or sets the collection of Books using EF models
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Gets or sets the collection of BookAuthor entries using EF models
        /// </summary>
        public DbSet<BookAuthor> BookAuthor { get; set; }

        /// <summary>
        /// Gets or sets the collection of BookGenre entries using EF models
        /// </summary>
        public DbSet<BookGenre> BookGenre { get; set; }


        public List<Genre> GenresList { get => Genres.ToList(); }      

        public List<Author> AuthorsList { get => Authors.ToList(); }

        public List<Book> BooksList { get => Books.ToList(); }

        public List<BookGenre> BooksGenresList { get => BookGenre.ToList(); }

        public List<BookAuthor> BooksAuthorsList { get => BookAuthor.ToList(); }

        public void AddAuthor(Author author)
        {
            Authors.Add(author);
            SaveChanges();
        }

        public void AddBook(Book book)
        {
            Books.Add(book);
            SaveChanges();
        }

        public void AddBookAuthor(BookAuthor ba)
        {
            BookAuthor.Add(ba);
            SaveChanges();
        }

        public void AddBookGenre(BookGenre bg)
        {
            BookGenre.Add(bg);
            SaveChanges();
        }

        public void AddGenre(Genre genre)
        {
            Genres.Add(genre);            
            SaveChanges();
        }

        public void DeleteAuthor(Author author)
        {
            Authors.Remove(author);
        }

        public void DeleteBook(Book book)
        {
            Books.Remove(book);
        }

        public void DeleteBookAuthor(BookAuthor ba)
        {
            BookAuthor.Remove(ba);
        }

        public void DeleteBookGenre(BookGenre bg)
        {
            BookGenre.Remove(bg);
        }

        public void DeleteGenre(Genre genre)
        {
            Genres.Remove(genre);
        }

        public void Save()
        {
            this.SaveChanges();
        }
    }
}
