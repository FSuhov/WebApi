using System;
using System.Collections.Generic;
using System.Text;

namespace BookShelfBusinessLogic
{
    public class BookAuthor : IComparable<BookAuthor>
    {
        public int Id { get; set; }
        public int BookRefId { get; set; }
        public int AuthorRefId { get; set; }

        public int CompareTo(BookAuthor other)
        {
            if (this.BookRefId == other.BookRefId && this.AuthorRefId == other.AuthorRefId)
            {
                return 0;
            }

            else return -1;
        }
    }
}
