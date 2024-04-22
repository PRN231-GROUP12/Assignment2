using PRN231_Group12.Assignment2.Repo;
using PRN231_Group12.Assignment2.Service.Common.Mapping;

namespace PRN231_Group12.Assignment2.Service.Models.Models;

public class AuthorModel : BaseModel, IMapFrom<Author>
{
    public int AuthorId { get; set; }
    public string? LastName { get; set; }
    public string? FirstName { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Zip { get; set; }
    public string? EmailAddress { get; set; }
    
    // Navigations Properties
    // public ICollection<BookAuthorModel> BookAuthors { get; set; }
}