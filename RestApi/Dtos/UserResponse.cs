namespace RespApi.Dtos;

public class UserResponse {
    public Guid Id { get; set; }
    public string Name { get; set;}
    public string Email { get; set;}
    public List<UserResponse> Users {get; set;}
}