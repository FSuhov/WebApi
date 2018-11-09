using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BookShelfBusinessLogic
{
    public class AutoMapperConfig
    {

        public class AutoMapperProfile : Profile
        {
            private IDataProvider _data;
            public AutoMapperProfile(IDataProvider data)
            {
                _data = data;
                CreateMap<Book, BookView>()
                    .ForMember(dest => dest.Authors, opts => opts.MapFrom(GetGenres(opts.Id))
            }

            private List<string> GetGenres(int bookId)
            {
                List<string> res = new List<string>();
                foreach (BookGenre entry in _data.BooksGenresList)
                {
                    if(entry.BookRefId == bookId)
                    {
                        Genre genre = _data.GenresList.First(g => g.Id == entry.GenreRefId);
                        res.Add(genre.Name);
                    }
                }
                return res;
            }
        }
    }
}
