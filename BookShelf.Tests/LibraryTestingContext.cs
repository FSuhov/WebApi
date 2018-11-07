using BookShelfBusinessLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookShelf.Tests
{
    public class LibraryTestingContext : IDataProvider
    {
        public virtual List<Genre> GenresList { get; set; }

        public virtual List<Author> AuthorsList { get; set; }

        public virtual List<Book> BooksList { get; set; }

        public virtual List<BookGenre> BooksGenresList { get; set; }

        public virtual List<BookAuthor> BooksAuthorsList { get; set; }

        public void AddAuthor(Author author)
        {
            AuthorsList.Add(author);           
        }

        public void AddBook(Book book)
        {
            BooksList.Add(book);            
        }

        public void AddBookAuthor(BookAuthor ba)
        {
            BooksAuthorsList.Add(ba);            
        }

        public void AddBookGenre(BookGenre bg)
        {
            BooksGenresList.Add(bg);            
        }

        public void AddGenre(Genre genre)
        {
            GenresList.Add(genre);            
        }

        public void DeleteAuthor(Author author)
        {
            AuthorsList.Remove(author);
        }

        public void DeleteBook(Book book)
        {
            BooksList.Remove(book);
        }

        public void DeleteBookAuthor(BookAuthor ba)
        {
            BooksAuthorsList.Remove(ba);
        }

        public void DeleteBookGenre(BookGenre bg)
        {
            BooksGenresList.Remove(bg);
        }

        public void DeleteGenre(Genre genre)
        {
            GenresList.Remove(genre);
        }

        public void Save()
        {
            return;
        }
    }
}
