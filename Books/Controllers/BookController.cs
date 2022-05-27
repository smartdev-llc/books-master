using Books.Entities;
using Books.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        IBookService _iBook;
        public BookController(IBookService iBook)
        {
            _iBook = iBook;
        }

        [HttpGet]
        public async Task<ActionResult<List<Book>>> Get(string title)
        {
            return await Task.FromResult(_iBook.GetByTitle(title));
        }
    }
}
