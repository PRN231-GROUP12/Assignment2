namespace PRN231_Group12.Assignment2.Service.Models.Payload.Requests.Book;

public class UpdateBookRequest
{
    public string Title { get; set; }
    public string Type { get; set; }
    public decimal Price { get; set; }
    public decimal Advance { get; set; }
    public int Royalty { get; set; }
    public string Notes { get; set; }
}