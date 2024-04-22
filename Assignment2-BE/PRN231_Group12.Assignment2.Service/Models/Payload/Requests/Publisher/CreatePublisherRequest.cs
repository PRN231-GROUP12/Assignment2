namespace PRN231_Group12.Assignment2.Service.Models.Payload.Requests.Publisher;

public class CreatePublisherRequest
{
    public string PublisherName { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Country { get; set; }
}