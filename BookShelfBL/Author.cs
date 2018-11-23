using System.ComponentModel.DataAnnotations;

namespace BookShelfBL
{
    /// <summary>
    /// Represents the model of Author
    /// </summary>
    public class Author
    {
        /// <summary>
        /// Static counter for automatic Id generation
        /// </summary>
        static int counter = 0;

        /// <summary>
        /// Creates new instance of Author class
        /// </summary>
        /// <param name="name">Name of author </param>
        public Author(string name)
        {
            this.Id = counter++;
            this.Name = name;
        }

        /// <summary>
        /// Sets or Gets a Unique number for Author identification and storage in Database
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Sets or gets a Name of Author
        /// </summary>
        [Required]
        public string Name { get; set; }

        
    }
}
