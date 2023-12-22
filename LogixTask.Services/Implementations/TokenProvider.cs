using LogixTask.Common.Exceptions;
using LogixTask.Domain.Login;
using LogixTask.Entities.Entities;
using LogixTask.Services.Interfaces;
using Microsoft.Extensions.Logging;
using System.Security.Claims;

namespace LogixTask.Services.Implementations;

public class TokenProvider : ITokenProvider
{
    private readonly IJwtAuthManager _jwtAuthManager;
    private readonly ILogger<TokenProvider> _logger;

    public TokenProvider(IJwtAuthManager jwtAuthManager, ILogger<TokenProvider> logger)
    {
        _jwtAuthManager = jwtAuthManager ?? throw new RestApiResponseException(nameof(jwtAuthManager));
        _logger = logger ?? throw new RestApiResponseException(nameof(logger));
    }

    public async Task<LoginResponse> GetToken(User user)
    {
        var claims = new[]
        {
            new Claim(ClaimTypes.Email,user.Email),
            new Claim(ClaimTypes.Name,user.FirstName),
            new Claim(ClaimTypes.Surname,user.LastName),
            new Claim(ClaimTypes.Sid,user.Id.ToString()),
            new Claim(ClaimTypes.NameIdentifier, user.UserTypeId.ToString()),
        };
        var jwtResult = _jwtAuthManager.GenerateTokens(user.Email, claims, DateTime.UtcNow);
        _logger.LogDebug($"User: {user.Email}  JWT: {jwtResult.AccessToken}");
        var returnUser = new LoginResponse
        {
            AccessToken = jwtResult.AccessToken,
            Email = user.Email,
            UserType = user.UserTypeId,
            FirstName = user.FirstName,
            LastName = user.LastName
        };

        return returnUser;
    }
}