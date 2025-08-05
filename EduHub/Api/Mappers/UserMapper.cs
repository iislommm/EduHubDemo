using Application.Dtos;

namespace Application.Mappers;

public static class UserMapper
{

    public static UserGetDto ToUserGetDto(User dto)
    {
        return new UserGetDto
        {
            FirstName = dto.FirstName,
            SecondName = dto.SecondName,
            UserName = dto.UserName,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email,
            Age = dto.Age,
            Role = dto.Role.Name,
        };
    }
}
