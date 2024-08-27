namespace SoapApi.Dtos;

[DataContract]

public class UserResponseDto
{
    public Guid UserId {get; set;}
    public Guid Id {get; set;}
    public string Email {get; set;} = null;
    public string FirstName {get; set;} = null;
    public string LastName {get; set;} = null;
}