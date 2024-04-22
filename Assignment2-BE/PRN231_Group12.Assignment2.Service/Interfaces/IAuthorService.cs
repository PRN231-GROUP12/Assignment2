using PRN231_Group12.Assignment2.Service.Models;
using PRN231_Group12.Assignment2.Service.Models.Models;
using PRN231_Group12.Assignment2.Service.Models.Payload.Requests.Author;
using Service.Models;

namespace PRN231_Group12.Assignment2.Service.Interfaces;

public interface IAuthorService
{
    Task<PaginatedList<AuthorModel>> GetAuthors(GetAuthorsRequest request);
    Task<AuthorModel> GetAuthorById(int id);
    Task<AuthorModel> CreateAuthor(CreateAuthorRequest request);
    Task<AuthorModel> UpdateAuthor(int id, UpdateAuthorRequest request);
    Task<AuthorModel> DeleteAuthor(int id);
}