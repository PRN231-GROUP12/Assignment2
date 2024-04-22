using Service.Models;

namespace PRN231_Group12.Assignment2.Service.Models.Payload.Requests.Book;

public class GetBooksRequest : PaginatedQueryParams
{
    public decimal price { get; set; }
}