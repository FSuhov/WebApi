using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShelfBL
{
    /// <summary>
    /// Represents a Book model to be stored in the Database
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Static counter for automatic Id generation
        /// </summary>
        static int counter = 0;

        /// <summary>
        /// Creates new instance of Book withour parameters, to be used in tests
        /// </summary>
        public Book() {}

        /// <summary>
        /// Creates new instance of Book
        /// </summary>
        /// <param name="name">Title of book </param>
        public Book(string title)
        {
            this.Id = counter++;
            this.Title = title;
        }

        /// <summary>
        /// Gets or sets a Unique number to identify the book and store in the Database
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a Title of the book
        /// </summary>
        [Required]
        public string Title { get; set; }

        /// <summary>
        /// Gets or sets a collection of Ids of Authors of book
        /// </summary>
        public List<int> AuthorsId { get; set; } = new List<int>();

        /// <summary>
        /// Gets or sets a collection of Ids of Genres for book
        /// </summary>
        public List<int> GenresId { get; set; } = new List<int>();
        
        /// <summary>
        /// Adds author Id to book
        /// </summary>
        /// <param name="authorId">Id of author </param>
        public void AddAuthor(int authorId)
        {
            this.AuthorsId.Add(authorId);
        }

        /// <summary>
        /// Adds genre Id to book
        /// </summary>
        /// <param name="authorId">Id of genre </param>
        public void AddGenre(int genreId)
        {
            this.GenresId.Add(genreId);
        }
    }
}
