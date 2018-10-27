using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShelf.Models
{
    public class Author
    {
        static int counter = 0;
        public int Id { get; set; }
        public string  Name { get; set; }

        public Author(string name)
        {
            this.Id = counter++;
            this.Name = name;
        }
    }
}
