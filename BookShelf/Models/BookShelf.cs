using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShelf.Models
{
    public class BookShelf
    {
        public int Id { get; set; }
        public List<Book> Books { get; set; }
    }
}
