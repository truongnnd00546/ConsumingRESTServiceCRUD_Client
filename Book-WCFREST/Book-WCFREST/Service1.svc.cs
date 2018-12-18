using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Book_WCFREST
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        static IBookRepository repository = new BookRepository();
        public string AddBook(Book book)
        {
            Book newBook = repository.AddNewBook(book);
            return "id=" + newBook.BookId;
        }

        public string DeleteBook(string id)
        {
            bool deleted = repository.DeleteBook(int.Parse(id));
            if (deleted)
            {
                return "Delete success";
            }
            else
            {
                return "Delete false";
            }
        }

        public Book GetBookById(string id)
        {
            return repository.GetBookById(int.Parse(id));
        }

        public List<Book> GetBookList()
        {
            return repository.GetAllBooks();
        }

        public string UpdateBook(Book book)
        {
            bool deleted = repository.UpdateBook(book);
            if (deleted)
            {
                return "Book with id=" + book.BookId + "update successfully";
            }
            else
            {
                return "Unable to update book with id=" + book.BookId;
            }
        }
    }
}
