using AutoMapper;
using PRN231_Group12.Assignment2.Repo;
using PRN231_Group12.Assignment2.Service.Common.Mapping;

namespace PRN231_Group12.Assignment2.Service.Models.Models;

public class UserModel : BaseModel, IMapFrom<User>
{
    public string Email { get; set; }
    public string Password { get; set; }
    public string Source { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public int RoleId { get; set; }
    public int PublisherId { get; set; }
    public DateTime HiredDate { get; set; }
    
    // Navigation properties
    public RoleModel Role { get; set; }
    public PublisherModel Publisher { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, UserModel>()
            .ForMember(dest => dest.PublisherId,
                opt => opt.MapFrom(src => src.Publisher.PublisherId))
            .ForMember(dest => dest.RoleId, opt => opt.MapFrom(src => src.Role.RoleId));
    }
}