using PRN231_Group12.Assignment2.Service.Models;
using PRN231_Group12.Assignment2.Service.Models.Models;
using PRN231_Group12.Assignment2.Service.Models.Payload.Requests.Book;
using Service.Models;

namespace PRN231_Group12.Assignment2.Service.Interfaces;

public interface IBookService
{
    Task<PaginatedList<BookModel>> GetBooks(GetBooksRequest request);
    Task<BookModel> GetBookById(int id);
    Task<BookModel> CreateBook(CreateBookRequest request);
    Task<BookModel> UpdateBook(int id, UpdateBookRequest request);
    Task<BookModel> DeleteBook(int id);
}