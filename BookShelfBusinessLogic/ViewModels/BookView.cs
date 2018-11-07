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
        /// <param name="data"> Data context </param>
        public BookView(Book book, IDataProvider data)
        {
            this.Id = book.Id;
            this.Title = book.Title;
            this.Authors = new List<string>();
            this.Genres = new List<string>();

            foreach (BookAuthor item in data.BooksAuthorsList)
            {
                if (item.BookRefId == book.Id)
                {
                    Author author = data.AuthorsList.First(a => a.Id == item.AuthorRefId);
                    this.Authors.Add(author.Name);
                }
            }

            foreach (BookGenre item in data.BooksGenresList)
            {
                if (item.BookRefId == book.Id)
                {
                    Genre genre = data.GenresList.First(g => g.Id == item.GenreRefId);
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
