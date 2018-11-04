using BookShelf.Controllers;
using BookShelfBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Moq;

namespace BookShelf.Tests
{
    [TestClass]
    public class GenreServiceTests
    {
        [TestMethod]
        public void GetAllGenres_ReturnsCollectionOfGenres()
        {
            // Arrange
            List<Genre> testGenres = new List<Genre>()
            {
                new Genre(){Id = 1, Name = "Genre1"},
                new Genre(){Id = 2, Name = "Genre2"},
                new Genre(){Id = 3, Name = "Genre3"}
            };

            var mockData = new LibraryTestingContext();
            var libraryService = new LibraryService(mockData);
            mockData.Add(testGenres[0]);
            mockData.Add(testGenres[1]);
            mockData.Add(testGenres[2]);
            mockData.SaveChanges();

            // Act
            IEnumerable<Genre> actualGenres = libraryService.GetGenres();
            bool isObjectsEqual = true;
            for(int i = 0; i < actualGenres.Count(); i++)
            {
                Genre expected = testGenres[i];
                Genre actual = actualGenres.ElementAt(i);
                isObjectsEqual = expected.Id == actual.Id && expected.Name == actual.Name;
            }
            
            // Assert
            Assert.AreEqual(testGenres.Count, actualGenres.Count());
            Assert.AreEqual(true, isObjectsEqual);
        }

        [TestMethod]
        [DataRow(4,3)]        
        public void GetGenreById_ReturnsCorrectGenreOrNull(int id, int genreIndexExpected)
        {
            // Arrange
            List<Genre> testGenres = new List<Genre>()
            {
                new Genre(){Id = 1, Name = "Genre1"},
                new Genre(){Id = 2, Name = "Genre2"},
                new Genre(){Id = 3, Name = "Genre3"}
            };            
            var mockData = new LibraryTestingContext();
            var libraryService = new LibraryService(mockData);            
            mockData.Add(testGenres[0]);
            mockData.Add(testGenres[1]);
            mockData.Add(testGenres[2]);
            mockData.SaveChanges();

            // Act
            Genre actual = libraryService.GetGenreById(id);
            Genre expected = testGenres[genreIndexExpected];
            bool isEqualGenres = ((actual == null && expected == null) || (actual.Id == expected.Id && actual.Name == expected.Name));
            

            // Assert
            Assert.AreEqual(true, isEqualGenres);            
        }
    }
}
