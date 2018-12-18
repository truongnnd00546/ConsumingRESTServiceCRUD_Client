using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;
using ConsumingRESTServiceCRUD.ServiceReference1;

namespace ConsumingRESTServiceCRUD.Models
{
    public class BookServiceClient
    {
        Service1Client client = new Service1Client();
        //string BASE_URL = "http://localhost:64839/Service1.svc";
        
        public List<Book> getAllBook()
        {
            //*Case1*//
            var list = client.GetBookList().ToList();
            var rt = new List<Book>();
            list.ForEach(b => rt.Add(new Book()
            {
                BookId = b.BookId,
                ISBN = b.ISBN,
                Title = b.Title
            }));
            return rt;
            //*Case2*//
            //var syncClient = new WebClient();
            //var content = syncClient.DownloadString(BASE_URL + "Books");
            //var json_serializer = new JavaScriptSerializer();
            //return json_serializer.Deserialize<List<Book>>(content);
        }
        public string AddBook(Book newBook)
        {
            var book = new ServiceReference1.Book()
            {
                BookId = newBook.BookId,
                ISBN = newBook.ISBN,
                Title = newBook.Title
            };
            return client.AddBook(book);
        }
        public string DeleteBook(int id)
        {
            return client.DeleteBook(Convert.ToString(id));
        }
        public string Edit(Book newBook)
        {
            var book = new ServiceReference1.Book()
            {
                BookId = newBook.BookId,
                ISBN = newBook.ISBN,
                Title = newBook.Title
            };
            return client.UpdateBook(book);
        }
    }
}