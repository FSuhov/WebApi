using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShelfBusinessLogic
{
    public interface ILibraryContext
    {
        /// <summary>
        /// Gets or sets the collection of Authors using EF models
        /// </summary>
        DbSet<Author> Authors { get; set; }

        /// <summary>
        /// Gets or sets the collection of Genres using EF models
        /// </summary>
        DbSet<Genre> Genres { get; set; }

        /// <summary>
        /// Gets or sets the collection of Books using EF models
        /// </summary>
        DbSet<Book> Books { get; set; }

        /// <summary>
        /// Gets or sets the collection of BookAuthor entries using EF models
        /// </summary>
        DbSet<BookAuthor> BookAuthor { get; set; }

        /// <summary>
        /// Gets or sets the collection of BookGenre entries using EF models
        /// </summary>
        DbSet<BookGenre> BookGenre { get; set; }

        int SaveChanges();
    }
}
