using BookShelf.Controllers;
using BookShelfBusinessLogic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BookShelf.Tests
{
    [TestClass]
    public class BookControllerTests
    {
        private LibraryService _library;
        private LibraryContext _context;
        private BookController _controller;

        public BookControllerTests()
        {
            var options = new DbContextOptionsBuilder<LibraryContext>()
               .UseInMemoryDatabase(databaseName: "Add_mockup_data_to_database")
               .Options;

            _context = new LibraryContext(options);
            _library = new LibraryService(_context);

            InitLibary();
        }

        [TestMethod]
        public void GetAllTest_ReturnsCollectionOfBooks()
        {
            // Arrange
            BooksComparer comparer = new BooksComparer();
            _controller = new BookController(_context);
            List<Book> expected = GetSampleBookCollection().ToList<Book>();

            // Act            
            List<Book> actual = _controller.GetAll().Value;

            // Assert
            bool isCollectionsSame = actual.SequenceEqual(expected, comparer);
            Assert.AreEqual(true, isCollectionsSame);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(2)]
        public void GetByIdTest_ReturnsBook(int id)
        {
            // Arrange
            BooksComparer comparer = new BooksComparer();
            _controller = new BookController(_context);
            BookView expectedBook = new BookView (sampleBooks[id - 1], _context);

            // Act
            BookView actualBook = _controller.GetById(id).Value;
            bool isBookAsExpected = expectedBook.Id == actualBook.Id && expectedBook.Title == actualBook.Title;

            // Assert
            Assert.AreEqual(true, isBookAsExpected);
        }

        [TestMethod]
        [DataRow(5)]
        public void GetByIdTestWhenIdDoesNotExists_ReturnsNotFound(int id)
        {
            // Arrange
            BooksComparer comparer = new BooksComparer();
            _controller = new BookController(_context);
            BookView expectedBook = null;

            // Act
            BookView actualBook = _controller.GetById(id).Value;            

            // Assert
            Assert.AreEqual(expectedBook, actualBook);
        }

        [TestMethod]
        [DataRow(1)]
        public void UpdateTest_WhenCalledWithValidId_ReturnsOK(int id)
        {
            // Arrange
            _controller = new BookController(_context);
            Book bookSample = new Book { Id = 1, Title = "War and Piece+" };

            // Act
            IActionResult result = _controller.Update(id, bookSample);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public void AddTest_ReturnsCreatedActionResult()
        {
            // Arrange
            _controller = new BookController(_context);

            // Act
            IActionResult result = _controller.Add(sampleBooks[2]);

            // Assert
            Assert.IsInstanceOfType(result, typeof(CreatedResult));
        }

        class BooksComparer : IEqualityComparer<Book>
        {
            public bool Equals(Book b1, Book b2)
            {
                if (b1.Id == b2.Id && b1.Title == b2.Title)
                {
                    return true;
                }
                return false;
            }

            public int GetHashCode(Book book)
            {
                return book.GetHashCode();
            }
        }
        
        private IEnumerable<Book> GetSampleBookCollection()
        {
            List<Book> books = new List<Book>();
            books.Add(new Book { Id = 1, Title = "War and Piece" });
            books.Add(new Book { Id = 2, Title = "Cherry garden" });
            return books;
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

        private static Book[] sampleBooks =
        {
            new Book { Id = 1, Title = "War and Piece" },
            new Book { Id = 2, Title = "Cherry garden" },
            new Book { Id = 3, Title = "Crime and Punishment" }
        };
    }
}
