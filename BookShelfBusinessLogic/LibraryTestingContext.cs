using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShelfBusinessLogic
{
    public class LibraryTestingContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }

        public DbSet<BookAuthor> BookAuthor { get; set; }
        public DbSet<BookGenre> BookGenre { get; set; }

        

        public LibraryTestingContext()
        {
           
            Authors.Add(new Author { Id = 1, Name = "Leo Tolstoy" });
            Authors.Add(new Author { Id = 2, Name = "Anton Chechov" });
            Genres.Add(new Genre { Id = 1, Name = "Novel" });
            Genres.Add(new Genre { Id = 2, Name = "Poetry" });
            Books.Add(new Book { Id = 1, Title = "War and Piece" });
            Books.Add(new Book { Id = 2, Title = "Cherry garder" });
            BookAuthor.Add(new BookAuthor { Id = 1, BookRefId = 1, AuthorRefId = 1 });
            BookAuthor.Add(new BookAuthor { Id = 2, BookRefId = 2, AuthorRefId = 2 });
            BookGenre.Add(new BookGenre { Id = 1, BookRefId = 1, GenreRefId = 1 });
            BookGenre.Add(new BookGenre { Id = 2, BookRefId = 2, GenreRefId = 2 });
        }

        public int SaveChanges()
        {
            return 0;
        }

        public void Dispose() { }
    }
}
