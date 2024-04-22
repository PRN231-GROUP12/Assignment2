using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PRN231_Group12.Assignment2.Repo;
using PRN231_Group12.Assignment2.Repo.Interfaces;
using PRN231_Group12.Assignment2.Service.Extensions;
using PRN231_Group12.Assignment2.Service.Interfaces;
using PRN231_Group12.Assignment2.Service.Models;
using PRN231_Group12.Assignment2.Service.Models.Models;
using PRN231_Group12.Assignment2.Service.Models.Payload.Requests.Author;
using Service.Models;

namespace PRN231_Group12.Assignment2.Service.Services;

public class AuthorService : IAuthorService
{
    private readonly IUnitOfWork _uow;
    private readonly IMapper _mapper;
    private readonly IRepository<Author> _authorRepository;

    public AuthorService(IUnitOfWork uow, IMapper mapper, IRepository<Author> authorRepository)
    {
        _uow = uow;
        _mapper = mapper;
        _authorRepository = _uow.GetRequiredRepository<Author>();
    }

    public async Task<PaginatedList<AuthorModel>> GetAuthors(GetAuthorsRequest request)
    {
        var authors = _authorRepository.GetAll().AsQueryable();

        return await authors.ListPaginateWithSortAsync<Author, AuthorModel>(
            request.page,
            request.size,
            request.sortBy,
            request.sortOrder,
            _mapper.ConfigurationProvider
        );
    }

    public async Task<AuthorModel> GetAuthorById(int id)
    {
        var author = await _authorRepository.GetByIdAsync(id);

        if (author is null)
        {
            throw new KeyNotFoundException("Author does not exist!");
        }

        return _mapper.Map<AuthorModel>(author);
    }

    public async Task<AuthorModel> CreateAuthor(CreateAuthorRequest request)
    {
        var author = await _authorRepository.FindByCondition(x => x.EmailAddress == request.EmailAddress).FirstOrDefaultAsync();
        if (author is not null)
        {
            throw new InvalidOperationException("Author already exist");
        }

        var entity = new Author()
        {
            EmailAddress = request.EmailAddress,
            Address = request.Address,
            FirstName = request.FirstName,
            City = request.City,
            LastName = request.LastName,
            Phone = request.Phone,
            State = request.State,
            Zip = request.Zip,
        };

        var result = await _authorRepository.AddAsync(entity);
        await _uow.CommitAsync();
        return _mapper.Map<AuthorModel>(result);
    }

    public async Task<AuthorModel> UpdateAuthor(int id, UpdateAuthorRequest request)
    {
        var author = await _authorRepository.GetByIdAsync(id);
        if (author is null)
        {
            throw new KeyNotFoundException("Author already exist");
        }

        author.Address = request.Address;
        author.FirstName = request.FirstName;
        author.LastName = request.LastName;
        author.City = request.City;
        author.EmailAddress = request.EmailAddress;
        author.Phone = request.Phone;
        author.State = request.State;
        author.Zip = request.Zip;

        var result = _authorRepository.Update(author);
        return _mapper.Map<AuthorModel>(author);
    }

    public async Task<AuthorModel> DeleteAuthor(int id)
    {
        var author = await _authorRepository.GetByIdAsync(id);
        if (author is null)
        {
            throw new KeyNotFoundException("Author does not exist!");
        }

        var result =  _authorRepository.Remove(id);
        await _uow.CommitAsync();

        return _mapper.Map<AuthorModel>(author);
    }
}