using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShelf.Models;

namespace BookShelf.BookService
{
    public class BookList : IBook
    {
        List<Book> _books;

        public BookList()
        {
            _books = new List<Book>();
            _books.Add(new Book("War and Piece"));
            _books.Add(new Book("Anna Korenina"));
        }

        public List<Book> getAll()
        {
            return _books;
        }

        public Book getOne(int id)
        {
            return _books.First(b => b.Id == id);            
        }

        public void UpdateBook(int id, Book book)
        {
            Book toBeUpdated = _books.First(b => b.Id == id);
            if (toBeUpdated != null)
            {
                toBeUpdated.Title = book.Title;
            }
        }

        public void Delete(int id)
        {
            Book toBeRemoved = _books.FirstOrDefault(b => b.Id == id);
            _books.Remove(toBeRemoved);
        }

        public int Add(Book book)
        {
            this._books.Add(book);
            return _books.First(b => b.Id == book.Id).Id;
        }
    }
}
