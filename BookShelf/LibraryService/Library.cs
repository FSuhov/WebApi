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
        List<Genre> genres;

        public Library()
        {
            this.authors = new List<Author>();
            authors.Add(new Author("Leo Tolstoy")); //0
            authors.Add(new Author("Marcel Proust")); //1
            authors.Add(new Author("James Joyce")); //2
            authors.Add(new Author("William Shakespeare")); //3

            this.books = new List<Book>();
            books.Add(new Book("War and Peace"));
            books.Add(new Book("Anna Korenina"));
            books.Add(new Book("Hamlet"));
            books.Add(new Book("The Odyssey"));
            books.Add(new Book("Ulysses"));
            books.Add(new Book("In Search of Lost Time"));
            books.Add(new Book("The Iliad"));

            this.genres = new List<Genre>();
            genres.Add(new Genre("Classic"));
            genres.Add(new Genre("Modern"));
            genres.Add(new Genre("Ancient"));

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
            // TODO: Think what to do: either remove books or just remove author.
            // Currently - all books where this Author exists will be deleted.
            Author authorToDelete = authors.Find(a => a.Id == id);
            if (authorToDelete != null)
            {
                foreach(Book item in books)
                {
                    item.AuthorsId.Remove(id);
                }
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
                bookToUpdate.AuthorsId = book.AuthorsId;
            }
        }

        public bool AddAuthorToBook(int bookId, int authorId)
        {
            Book bookToUpdate = books.Find(b => b.Id == bookId);
            Author author = authors.Find(a => a.Id == authorId);
            if (bookToUpdate != null && author != null)
            {
                bookToUpdate.AuthorsId.Add(authorId);
                return true;
            }
            return false;
        }

        public bool AddGenreToBook(int bookId, int genreId)
        {
            Book bookToUpdate = books.Find(b => b.Id == bookId);
            Genre genre = genres.Find(g => g.Id == genreId);
            if (bookToUpdate != null && genre != null)
            {
                bookToUpdate.GenresId.Add(genreId);
                return true;
            }
            return false;
        }

        public List<Genre> GetGenres()
        {
            return genres;
        }

        public Genre GetGenreById(int id)
        {
            return genres.Find(g => g.Id == id);
        }

        public int AddGenre(Genre genre)
        {
            genres.Add(genre);
            return genre.Id;
        }

        public bool DeleteGenre(int id)
        {            
            var items = books.FindAll(b => b.GenresId.Contains(id));
            if (items.Count() == 0)
            {
                genres.Remove(genres.Find(g => g.Id == id));
                return true;
            }
            return false;
        }

        public List<Book> GetBooksByGenre(int genreId)
        {
            return books.FindAll(b => b.GenresId.Contains(genreId));
        }

        public List<Book> GetBooksByAuthor(int authorId)
        {
            return books.FindAll(b => b.AuthorsId.Contains(authorId));
        }
    }
}
