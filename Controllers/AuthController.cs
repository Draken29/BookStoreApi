using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers;

[ApiController]
[Route("/[controller]")]
public class Authorcontroller : ControllerBase
{
    public static List<Author> Authors = new List<Author>(){
        new Author { Id = 1, Name = "George Orwell" },  
        new Author { Id = 2, Name = "Yuval Noah Harari" }
    };

    // DTO for POST /authors
    public class AuthorRequest
    {
        public string Name { get; set; } = string.Empty;
    }

    [HttpGet]
    public ActionResult<List<Author>> GetAuthors()
    {
        return Ok(Authors);
    }

    [HttpGet("{id:int}")]
    public ActionResult<Author> GetSingleAuthor(int id)
    {
        return Authors.FirstOrDefault(a => a.Id == id) is Author author ? Ok(author) : NotFound();
    }
      
    [HttpPost]
    public ActionResult CreateAuthor([FromBody] AuthorRequest request)
    {
        if (string.IsNullOrWhiteSpace(request.Name) || request.Name.Length < 3)
            return BadRequest("Name must be at least 3 characters.");

        var newId = Authors.Any() ? Authors.Max(a => a.Id) + 1 : 1;

        var newAuthor = new Author
        {
            Id = newId,
            Name = request.Name
        };

        Authors.Add(newAuthor);
        return Created(string.Empty, newAuthor);
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteAuthor(int id)
    {
        var author = Authors.FirstOrDefault(a => a.Id == id);
        if (author is null)
            return NotFound();
        Authors.Remove(author);
        return NoContent();
    }
}