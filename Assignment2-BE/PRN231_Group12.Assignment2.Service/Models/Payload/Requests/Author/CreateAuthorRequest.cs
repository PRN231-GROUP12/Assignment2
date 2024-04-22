namespace PRN231_Group12.Assignment2.Service.Models.Payload.Requests.Author;

public class CreateAuthorRequest
{
    public string LastName { get; set; }
    public string FirstName { get; set; }
    public string Phone { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
    public string EmailAddress { get; set; }
}