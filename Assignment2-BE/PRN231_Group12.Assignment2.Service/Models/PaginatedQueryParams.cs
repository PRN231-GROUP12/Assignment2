namespace Service.Models;

public class PaginatedQueryParams
{
    public int? page { get; set; }
    public int? size { get; set; }
    public string? searchTerm { get; set; }
    public string? sortBy { get; set; }
    public string? sortOrder { get; set; }
}