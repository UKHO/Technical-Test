using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase

{
    private List<Book> books = new List<Book>()
        {
             new Book { Id = 1, Title = "Something", Author = "Someone", CoverImage = "https://picsum.photos/200/300" },

             new Book { Id = 2, Title = "How to test", Author = "Mr Tester", CoverImage = "https://picsum.photos/200/300" },

             new Book { Id = 3, Title = "Writing a book", Author = "Author", CoverImage = "https://picsum.photos/200/300" }

        };

    [HttpGet]
    public ActionResult GetBooks()

    {
        return Ok(books);
    }

    [HttpGet]
    public ActionResult GetBooks(string searchTerm)

    {
        var filteredBooks = books.Where(book => book.Title.ToLower().Contains(searchTerm.ToLower())).ToList();

        return Ok(filteredBooks);
    }
}