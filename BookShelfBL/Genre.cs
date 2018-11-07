using System.ComponentModel.DataAnnotations;

namespace BookShelfBL
{
    /// <summary>
    /// Represents the model of Genre
    /// </summary>
    public class Genre
    {
        /// <summary>
        /// Static counter for automatic Id generation
        /// </summary>
        static int count = 0;

        /// <summary>
        /// Creates new instance of Genre class
        /// </summary>
        /// /// <param name="name">Name of genre </param>
        public Genre(string name)
        {
            this.Id = count++;
            this.Name = name;
        }

        // <summary>
        /// Sets or Gets a Unique number for Genre identification and storage in Database
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Sets or gets a Name of Genre
        /// </summary>
        [Required]
        public string Name { get; set; }        
    }
}
