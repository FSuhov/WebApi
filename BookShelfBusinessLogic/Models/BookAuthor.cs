using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookShelfBusinessLogic
{
    /// <summary>
    /// Represents an entry for many-to-many relations for Books and Authors
    /// </summary>
    public class BookAuthor : IComparable<BookAuthor>
    {
        /// <summary>
        /// Gets or sets a Unique number to identify the BookAuthor entry and store in the Database
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets an Id of Book
        /// </summary>
        [ForeignKey("Book")]
        public int BookRefId { get; set; }

        /// <summary>
        /// Gets or sets an Id of Author
        /// </summary>
        [ForeignKey("Author")]
        public int AuthorRefId { get; set; }

        /// <summary>
        /// Compares this with another entry of BookAuthor and returns a result
        /// </summary>
        /// <param name="other"> Another entry</param>
        /// <returns> 0 in case equal, -1 if not</returns>
        public int CompareTo(BookAuthor other)
        {
            if (this.BookRefId == other.BookRefId && this.AuthorRefId == other.AuthorRefId)
            {
                return 0;
            }

            else return -1;
        }
    }
}
