using LogixTask.Common.Constants;
using LogixTask.Common.Exceptions;
using LogixTask.Domain.Login;
using LogixTask.Entities.Context;
using LogixTask.Services.Interfaces;
using System.Net;
using System.Security.Claims;

namespace LogixTask.Services.Implementations;

public class RefreshTokenHandler : IRefreshTokenHandler
{
    private readonly IJwtAuthManager _jwtAuthManager;
    private readonly ITokenProvider _tokenProvider;
    private readonly LogixTaskDbContext _context;

    public RefreshTokenHandler(ITokenProvider tokenProvider, IJwtAuthManager jwtAuthManager, LogixTaskDbContext context)
    {
        _tokenProvider = tokenProvider ?? throw new RestApiResponseException(nameof(tokenProvider));
        _jwtAuthManager = jwtAuthManager ?? throw new RestApiResponseException(nameof(jwtAuthManager));
        _context = context ?? throw new RestApiResponseException(nameof(context));
    }

    public async Task<LoginResponse> RefreshTokenHandle(RefreshTokenRequest request)
    {
        var tokenParts = request.ExpiredAccessToken.Split(" ");

        if (tokenParts.Length != 2)
        {
            throw new RestApiResponseException(ExceptionMessages.InvalidToken);
        }

        if (!tokenParts[0].Equals("Bearer", StringComparison.InvariantCultureIgnoreCase))
        {
            throw new RestApiResponseException(ExceptionMessages.InvalidToken);
        }

        var principal = _jwtAuthManager.DecodeJwtToken(tokenParts[1]);

        if (principal?.Identity == null)
        {
            throw new RestApiResponseException(ExceptionMessages.InvalidToken);
        }

        int? userId = int.Parse(principal.Identities?.FirstOrDefault()?.Claims?.FirstOrDefault(x => x.Type == ClaimTypes.Sid)?.Value);

        if (userId == null)
        {
            throw new RestApiResponseException((int)HttpStatusCode.NotFound, ExceptionMessages.UserNotFound);
        }

        var user = await _context.Users.FindAsync(userId.Value);

        if (user == null)
        {
            throw new RestApiResponseException((int)HttpStatusCode.NotFound, ExceptionMessages.UserNotFound);
        }

        return await _tokenProvider.GetToken(user);
    }
}