using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BookShelfBusinessLogic
{
    /// <summary>
    /// Represents a data context for exchanging the data between user and database
    /// </summary>
    public class LibraryContext : DbContext, ILibraryContext
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
    }
}
