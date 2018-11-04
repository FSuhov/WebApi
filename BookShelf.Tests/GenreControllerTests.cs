using BookShelf.Controllers;
using BookShelfBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BookShelf.Tests
{
    /*
    [TestClass]
    public class GenreControllerTests
    {
        private LibraryService _library;
        private LibraryContext _context;
        private GenreController _controller;

        public GenreControllerTests()
        {
            var options = new DbContextOptionsBuilder<LibraryContext>()
               .UseInMemoryDatabase(databaseName: "Add_mockup_data_to_database")
               .Options;

            _context = new LibraryContext(options);
            _library = new LibraryService(_context);

            InitLibary();
        }


        [TestMethod]
        public void GetAllTest_ReturnsCollectionOfGenres()
        {
            // Arrange
            GenreComparer comparer = new GenreComparer();
            _controller = new GenreController(_context);
            List<Genre> expected = GetSampleGenreCollection().ToList<Genre>();

            // Act            
            List<Genre> actual = _controller.GetAll().Value;

            // Assert
            bool isCollectionsSame = actual.SequenceEqual(expected, comparer);
            Assert.AreEqual(true, isCollectionsSame);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        public void GetByIdTest_ReturnsCorrectGenre(int id)
        {
            // Arrange            
            _controller = new GenreController(_context);
            Genre expectedGenre = sampleGenres[id-1];

            // Act
            Genre actualGenre = _controller.GetById(id).Value;
            bool isBookAsExpected = expectedGenre.Id == actualGenre.Id && expectedGenre.Name == actualGenre.Name;

            // Assert
            Assert.AreEqual(true, isBookAsExpected);
        }

        [TestMethod]
        [DataRow(5)]
        public void GetByIdTestWhenIdDoesNotExists_ReturnsNotFound(int id)
        {
            // Arrange            
            _controller = new GenreController(_context);

            // Act
            Genre expectedGenre = null;
            Genre actualGenre = _controller.GetById(id).Value;
            
            // Assert
            Assert.AreEqual(expectedGenre, actualGenre);
        }

        [TestMethod]
        public void AddTest_ReturnsCreatedActionResult()
        {
            // Arrange
            _controller = new GenreController(_context);

            // Act
            IActionResult result = _controller.Add(sampleGenres[2]);

            // Assert
            Assert.IsInstanceOfType(result, typeof(CreatedResult));
        }

        class GenreComparer : IEqualityComparer<Genre>
        {
            public bool Equals(Genre g1, Genre g2)
            {
                if (g1.Id == g2.Id && g1.Name == g2.Name)
                {
                    return true;
                }
                return false;
            }

            public int GetHashCode(Genre genre)
            {
                return genre.GetHashCode();
            }
        }

        private IEnumerable<Genre> GetSampleGenreCollection()
        {
            List<Genre> genres = new List<Genre>();
            genres.Add(new Genre { Id = 1, Name = "Novel" });
            genres.Add(new Genre { Id = 2, Name = "Poetry" });
            return genres;
        }

        private void InitLibary()
        {
            _library.IsBookAdded(new Book { Id = 1, Title = "War and Piece" });
            _library.IsBookAdded(new Book { Id = 2, Title = "Cherry garden" });
            _library.AddAuthor(new Author { Id = 1, Name = "Leo Tolstoy" });
            _library.AddAuthor(new Author { Id = 2, Name = "Anton Chechov" });
            _library.AddGenre(new Genre { Id = 1, Name = "Novel" });
            _library.AddGenre(new Genre { Id = 2, Name = "Poetry" });
        }

        private static Genre[] sampleGenres =
        {
            new Genre { Id = 1, Name = "Novel" },
            new Genre { Id = 2, Name = "Poetry" },
            new Genre { Id = 3, Name = "Sci-Fi" }
        };
    }
    */
}

