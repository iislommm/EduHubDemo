using Application.Abstractions.Repositories;
using Application.Dtos;
using Application.FluintValidation;
using Application.Helpers;
using Application.Helpers.PasswordHasher;
using Application.Repositories;
using Core.Core.Errors;
using Core.Errors;
using Domain.Entities;

namespace Application.ServiceContracts.ServiceImplementations;

public class AuthService(
    IUserRepository userRepository,
    ITokenService tokenService,
    IRefreshTokenRepository refreshTokenRepository,
    IRoleRepository roleRepository,
    IPasswordHasher passwordHasher
) : IAuthService
{
    
    public async Task<LoginResponseDto> LoginUserAsync(UserLoginDto dto)
    {
        var validator = new UserLoginDtoValidator();
        var result = validator.Validate(dto);

        if (!result.IsValid)
        {
            var errors = string.Join("\n", result.Errors.Select(e => e.ErrorMessage));
            throw new ValidateFailedException(errors);
        }

        var user = await userRepository.SelectUserByUserNameAsync(dto.UserName)
                   ?? throw new UnauthorizedException("User or password incorrect");

        var isPasswordCorrect = passwordHasher.Verify(dto.Password, user.PasswordHash, user.PasswordSalt);
        if (!isPasswordCorrect)
            throw new UnauthorizedException("User or password incorrect");

        var accessToken = tokenService.GenerateTokent(new UserGetDto
        {
            UserId = user.Id,
            FirstName = user.FirstName,
            SecondName = user.SecondName,
            Email = user.Email,
            UserName = user.UserName,
            PhoneNumber = user.PhoneNumber,
            Role = user.Role.Name,
        });

        var existingRefresh = await refreshTokenRepository.SelectActiveTokenByUserIdAsync(user.Id);

        var response = new LoginResponseDto
        {
            AccessToken = accessToken,
            TokenType = "Bearer",
            Expires = 24,
            RefreshToken = existingRefresh?.Token ?? await GenerateAndStoreRefreshTokenAsync(user.Id)
        };

        return response;
    }

    public async Task<long> SignUpUserAsync(SignUpDto dto)
    {
        var validator = new UserCreateDtoValidator();

        var result = validator.Validate(dto);

        if (!result.IsValid)
        {
            var errors = string.Join("\n", result.Errors.Select(e => e.ErrorMessage));
            throw new ValidateFailedException(errors);
        }

        var (hash, salt) = passwordHasher.Hash(dto.Password);

        var role = await roleRepository.SelectRoleIdByNameAsync("User");

        var user = new User
        {
            FirstName = dto.FirstName,
            SecondName = dto.SecondName,
            UserName = dto.Username,
            PhoneNumber = dto.PhoneNumber,
            Email = dto.Email,
            PasswordHash = hash,
            PasswordSalt = salt,
            Age = dto.Age,
            RoleId = role,
        };

        return await userRepository.InsertUserAsync(user);
    }

    public async Task LogoutAsync(string refreshToken)
    {
        await refreshTokenRepository.RemoveRefreshTokenAsync(refreshToken);
    }

    public async Task<LoginResponseDto> RefreshTokenAsync(RefreshRequestDto request)
    {
        var principal = tokenService.GetPrincipalFromExpiredToken(request.AccessToken)
                        ?? throw new ForbiddenException("Invalid Access token");

        var userIdClaim = principal.FindFirst(c => c.Type == "UserId")
                           ?? throw new ForbiddenException("Invalid claims");

        var userId = long.Parse(userIdClaim.Value);

        var existingToken = await refreshTokenRepository.SelectRefreshTokenAsync(request.RefreshToken, userId);
        if (existingToken is null || existingToken.IsRevoked || existingToken.Expires < DateTime.UtcNow)
            throw new UnauthorizedException("Refresh token is invalid or expired");

        existingToken.IsRevoked = true;

        var user = await userRepository.SelectUserByIdAsync(userId)
                   ?? throw new NotFoundException("User not found");

        // Bu ishlashi kerak
        var newAccessToken = tokenService.GenerateTokent(new UserGetDto
        {
            UserId = user.Id,
            FirstName = user.FirstName,
            SecondName = user.SecondName,
            Email = user.Email,
            UserName = user.UserName,
            PhoneNumber = user.PhoneNumber,
            Role = user.Role.Name,
        });


        var newRefreshToken = await GenerateAndStoreRefreshTokenAsync(user.Id);

        return new LoginResponseDto
        {
            AccessToken = newAccessToken,
            RefreshToken = newRefreshToken,
            TokenType = "Bearer",
            Expires = 900
        };
    }

    private async Task<string> GenerateAndStoreRefreshTokenAsync(long userId)
    {
        var refreshToken = tokenService.GenerateRefreshToken();

        var tokenToStore = new RefreshToken
        {
            Token = refreshToken,
            Expires = DateTime.UtcNow.AddDays(21),
            IsRevoked = false,
            UserId = userId
        };

        await refreshTokenRepository.InsertRefreshTokenAsync(tokenToStore);
        return refreshToken;
    }

}
