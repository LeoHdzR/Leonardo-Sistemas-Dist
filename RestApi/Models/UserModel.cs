namespace RestApi.Models;

public class UserModel{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = null;
    public string LastName { get; set; } = null;
    public string? Email { get; set; }
    public DateTime BirthDay{ get; set; }

}