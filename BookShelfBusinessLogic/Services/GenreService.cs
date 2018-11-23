using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShelfBusinessLogic
{
    /// <summary>
    /// Class containing all methods for data exchange with the database.
    /// Accepts DataProvider - an object interacting with external DB or with data in memory.
    /// </summary>
    public class GenreService : IGenreService
    {
        /// <summary>
        /// Object containing properties for data in database and basic methods for add and delete.
        /// Containes collections of type DbSet and Lists for all models.
        /// </summary>
        private IDataProvider _data;

        /// <summary>
        /// Initializes new instance of GenreService.
        /// </summary>
        public GenreService()
        {
        }

        /// <summary>
        /// Initializes new instance of GenreService.
        /// </summary>
        /// <param name="dataProvider"> Dataprovider. </param>
        public GenreService(IDataProvider dataProvider)
        {
            _data = dataProvider;
        }

        /// <summary>
        /// Gets the collection of Genres existing in the database
        /// </summary>
        /// <returns> The collection of Genres (might be empty)</returns>
        public IEnumerable<Genre> GetAllGenres()
        {
            return _data.GenresList;
        }

        /// <summary>
        /// Looks for instance of Genre with the specified Id in the collection
        /// </summary>
        /// <param name="id"> Id of Genre to look for </param>
        /// <returns> An instance of Genre or null if not found </returns>
        public Genre GetGenreById(int id)
        {
            return _data.GenresList.FirstOrDefault(g => g.Id == id);
        }

        /// <summary>
        /// Tries to add new Genre to the collection.
        /// </summary>
        /// <param name="genre"> Instance of new genre </param>
        /// <returns> True if added, false if such genre already exists in the collection </returns>
        public bool AddNewGenre(Genre genre)
        {
            Genre existingGenre = _data.GenresList.FirstOrDefault(g => g.Name == genre.Name);

            if (existingGenre == null)
            {
                _data.AddGenre(genre);                
                _data.Save();
                return true;
            }
            
            return false;
        }

        /// <summary>
        /// Tries to update Genre with specified Id.
        /// </summary>
        /// <param name="id"> Id of Genre to look for. </param>
        /// <param name="genre"> Genre to copy from. </param>
        /// <returns> True if updated, false if not found. </returns>
        public bool UpdateGenre(int id, Genre genre)
        {
            Genre genreToUpdate = _data.GenresList.FirstOrDefault(g => g.Id == id);
            if (genreToUpdate == null)
            {
                return false;
            }

            genreToUpdate.Id = genre.Id;
            genreToUpdate.Name = genre.Name;
            _data.Save();

            return true;
        }

        /// <summary>
        /// Tries to remove Genre with specified Id from collection.        
        /// </summary>
        /// <param name="id"> Id of Genre to look for. </param>
        /// <returns> True if removed, false if not found. </returns>
        public bool DeleteGenre(int id)
        {
            Genre genreToRemove = _data.GenresList.FirstOrDefault(g => g.Id == id);
            if (genreToRemove == null)
            {
                return false;
            }

            _data.DeleteGenre(genreToRemove);
            _data.Save();
            return true;
        }

        /// <summary>
        /// Selects all Books by specified genre
        /// </summary>
        /// <param name="genreId">Id of genre</param>
        /// <returns>The collection of Books </returns>
        public IEnumerable<Book> GetBooksByGenre(int genreId)
        {
            IEnumerable<Book> booksByGenre = from book in _data.BooksList
                                             join entry in _data.BooksGenresList on book.Id equals entry.BookRefId
                                             where entry.GenreRefId == genreId
                                             select book;

            return booksByGenre;
        }
    }
}
