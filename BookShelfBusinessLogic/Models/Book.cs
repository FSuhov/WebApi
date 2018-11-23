using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookShelfBusinessLogic
{
    /// <summary>
    /// Represents a Book model to be stored in the Database
    /// </summary>
    public class Book
    {
        /// <summary>
        /// Gets or sets a Unique number to identify the book and store in the Database
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a Title of the book
        /// </summary>
        [Required]
        public string Title { get; set; }
    }
}
