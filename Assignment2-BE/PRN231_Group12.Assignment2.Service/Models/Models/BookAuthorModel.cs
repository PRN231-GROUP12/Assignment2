using AutoMapper;
using PRN231_Group12.Assignment2.Repo;
using PRN231_Group12.Assignment2.Service.Common.Mapping;

namespace PRN231_Group12.Assignment2.Service.Models.Models;

public class BookAuthorModel : BaseModel, IMapFrom<BookAuthor>
{
    public int AuthorId { get; set; }
    public int BookId { get; set; }
    public string AuthorOrder { get; set; }
    public double RoyaltyPercentage { get; set; }
    
    // Navigation properties
    // public AuthorModel Author { get; set; }
    // public BookModel Book { get; set; }
    
    public void Mapping(Profile profile)
    {
        profile.CreateMap<BookAuthor, BookAuthorModel>()
            .ForMember(dest => dest.AuthorId,
                opt => opt.MapFrom(src => src.Author.AuthorId))
            .ForMember(dest => dest.BookId,
                opt => opt.MapFrom(src => src.Book.BookId));
    }
}