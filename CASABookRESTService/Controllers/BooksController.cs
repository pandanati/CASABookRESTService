using CASABookClassLibrary;
using CASABookRESTService.Managers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CASABookRESTService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksManager _manager = new BooksManager();

        // GET: api/<ValuesController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            //In case the user doesn't write anything in the URL
            IEnumerable<Book> books = _manager.GetAllBooks(null);
            
            if (books == null)
            {
                return NotFound("Could not find any books");
            }

            return Ok(books);
        }

        // GET api/<ValuesController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{substring}")]
        public ActionResult<IEnumerable<Book>> Get(string substring)
        {
            IEnumerable<Book> books = _manager.GetAllBooks(substring);

            if (books == null)
            {
                return NotFound("Could not find any books");
            }

            return Ok(books);
        }

        // POST api/<ValuesController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPost]
        public ActionResult<Book> Post([FromBody] Book value)
        {
            if (value == null)
            {
                return NotFound("The value is null");
            }
            _manager.Add(value);
            return Ok();
        }

        // PUT api/<ValuesController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{isbn}")]
        public ActionResult<Book> Put(string isbn, [FromBody] Book newBook)
        {
            if (newBook == null)
            {
                return NotFound("The value is null");
            }
            _manager.Update(isbn, newBook);
            return Ok();
        }

        // DELETE api/<ValuesController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{isbn}")]
        public ActionResult<Book> Delete(string isbn)
        {
            if (isbn == null)
            {
                return NotFound("Book with this ISBN not found");
            }
            _manager.Delete(isbn);
            return Ok();
        }
    }
}
