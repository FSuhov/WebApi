using System.ComponentModel.DataAnnotations;

namespace BookShelfBusinessLogic
{
    /// <summary>
    /// Represents a Genre model to be stored in the Database
    /// </summary>
    public class Genre
    {
        public Genre()
        {
        }

        /// <summary>
        /// Gets or sets a Unique number to identify the Genre and store in the Database
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets a Name of the Genre
        /// </summary>
        [Required]
        public string Name { get; set; }
    }
}
