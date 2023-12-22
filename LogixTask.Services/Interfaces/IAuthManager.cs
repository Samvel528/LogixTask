using LogixTask.Domain.Login;

namespace LogixTask.Services.Interfaces
{
    public interface IAuthManager
    {
        /// <summary>
        /// Authenticates a user's login request.
        /// </summary>
        /// <param name="loginRequest">The user's login request.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous login operation.</returns>
        Task<LoginResponse> LoginAsync(LoginRequest loginRequest);
    }
}
