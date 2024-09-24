using RestApi.Models;
using RestApi.Infrasctructure.Soap.SoapContracts;

namespace RespApi.Mappers;

public static class UserMapper{
    public static UserModel ToDomain(this UserResponseDto user){
        if (user is null)
        {
            return null;
        }

        return new UserModel{
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            BirthDay = user.BirthDate,

        };
    }
}