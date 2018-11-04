using BookShelfBusinessLogic;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BookShelf.Tests
{
    /*
    [TestClass]
    public class LibraryServiceTests
    {
        private LibraryService _library;
        private LibraryContext _context;

        public LibraryServiceTests()
        {
            var options = new DbContextOptionsBuilder<LibraryContext>()
               .UseInMemoryDatabase(databaseName: "Add_mockup_data_to_database")
               .Options;

            _context = new LibraryContext(options);
            _library = new LibraryService(_context);

            InitLibary();            
        }

        [TestMethod]
        public void GetBooksTest_ReturnsCollectionOfBooks()
        {
            // Arrange
            BooksComparer comparer = new BooksComparer();
            List<Book> expected = GetSampleBookCollection().ToList<Book>();

            // Act
            List<Book> actual = _library.GetBooks().ToList<Book>();            

            // Assert
            bool isCollectionsSame = actual.SequenceEqual(expected, comparer);
            Assert.AreEqual(true, isCollectionsSame);
        }

        [TestMethod]
        [DataRow(1, true)]
        [DataRow(2, true)]
        public void GetBookByIdTest_ReturnsBookWhenFound(int id, bool expected)
        {
            // Arrange
            BookView expectedBook = new BookView ( sampleBooks[id-1], _context);

            // Act
            BookView actualBook = _library.GetBookById(id);

            bool isEqual = (expectedBook.Id == actualBook.Id) && (expectedBook.Title == actualBook.Title);

            // Assert
            Assert.AreEqual(expected, isEqual);
        }

        [TestMethod]
        [DataRow(5, null)]
        public void GetBookByIdTest_ReturnsNullWhenNotFound(int id, object expected)
        {
            // Arrange

            // Act
            BookView actualBook = _library.GetBookById(id);

            // Assert
            Assert.AreEqual(expected, actualBook);
        }

        [TestMethod]
        public void IsBookAdded_ReturnsTrueWhenBookWasNotInTheCollectionBefore()
        {
            // Arrange
            Book toBeAdded = sampleBooks[2];

            // Act
            bool actual = _library.IsBookAdded(toBeAdded);

            // Asser
            Assert.AreEqual(true, actual);
        }

        [TestMethod]
        public void IsBookAdded_ReturnsFalseWhenBookWasInTheCollectionAlready()
        {
            // Arrange
            Book toBeAdded = sampleBooks[0];

            // Act
            bool actual = _library.IsBookAdded(toBeAdded);

            // Asser
            Assert.AreEqual(false, actual);
        }

        private IEnumerable<Book> GetSampleBookCollection()
        {
            List<Book> books = new List<Book>();
            books.Add(new Book { Id = 1, Title = "War and Piece" });
            books.Add(new Book { Id = 2, Title = "Cherry garden" });
            return books;
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
    */
}
