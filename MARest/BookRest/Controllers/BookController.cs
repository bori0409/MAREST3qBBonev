using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ClassLibrary2;

namespace BookRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase

    {
        static List<Book> books = new List<Book>(){
 new Book("The Hunger Games","Suzanne Collins","9780439023528",374),
 new Book("The Ugly Duckling","	Hans Christian Andersen","5487548832125",40),
 new Book("The Maze Runner","James Dashner","9780385737944",375)
       };
        
        // GET: api/Book
        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            return books;
        }

        // GET: api/Book/IMSBN-number(9780439023528)
        [HttpGet("{id}", Name = "Get")]
        public Book Get(string id)
        {
            return books.Find(i => i.ISBN13 == id);
        }

        // POST: api/Book
        [HttpPost]
        public void Post([FromBody] Book mynewbook)
        {
           Post(mynewbook);
        }

        // PUT: api/Book/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Book value)
        {
           ClassLibrary2.Book books = Get(id);
            if (books != null)
            {
                books.Title = value.Title;
                books.Author = value.Author;
                books.ISBN13 = value.ISBN13;
                books.PageNumber = value.PageNumber;
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            ClassLibrary2.Book boks = Get(id);
            books.Remove(boks);
        }
    }
}
