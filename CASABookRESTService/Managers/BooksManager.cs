using CASABookClassLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CASABookRESTService.Managers
{
    public class BooksManager
    {
        private static readonly List<Book> bookList1 = new List<Book>()
        {
            new Book(){Author = "Natalie", ISBN = "123ABC", PageNumber = 5, Title = "Ohh"},
            new Book(){Author = "Pedro", ISBN = "1234ABCD", PageNumber = 102, Title = "Noo"},
            new Book(){Author = "Tom", ISBN = "ABCD1234", PageNumber = 105, Title = "The Way Of An Alien"}
        };


        public List<Book> GetAllBooks(string substring)
        {
            List<Book> resultat = new List<Book>(bookList1);
            if (substring != null)
            {
                resultat = resultat.FindAll(x => x.Title.Contains(substring, StringComparison.OrdinalIgnoreCase));
            }

            return resultat;
        }

        public void Add(Book newBook)
        {
            bookList1.Add(newBook);
        }

        public void Delete(string isbn)
        {
            Book book = bookList1.Find(x => x.ISBN == isbn);
            bookList1.Remove(book);
        }

        public void Update(string isbn, Book update)
        {
            Book book = bookList1.Find(x => x.ISBN == isbn);
            book.Author = update.Author;
            book.PageNumber = update.PageNumber;
            book.Title = update.Title;
        }







    }
}
