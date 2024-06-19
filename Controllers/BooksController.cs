using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        // GET: api/book
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "Book1", "Book2" };
        }

        // GET: api/book/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return $"Book {id}";
        }

        // POST: api/book
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/book/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/book/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
