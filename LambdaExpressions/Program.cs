var books = new BookRepository().GetBooks();
var cheapBooks = books.FindAll(b => b.Price < 10);
Console.WriteLine(string.Join(", ", cheapBooks));

record BookRepository
{
    public List<Book> GetBooks() => new()
    {
        new Book(Title: "Title 1", Price: 5),
        new Book(Title: "Title 2", Price: 7),
        new Book(Title: "Title 3", Price: 17),
    };
}

record Book(string Title, float Price);
