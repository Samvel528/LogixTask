using LogixTask.Domain.Login;

namespace LogixTask.Services.Interfaces
{
    public interface IRefreshTokenHandler
    {
        /// <summary>
        /// Handles refreshing the token for the given refresh token request.
        /// </summary>
        /// <param name="request">The refresh token request.</param>
        /// <returns>The login response with the new token information.</returns>
        Task<LoginResponse> RefreshTokenHandle(RefreshTokenRequest request);
    }
}
