using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookShelf.Models
{
    public class Genre
    {
        static int count = 0;

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        //public List<int> booksId { get; set; } = new List<int>();

        public Genre(string name)
        {
            this.Id = count++;
            this.Name = name;
        }
    }
}
