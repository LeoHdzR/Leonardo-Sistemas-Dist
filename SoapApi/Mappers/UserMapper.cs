
public static class UserMapper
{
    public static UserModel ToModel(this UserEntity user)
    {
        return new UserModel
        {
            Id = user.Id,
            Email = user.Email,
            FirstName = user.FirstName,
            LastName = user.LastName,
        }
    }

    public static UserResponseDto ToDto(this UserModel user)
    {
        
    }
}
