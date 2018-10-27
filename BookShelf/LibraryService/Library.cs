using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookShelf.Models;

namespace BookShelf.LibraryService
{
    public class Library : ILibrary
    {
        List<Book> books;
        List<Author> authors;

        public Library()
        {
            this.authors = new List<Author>();
            authors.Add(new Author("Leo Tolstoy")); //0
            authors.Add(new Author("Marcel Proust")); //1
            authors.Add(new Author("James Joyce")); //2
            authors.Add(new Author("William Shakespeare")); //3

            this.books = new List<Book>();
            books.Add(new Book("War and Peace", 0));
            books.Add(new Book("Anna Korenina", 0));
            books.Add(new Book("Hamlet", 3));
            books.Add(new Book("The Odyssey"));
            books.Add(new Book("Ulysses", 2));
            books.Add(new Book("In Search of Lost Time", 1));
            books.Add(new Book("The Iliad"));
        }
        public int AddAuthor(Author author)
        {
            authors.Add(author);
            return author.Id;
        }

        public int AddBook(Book book)
        {
            books.Add(book);
            return book.Id;
        }

        public void DeleteAuthor(int id)
        {
            Author authorToDelete = authors.Find(a => a.Id == id);
            if (authorToDelete != null)
            {
                books.RemoveAll(b => b.AuthorId == id);
                authors.Remove(authorToDelete);
            }
        }

        public void DeleteBook(int id)
        {
            Book bookToRemove = books.Find(b => b.Id == id);
            if (bookToRemove != null)
            {
                books.Remove(bookToRemove);
            }
        }

        public Author GetAuthorById(int id)
        {
            return authors.Find(a => a.Id == id);
        }

        public List<Author> GetAuthors()
        {
            return authors;
        }

        public Book GetBookById(int id)
        {
            return books.Find(b => b.Id == id);
        }

        public List<Book> GetBooks()
        {
            return books;
        }

        public void UpdateAuthor(int id, Author author)
        {
            Author authorToUpdate = authors.Find(a => a.Id == id);
            if (authorToUpdate != null)
            {
                authorToUpdate.Name = author.Name;
            }
        }

        public void UpdateBook(int id, Book book)
        {
            Book bookToUpdate = books.Find(b => b.Id == id);
            if (bookToUpdate != null)
            {
                bookToUpdate.Title = book.Title;
                bookToUpdate.AuthorId = book.AuthorId;
            }
        }

        public void UpdateBook(int bookId, int authorId)
        {
            Book bookToUpdate = books.Find(b => b.Id == bookId);
            Author author = authors.Find(a => a.Id == authorId);
            if (bookToUpdate != null && author != null)
            {
                bookToUpdate.AuthorId = authorId;
            }
        }
    }
}
