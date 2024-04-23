using PRN231_Group12.Assignment2.Repo;
using PRN231_Group12.Assignment2.Repo.Entity;
using PRN231_Group12.Assignment2.Service.Common.Mapping;

namespace PRN231_Group12.Assignment2.Service.Models.Models;

public class PublisherModel : BaseModel, IMapFrom<Publisher>
{
    public int PublisherId { get; set; }
    public string? PublisherName { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Country { get; set; }
    
    // Navigations
    // public ICollection<UserModel> Users { get; set; }
    // public ICollection<BookModel> Books { get; set; }
}