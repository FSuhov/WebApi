using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShelf.Models
{
    public class Book
    {
        static int count = 0;
        public int Id { get; set; }
        public string Title { get; set; }

        public Book(string title)
        {
            this.Id = count++;
            this.Title = title;
        }
    }
}
