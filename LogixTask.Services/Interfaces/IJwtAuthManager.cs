using LogixTask.Domain.Login;
using System.Security.Claims;

namespace LogixTask.Services.Interfaces;


public interface IJwtAuthManager
{
    /// <summary>
    /// Generates access and refresh tokens for the given user.
    /// </summary>
    /// <param name="username">Username for whom the tokens are being generated</param>
    /// <param name="claims">Claims that the tokens should contain</param>
    /// <param name="now">Current time</param>
    /// <returns>The generated tokens as a <see cref="JwtAuthResult"/> object</returns>
    JwtAuthResult GenerateTokens(string username, Claim[] claims, DateTime now);

    /// <summary>
    /// Refreshes an access token using the given refresh token.
    /// </summary>
    /// <param name="refreshToken">Refresh token to use for refreshing the access token</param>
    /// <param name="accessToken">Access token to refresh</param>
    /// <param name="now">Current time</param>
    /// <returns>The refreshed tokens as a <see cref="JwtAuthResult"/> object</returns>
    JwtAuthResult Refresh(string refreshToken, string accessToken, DateTime now);

    /// <summary>
    /// Decodes a JWT token and returns the claims extracted from it.
    /// </summary>
    /// <param name="token">JWT token to decode</param>
    /// <returns>A <see cref="ClaimsPrincipal"/> object containing the claims extracted from the token</returns>
    ClaimsPrincipal DecodeJwtToken(string token);

    /// <summary>
    /// Generates an access token with the given claims and expiry time.
    /// </summary>
    /// <param name="claims">Claims that the token should contain</param>
    /// <param name="now">Current time</param>
    /// <param name="minuteExpiry">Expiry time of the token in minutes</param>
    /// <returns>The generated access token as a string</returns>
    string GenerateAccessToken(Claim[] claims, DateTime now, double minuteExpiry);
}
