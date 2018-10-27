using BookShelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShelf.LibraryService
{
    public interface ILibrary
    {
        List<Book> GetBooks();
        Book GetBookById(int id);
        void UpdateBook(int id, Book book);
        int AddBook(Book book);
        void DeleteBook(int id);

        List<Author> GetAuthors();
        Author GetAuthorById(int id);
        void UpdateAuthor(int id, Author author);
        int AddAuthor(Author author);
        void DeleteAuthor(int id);

        List<Genre> GetGenres();
        Genre GetGenreById(int id);
        int AddGenre(Genre genre);
        bool DeleteGenre(int id);

        bool AddAuthorToBook(int bookId, int authorId);
        bool AddGenreToBook(int bookId, int genreId);

        List<Book> GetBooksByGenre(int genreId);
        List<Book> GetBooksByAuthor(int authorId);
    }
}
