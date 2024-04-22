namespace PRN231_Group12.Assignment2.Service.Models.Payload.Requests.Book;

public class CreateBookRequest
{
    public string Title { get; set; }
    public string Type { get; set; }
    public int PublisherId { get; set; }
    public decimal Price { get; set; }
    public decimal Advance { get; set; }
    public decimal Royalty { get; set; }
    public int YtdSales { get; set; }
    public string Notes { get; set; }
    public string PublishedDate { get; set; }
    
    public int[] AuthorIds { get; set; }
}