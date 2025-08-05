using Application.Dtos;

namespace Application.ServiceContracts;

public interface IAuthService
{
    Task<LoginResponseDto> LoginUserAsync(UserLoginDto dto);
    Task<long> SignUpUserAsync(SignUpDto dto);
    Task<LoginResponseDto> RefreshTokenAsync(RefreshRequestDto request);
    Task LogoutAsync(string refreshToken);
}
