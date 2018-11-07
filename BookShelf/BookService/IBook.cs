using BookShelf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookShelf.BookService
{
    public interface IBook
    {
        List<Book> getAll();
        Book getOne(int id);
        void UpdateBook(int id, Book book);
        void Delete(int id);
        int Add(Book book);
    }
}
