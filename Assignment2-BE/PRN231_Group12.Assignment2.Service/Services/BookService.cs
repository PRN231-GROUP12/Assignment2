using AutoMapper;
using Microsoft.EntityFrameworkCore;
using PRN231_Group12.Assignment2.Repo;
using PRN231_Group12.Assignment2.Repo.Entity;
using PRN231_Group12.Assignment2.Repo.Interfaces;
using PRN231_Group12.Assignment2.Service.Extensions;
using PRN231_Group12.Assignment2.Service.Interfaces;
using PRN231_Group12.Assignment2.Service.Models;
using PRN231_Group12.Assignment2.Service.Models.Models;
using PRN231_Group12.Assignment2.Service.Models.Payload.Requests.Book;
using Service.Models;

namespace PRN231_Group12.Assignment2.Service.Services;

public class BookService : IBookService
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IRepository<Book> _bookRepository;
    private readonly IRepository<Publisher> _publisherRepository;
    private readonly IRepository<Author> _authorRepository;
    private readonly IRepository<BookAuthor> _bookAuthorRepository;

    public BookService(IMapper mapper, IUnitOfWork unitOfWork)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _publisherRepository = _unitOfWork.GetRequiredRepository<Publisher>();
        _bookRepository = _unitOfWork.GetRequiredRepository<Book>();
        _authorRepository = _unitOfWork.GetRequiredRepository<Author>();
        _bookAuthorRepository = _unitOfWork.GetRequiredRepository<BookAuthor>();
    }

    public Task<PaginatedList<BookModel>> GetBooks(GetBooksRequest request)
    {
        var books = _bookRepository.GetAll()
            .Include(x => x.BookAuthors)
            .Include(x => x.Publisher)
            .AsQueryable();
        
        if (request.searchTerm is not null)
        {
            books = books.Where(x => x.Title.Contains(request.searchTerm));
        }

        if (request.price > 0)
        {
            books.Where(x => x.Price == request.price);
        }
        
        return books.ListPaginateWithSortAsync<Book, BookModel>(
            request.page,
            request.size,
            request.sortBy,
            request.sortOrder,
            _mapper.ConfigurationProvider
        );
    }

    public async Task<BookModel> GetBookById(int id)
    {
        var book = await _bookRepository.FindByCondition(x => x.BookId == id).Include(x => x.BookAuthors)
            .Include(x => x.Publisher)
            .FirstOrDefaultAsync();
        if (book is null)
        {
            throw new KeyNotFoundException("Book does not exist!");
        }

        return _mapper.Map<BookModel>(book);
    }

    public async Task<BookModel> CreateBook(CreateBookRequest request)
    {
        var date = request.PublishedDate.ToDateTime("PublishedDate");
        var publisher = await _publisherRepository.GetByIdAsync(request.PublisherId);
        if (publisher is null)
        {
            throw new KeyNotFoundException("Publisher does not exist!");
        }

        var bookAuthors = new List<BookAuthor>();
        
        var exist = _bookRepository.GetAll().ToList().Count > 0;
        var bookId = 1;
        if (exist)
        {
            bookId = _bookRepository.GetAll().Max(x => x.BookId) + 1;
        }
        
        var book = new Book()
        {
            BookId = bookId,
            PublishedDate = date,
            Advance = request.Advance,
            Notes = request.Notes,
            Price = request.Price,
            Royalty = request.Royalty,
            Title = request.Title,
            Type = request.Type,
            YtdSales = request.YtdSales,
            PublisherId = request.PublisherId
        };
        
        
        await _bookRepository.AddAsync(book);
        
        foreach (var id in request.AuthorIds)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author is null)
            {
                throw new KeyNotFoundException("Author does not exist!");
            }

            var bookAuthor = new BookAuthor()
            {
                AuthorId = id,
                BookId = bookId,
                RoyalityPercentage = request.Royalty,
                AuthorOrder = 1
            };

            await _bookAuthorRepository.AddAsync(bookAuthor);
        }

        await _unitOfWork.CommitAsync();
        
        var result = await _bookRepository.FindByCondition(x => x.BookId == bookId)
            .Include(x => x.BookAuthors)
            .Include(x => x.Publisher).FirstOrDefaultAsync();

        return _mapper.Map<BookModel>(result);
    }

    public async Task<BookModel> UpdateBook(int id, UpdateBookRequest request)
    {
        var book = await _bookRepository.GetByIdAsync(id);
        if (book is null)
        {
            throw new KeyNotFoundException("Book does not exist!");
        }

        book.Title = request.Title;
        book.Type = request.Type;
        book.Price = request.Price;
        book.Advance = request.Advance;
        book.Royalty = request.Royalty;
        book.Notes = request.Notes;

        var result = _bookRepository.Update(book);
        await _unitOfWork.CommitAsync();

        return _mapper.Map<BookModel>(result);
    }

    public async Task<BookModel> DeleteBook(int id)
    {
        var book = await _bookRepository.GetByIdAsync(id);

        if (book is null)
        {
            throw new KeyNotFoundException("Book does not exist");
        }

        var result = _bookRepository.Remove(id);
        await _unitOfWork.CommitAsync();

        return _mapper.Map<BookModel>(result);
    }
}