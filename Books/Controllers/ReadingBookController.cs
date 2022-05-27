using Books.Entities;
using Books.Interface;
using Books.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Books.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ReadingBookController : ControllerBase
    {

        readonly IUserBookService _iUserBook;
        readonly IUserService _userService;
        readonly IBookService _bookService;
        const string READING_STATUS_COMPLETE = "Completed";
        const string READING_STATUS_INPROGRESS = "Reading";
        public ReadingBookController(IUserBookService iUserBook, IUserService userService, IBookService bookService)
        {
            _iUserBook = iUserBook;
            _userService = userService;
            _bookService = bookService;
        }
        private string CurrentUsername
        {
            get
            {
                if (HttpContext.User.Identity is ClaimsIdentity identity)
                {
                    string username = identity.FindFirst(ClaimTypes.Name).Value;
                    return username;
                };
                return String.Empty;
            }
        }
        private int CurrentUserId
        {
            get
            {
                return (_userService.GetByUsername(CurrentUsername)?.Id) ?? throw new InvalidOperationException("User does not logon");
            }
        }

        [HttpGet]
        public ActionResult<List<UserBookDetailModel>> Get(string? status)
        {
            var listBookByUser = _iUserBook.GetByUser(CurrentUserId);
            listBookByUser = listBookByUser.Where(e => e.Status == status).ToList();
            var resultList = listBookByUser.Select(e => new UserBookDetailModel()
            {
                Id = e.Id,
                BookId = e.BookId,
                BookTitle = _bookService.GetById(e.BookId).Title,
                Status = e.Status
            }).ToList();
            return resultList;
        }

        [HttpPost]
        public ActionResult<ReadingBook> Add(ReadingBook userBook)
        {
            userBook.Status = READING_STATUS_INPROGRESS;
            userBook.UserId = CurrentUserId;
            var returnModel = _iUserBook.AddBook(userBook);
            return returnModel;
        }
        [HttpPut("{id}/Status")]
        public ActionResult Update(int id, ReadingBook updateReadingBookStatus)
        {
            ReadingBook userBook = new ReadingBook()
            {
                BookId = id,
                UserId = CurrentUserId,
                Status = updateReadingBookStatus.Status,
            };
            _iUserBook.UpdateBook(userBook);
            return Ok();
        }

    }
}
