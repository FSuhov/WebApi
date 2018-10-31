using BookShelfBusinessLogic;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;

namespace BookShelf.Tests
{
    [TestClass]
    public class LibraryServiceTests
    {
        [TestMethod]
        public void GetBooksTest_ReturnsCollectionOfBooks()
        {            
            var options = new DbContextOptionsBuilder<LibraryContext>()
               .UseInMemoryDatabase(databaseName: "Add_writes_to_database")
               .Options;

            using (var context = new LibraryContext(options))
            {
                // Arrange
                var library = new LibraryService(context);
                library.IsBookAdded(new Book { Id = 1, Title = "War and Piece" });
                library.IsBookAdded(new Book { Id = 2, Title = "Cherry garden" });
                BooksComparer comparer = new BooksComparer();

                // Act
                List<Book> result = library.GetBooks().ToList<Book>();
                List<Book> expected = InitCollection().ToList<Book>();
                int x = result.Count();
                bool same = result.SequenceEqual(expected, comparer);

                // Assert
                Assert.AreEqual(2, x);
                Assert.AreEqual(true, same);
            }

        }

        private IEnumerable<Book> InitCollection()
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
                int hCode = book.Id + book.Title.GetHashCode();
                return hCode.GetHashCode();
            }
        }
    }
}
