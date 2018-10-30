using System;
using System.Collections.Generic;
using System.Text;

namespace BookShelfBusinessLogic
{
    public class BookGenre
    {
        public int Id { get; set; }
        public int BookRefId { get; set; }
        public int GenreRefId { get; set; }
    }
}
