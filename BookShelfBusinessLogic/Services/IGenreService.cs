using System;
using System.Collections.Generic;
using System.Text;

namespace BookShelfBusinessLogic
{
    public interface IGenreService
    {
        /// <summary>
        /// Gets the collection of Genres existing in the database.
        /// </summary>
        /// <returns> The collection of Genres.</returns>
        IEnumerable<Genre> GetAllGenres();

        /// <summary>
        /// Looks for instance of Genre with the specified Id in the collection.
        /// </summary>
        /// <param name="id"> Id of Genre to look for. </param>
        /// <returns> An instance of Genre. </returns>
        Genre GetGenreById(int id);

        /// <summary>
        /// Tries to update Genre with specified Id.
        /// </summary>
        /// <param name="id"> Id of Genre to look for. </param>
        /// <param name="genre"> Genre to copy from. </param>
        /// <returns> True if updated, false if not found. </returns>
        bool UpdateGenre(int id, Genre genre);

        /// <summary>
        /// Tries to add new Genre to the collection.
        /// </summary>
        /// <param name="genre"> Instance of new genre. </param>
        /// <returns> True if added, false if such genre already exists in the collection. </returns>
        bool AddNewGenre(Genre genre);

        /// <summary>
        /// Tries to remove Genre with specified Id from collection.        
        /// </summary>
        /// <param name="id"> Id of Genre to look for. </param>
        /// <returns> True if removed, false if not found. </returns>
        bool DeleteGenre(int id);

        /// <summary>
        /// Selects all Books by specified genre
        /// </summary>
        /// <param name="genreId">Id of genre</param>
        /// <returns>The collection of Books </returns>
        IEnumerable<Book> GetBooksByGenre(int id);
    }
}
