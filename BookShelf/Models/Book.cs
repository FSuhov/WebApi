using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookShelf.Models
{
    public class Book
    {
        static int counter = 0;
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public List<int> AuthorsId { get; set; } = new List<int>();
        public List<int> GenresId { get; set; } = new List<int>();

        public Book(string title)
        {
            this.Id = counter++;
            this.Title = title;
        }

        public void AddAuthor(int authorId)
        {
            this.AuthorsId.Add(authorId);
        }

        public void AddGenre(int genreId)
        {
            this.GenresId.Add(genreId);
        }
    }
}
