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
        private static GenreService _service;
        private Mock<LibraryTestingContext> _data;

        [TestInitialize]
        public void Initialize()
        {
            _data = new Mock<LibraryTestingContext>();

            _data.SetupGet(g => g.GenresList).Returns(mockGenres);            

            _service = new GenreService(_data.Object);
            _data.Object.Save();
        }

        [TestMethod]
        public void GetAllGenres()
        {
            // Arrange

            // Act
            List<Genre> actualGenres = _service.GetAllGenres().ToList();

            // Assert
            Assert.AreEqual(mockGenres.Count, actualGenres.Count);
        }

        [TestMethod]
        [DataRow(1, "TestGenre1")]
        public void GetGenreById_CorrectId_ReturnsGenre(int id, string name)
        {
            // Arrange             

            // Act
            Genre actualGenre = _service.GetGenreById(id);

            // Assert
            Assert.AreEqual(id, actualGenre.Id);
            Assert.AreEqual(name, actualGenre.Name);
        }

        [TestMethod]
        [DataRow(5)]
        public void GetGenreById_InCorrectId_ReturnsNull(int id)
        {
            // Arrange  

            // Act
            Genre actualGenre = _service.GetGenreById(id);

            // Assert
            Assert.AreEqual(null, actualGenre);
        }

        [TestMethod]
        [DataRow(4, "TestGenre4")]
        public void AddGenre_ValidGenre_ReturnsTrue(int id, string name)
        {
            // Arrange

            // Act
            bool isAdded =_service.AddNewGenre(new Genre { Id = id, Name = name });

            // Assert
            int actualCount = _data.Object.GenresList.Count;
            Genre lastGenreAdded = _service.GetAllGenres().ToList().Last();

            Assert.AreEqual(true, isAdded);
            Assert.AreEqual(mockGenres.Count, actualCount);
            Assert.AreEqual(id, lastGenreAdded.Id);
            Assert.AreEqual(name, lastGenreAdded.Name);
        }

        [TestMethod]
        [DataRow(4, "TestGenre1")]
        public void AddGenre_ExistingGenre_ReturnsFalse(int id, string name)
        {
            // Arrange

            // Act
            bool isAdded = _service.AddNewGenre(new Genre { Id = id, Name = name });

            // Assert
            int actualCount = _data.Object.GenresList.Count;
            Genre lastGenreAdded = _service.GetAllGenres().ToList().Last();

            Assert.AreEqual(false, isAdded);
            Assert.AreEqual(mockGenres.Count, actualCount);
            Assert.AreEqual(mockGenres[mockGenres.Count-1].Id, lastGenreAdded.Id);
            Assert.AreEqual(mockGenres[mockGenres.Count - 1].Name, lastGenreAdded.Name);
        }

        [TestMethod]
        [DataRow(3, "UpdateGenre3")]
        public void UpdateGenre_ValidGenre_ReturnsTrue(int id, string name)
        {
            // Arrange

            // Act
            bool isUpdated = _service.UpdateGenre(id, new Genre() { Id = id, Name = name });
            Genre updatedGenre = _data.Object.GenresList.FirstOrDefault(g => g.Id == id);

            // Assert
            Assert.AreEqual(true, isUpdated);
            Assert.AreEqual(name, updatedGenre.Name);
        }

        private static List<Genre> mockGenres = new List<Genre>
        {
            new Genre {Id = 1, Name = "TestGenre1"},
            new Genre {Id = 2, Name = "TestGenre2"},
            new Genre {Id = 3, Name = "TestGenre3"}
        };

        private static List<Author> mockAuthors = new List<Author>
        {
            new Author {Id = 1, Name = "TestAuthor1"},
            new Author {Id = 2, Name = "TestAuthor2"},
            new Author {Id = 3, Name = "TestAuthor3"}
        };

        private static List<Book> mockBooks = new List<Book>
        {
            new Book {Id = 1, Title = "TestBook1"},
            new Book {Id = 2, Title = "TestBook2"},
            new Book {Id = 3, Title = "TestBook3"},
        };

        private static List<BookGenre> mockBookGenre = new List<BookGenre>
        {
            new BookGenre {Id = 1, BookRefId = 1, GenreRefId = 1},
            new BookGenre {Id = 2, BookRefId = 2, GenreRefId = 2},            
        };

        private static List<BookAuthor> mockBookAuthor = new List<BookAuthor>
        {
            new BookAuthor {Id = 1, BookRefId = 1, AuthorRefId = 1},
            new BookAuthor {Id = 2, BookRefId = 2, AuthorRefId = 2},
        };

    }
}
