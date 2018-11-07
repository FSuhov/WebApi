using System;
using System.ComponentModel.DataAnnotations;

namespace BookShelfBusinessLogic
{
    /// <summary>
    /// Represents the model of Author
    /// </summary>
    public class Author
    {
        /// <summary>
        /// Sets or Gets a Unique number for Author identification and storage in Database
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Sets or gets a Name of Author
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// Compares Author with another object to get a correct comparison behavior in unit testing
        /// </summary>
        /// <param name="obj"> Another objetc to compare with </param>
        /// <returns> True if equal, false is not </returns>
        public override bool Equals(Object obj)
        {
            var other = obj as Author;

            if (other == null)
            {
                return false;
            }                

            if (this.Name != other.Name || this.Id != other.Id)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// Getting the hashcode of Author
        /// </summary>
        /// <returns> Hash code </returns>
        public override int GetHashCode()
        {
            return this.GetHashCode();
        }
    }
}
