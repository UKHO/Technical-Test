namespace FrontendChallenge.Web.Repo
{
    public class BookRepo: IBookRepo
    {
        private List<Book> books = new List<Book>()
        {
             new Book { Id = 1, Title = "Something", Author = "Someone", CoverImage = "https://picsum.photos/200/300" },
             new Book { Id = 2, Title = "How to test", Author = "Mr Tester", CoverImage = "https://picsum.photos/200/300" },
             new Book { Id = 3, Title = "Writing a book", Author = "Author", CoverImage = "https://picsum.photos/200/300" }
        };

        public BookRepo() { }

        public List<Book> GetBooks() 
        {
            return books;
        }
    }
}
