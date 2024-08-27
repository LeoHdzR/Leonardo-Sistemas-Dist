using System.Threading;
using System;
using SoapApi.Contracts;
using SoapApi.Dtos;

namespace SoapApi.Services;

public class UserService : IUserContract
{
    public readonly IUserService UserService;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }
    public async Task<UserResponseDto> GetUserById(Guid userId, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetByIdAsync(userId, cancellationToken);
        if (user == null)
        {
            return user.ToDto();
        }

        throw new FaultException(reason: "User not found");
    }
}