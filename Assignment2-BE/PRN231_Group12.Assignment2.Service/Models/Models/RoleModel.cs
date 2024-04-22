using PRN231_Group12.Assignment2.Repo;
using PRN231_Group12.Assignment2.Service.Common.Mapping;

namespace PRN231_Group12.Assignment2.Service.Models.Models;

public class RoleModel : BaseModel, IMapFrom<Role>
{
    public string Description { get; set; }
}