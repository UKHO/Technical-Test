using Microsoft.AspNetCore.Mvc;
using FrontendChallenge.Web.Repo;

[ApiController]
[Route("api/[controller]")]
public class BooksController : ControllerBase

{
    private IBookRepo bookRepo = new BookRepo(); 

    [HttpGet]
    public ActionResult GetBooks()
    {
        return Ok(bookRepo.GetBooks());
    }

    [HttpGet("{id}")]
    public ActionResult SearchBooks(string searchTerm)
    {
        var bl = new List<Book>();

        foreach (var book in bookRepo.GetBooks())
        {
            var title = book.Title.ToLower();
            if (title.Contains(searchTerm.ToLower()))
            {
                bl.Add(book);
            }
        }
        //var filteredBooks = books.Where(book => book.Title.ToLower()
        //                                        .Contains(searchTerm.ToLower()))
        //                                        .ToList();

        return Ok(bl);
    }
}