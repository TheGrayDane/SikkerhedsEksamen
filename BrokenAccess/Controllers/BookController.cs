using BrokenAccess.Data;
using BrokenAccess.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BrokenAccess.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {

        [HttpGet]
        public IActionResult GetBooks()
        {
            return Ok(Storage.BookList());
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] BookPostModel newBook)
        {
            if (Storage.LoggedIn().FirstOrDefault(u => u.Id == newBook.UserId) == null)
                return BadRequest("User not logged in"); //User is not logged in, cannot add book


            var books = Storage.BookList();

            var LastUsedId = books.LastOrDefault().Id;

            var book = new BookModel
            {
                Id = LastUsedId + 1,
                Title = newBook.Title,
                Author = newBook.Author,
                Price = newBook.Price
            };

            books.Add(book);

            if (books.Contains(book))
                return Ok("Book Added"); //Book added successfully

            return BadRequest("Some weired error happened"); //Book not added
        }

        [HttpPut]
        public IActionResult UpdateBook([FromBody] BookPostModel updatedBook)
        {

            if (Storage.LoggedIn().FirstOrDefault(u => u.Id == updatedBook.UserId) == null)
                return BadRequest("User not logged in"); //User is not logged in, cannot update book

            var books = Storage.BookList();
            var book = books.FirstOrDefault(b => b.Id == updatedBook.I);
            if (book == null)
                return NotFound("No book found"); //Book not found

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Price = updatedBook.Price;

            return Ok("Book updated"); //Book updated successfully
        }

        [HttpPost]
        public IActionResult DeleteBook([FromBody] BookPostModel deleteBook)
        {

            if (Storage.LoggedIn().FirstOrDefault(u => u.Id == deleteBook.UserId) == null)
                return BadRequest("User not logged in"); //User is not logged in, cannot delete book

            var books = Storage.BookList();
            var book = books.FirstOrDefault(b => b.Id == deleteBook.Id);
            if (book == null)
                return NotFound("No book found"); //Book not found
            else
                books.Remove(book);

            return Ok("Book deleted"); //Book deleted successfully
        }
    }
}
