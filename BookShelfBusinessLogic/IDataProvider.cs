using BookShelfBusinessLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShelfBusinessLogic
{
    public interface IDataProvider
    {
        List<Genre> GenresList { get; }
        List<Author> AuthorsList { get; }
        List<Book> BooksList { get; }
        List<BookGenre> BooksGenresList { get; }
        List<BookAuthor> BooksAuthorsList { get; }        

        void AddGenre(Genre genre);
        void DeleteGenre(Genre genre);
        void AddAuthor(Author author);
        void DeleteAuthor(Author author);
        void AddBook(Book book);
        void DeleteBook(Book book);
        void AddBookGenre(BookGenre bg);
        void DeleteBookGenre(BookGenre bg);
        void AddBookAuthor(BookAuthor ba);
        void DeleteBookAuthor(BookAuthor ba);


        void Save();
    }
}
