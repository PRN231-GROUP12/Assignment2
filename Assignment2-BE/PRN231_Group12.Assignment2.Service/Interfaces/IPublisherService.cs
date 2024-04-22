using PRN231_Group12.Assignment2.Service.Models;
using PRN231_Group12.Assignment2.Service.Models.Models;
using PRN231_Group12.Assignment2.Service.Models.Payload.Requests.Publisher;
using Service.Models;

namespace PRN231_Group12.Assignment2.Service.Interfaces;

public interface IPublisherService
{
    Task<PaginatedList<PublisherModel>> GetPublishers(GetPublisherRequest request);
    Task<PublisherModel> GetPublisherById(int id);
    Task<PublisherModel> CreatePublisher(CreatePublisherRequest request);
    Task<PublisherModel> UpdatePublisher(int id, UpdatePublisherRequest request);
    Task<PublisherModel> DeletePublisher(int id);
}