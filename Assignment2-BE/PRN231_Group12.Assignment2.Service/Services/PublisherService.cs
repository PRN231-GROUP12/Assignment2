using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PRN231_Group12.Assignment2.Repo.Entity;
using PRN231_Group12.Assignment2.Repo.Interfaces;
using PRN231_Group12.Assignment2.Service.Extensions;
using PRN231_Group12.Assignment2.Service.Interfaces;
using PRN231_Group12.Assignment2.Service.Models;
using PRN231_Group12.Assignment2.Service.Models.Models;
using PRN231_Group12.Assignment2.Service.Models.Payload.Requests.Publisher;

namespace PRN231_Group12.Assignment2.Service.Services;

public class PublisherService : IPublisherService
{
    private readonly IUnitOfWork _uow;
    private readonly IRepository<Publisher> _publisherRepository;
    private readonly IMapper _mapper;

    public PublisherService(IUnitOfWork uow, IRepository<Publisher> publisherRepository, IMapper mapper)
    {
        _uow = uow;
        _publisherRepository = _uow.GetRequiredRepository<Publisher>();
        _mapper = mapper;
    }

    public async Task<PaginatedList<PublisherModel>> GetPublishers(GetPublisherRequest request)
    {
        var publishers = _publisherRepository.GetAll().Include(x => x.Books).AsQueryable();

        return await publishers.ListPaginateWithSortAsync<Publisher, PublisherModel>(
            request.page,
            request.size,
            request.sortBy,
            request.sortOrder,
            _mapper.ConfigurationProvider
        );
    }

    public async Task<PublisherModel> GetPublisherById(int id)
    {
        var publisher = await _publisherRepository
            .FindByCondition(x => x.PublisherId == id)
            .Include(x => x.Books).FirstOrDefaultAsync();

        if (publisher is null)
        {
            throw new KeyNotFoundException("Publisher does not exist!");
        }

        return _mapper.Map<PublisherModel>(publisher);
    }

    public async Task<PublisherModel> CreatePublisher(CreatePublisherRequest request)
    {
        var entity = new Publisher()
        {
            City = request.City,
            Country = request.Country,
            State = request.State,
            PublisherName = request.PublisherName,
        };

        var result = await _publisherRepository.AddAsync(entity);
        await _uow.CommitAsync();

        return _mapper.Map<PublisherModel>(result);
    }

    public async Task<PublisherModel> UpdatePublisher(int id, UpdatePublisherRequest request)
    {
        var publisher = await _publisherRepository.GetByIdAsync(id);
        if (publisher is null)
        {
            throw new KeyNotFoundException("Publisher does not exist!");
        }

        publisher.City = request.City;
        publisher.Country = request.Country;
        publisher.State = request.State;
        publisher.PublisherName = request.PublisherName;

        var result = _publisherRepository.Update(publisher);
        await _uow.CommitAsync();

        return _mapper.Map<PublisherModel>(result);
    }

    public async Task<PublisherModel> DeletePublisher(int id)
    {
        var publisher = await _publisherRepository.GetByIdAsync(id);
        if (publisher is null)
        {
            throw new KeyNotFoundException("Publisher does not exists");
        }

        var result = _publisherRepository.Remove(id);
        await _uow.CommitAsync();

        return _mapper.Map<PublisherModel>(result);
    }
}