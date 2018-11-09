using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AutoMapper;

namespace BookShelfBusinessLogic
{
    public class BookGenreResolver : IBookResolver<Book, BookView, List<string>>
    {
        public List<string> Resolve(Book source, BookView destination, List<string> destMemebr, IDataProvider data)
        {
            List<string> genres = new List<string>();
            foreach(BookGenre entry in data.BooksGenresList)
            {
                if (entry.BookRefId == source.Id)
                {
                    Genre g = data.GenresList.First(x => x.Id == entry.GenreRefId);
                    genres.Add(g.Name);
                }
            }
            return genres;
        }
    }
}
