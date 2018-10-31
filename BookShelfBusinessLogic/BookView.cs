using System.Collections.Generic;
using System.Linq;

namespace BookShelfBusinessLogic
{
    /// <summary>
    /// Represents an entity for user-friendly representation of specific book
    /// </summary>
    public class BookView
    {
        /// <summary>
        /// Initializes new instance of BookView class
        /// </summary>
        /// <param name="book"> Base book model </param>
        /// <param name="context"> Data context </param>
        public BookView(Book book, LibraryContext context)
        {
            this.Id = book.Id;
            this.Title = book.Title;
            Authors = new List<string>();
            Genres = new List<string>();

            foreach (BookAuthor item in context.BookAuthor)
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

        /// <summary>
        /// Gets or sets a Unique number to identify the Book
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a Title of the book
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets a collection of Authors of specified book
        /// </summary>
        public List<string> Authors { get; set; }

        /// <summary>
        /// Gets or sets a collection of Genres of specified book
        /// </summary>
        public List<string> Genres { get; set; }        
    }
}
