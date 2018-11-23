using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShelfBusinessLogic
{
    public class BookAuthorResolver: IValueResolver<Book, BookView, List<string>>
    {
        public List<string> Resolve(Book source, BookView destination, List<string> destMember, IDataProvider data)
        {
            List<string> authors = new List<string>();
            foreach (BookAuthor entry in data.BooksAuthorsList)
            {
                if (entry.BookRefId == source.Id)
                {
                    Author a = data.AuthorsList.First(x => x.Id == entry.AuthorRefId);
                    authors.Add(a.Name);
                }
            }
            return authors;
        }

        public List<string> Resolve(Book source, BookView destination, List<string> destMember, ResolutionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
