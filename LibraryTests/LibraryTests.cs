using BookShelfBL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LibraryTests
{
    [TestClass]
    public class LibraryTests
    {
        Library _library;

        public LibraryTests()
        {
            _library = new Library();
        }

        [TestMethod]
        [DataRow(1)]
        public void GetByIdTest_ReturnsCorrectBook(int id)
        {
            // Arrange

            // Act
            Book actualBook = _library.GetBookById(id);
            Book expectedBook = sampleBooks[id];
            bool isBookEqual = actualBook.Title == expectedBook.Title && actualBook.Id == expectedBook.Id;

            // Assert
            Assert.AreEqual(true, isBookEqual);
        }

        public static Book[] sampleBooks =
        {
            new Book {Id = 0, Title = "War and Piece"},
            new Book {Id = 1, Title = "Anna Korenina"},
        };
    }
}
