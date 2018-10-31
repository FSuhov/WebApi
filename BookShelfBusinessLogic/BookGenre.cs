using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookShelfBusinessLogic
{
    /// <summary>
    /// Represents an entry for many-to-many relations for Books and Genres
    /// </summary>
    public class BookGenre
    {
        /// <summary>
        /// Gets or sets a Unique number to identify the BookGenre entry and store in the Database
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets an Id of Book
        /// </summary>
        [ForeignKey("Book")]
        public int BookRefId { get; set; }

        /// <summary>
        /// Gets or sets an Id of Genre
        /// </summary>
        [ForeignKey("Genre")]
        public int GenreRefId { get; set; }
    }
}
