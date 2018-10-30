using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShelfBusinessLogic
{
    public class BookView
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public List<string> Authors { get; set; }
        public List<string> Genres { get; set; }

        public BookView(Book book, LibraryContext context)
        {
            this.Id = book.Id;
            this.Title = book.Title;
            Authors = new List<string>();
            Genres = new List<string>();

            foreach(BookAuthor item in context.BookAuthor)
            {
                if (item.BookRefId == book.Id)
                {
                    Author author = context.Authors.First(a => a.Id == item.AuthorRefId);
                    this.Authors.Add(author.Name);
                }
            }

            foreach (BookGenre item in context.BookGenre)
            {
                if (item.BookRefId == book.Id)
                {
                    Genre genre = context.Genres.First(a => a.Id == item.GenreRefId);
                    this.Genres.Add(genre.Name);
                }
            }
        }
    }
}
