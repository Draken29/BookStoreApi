using System.ComponentModel.DataAnnotations;

namespace BookStoreApi;

public class BookRequest
{
    [MinLength(3, ErrorMessage = "Title must be at least 3 characters long.")]
    public string Title { get; set; }
    [AllowedStrings(["Novel", "Documentary"])]
    public string Category { get; set; }
}

public class BooksRequest
{
    [MinLength(3, ErrorMessage = "Title must be at least 3 characters long.")]
    public string Title { get; set; }
    public string Category { get; set; }
}

public class Author
{
    public int Id { get; set; }
    public string Name { get; set; }
}
