using BookShelfBusinessLogic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace BookShelf.Tests
{
    public class LibraryTestingContext : DbContext, ILibraryContext
    {
        
        public LibraryTestingContext()
        {            
        }
        public LibraryTestingContext(DbContextOptions<LibraryContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "Add_mockup_data_to_database");
            
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookAuthor> BookAuthor { get; set; }
        public DbSet<BookGenre> BookGenre { get; set; }

        //public List<Book> BookList { get => Books.ToList(); }
        public List<Genre> GenreList
        {
            get => Genres.ToList();
            set
            {                
                foreach(Genre item in value)
                {
                    this.Add(item);
                }
                SaveChanges();
            }
        }
        //public List<Author> AuthorList { get => Authors.ToList(); }
    }
}
