using LogixTask.Domain.Login;
using LogixTask.Entities.Entities;

namespace LogixTask.Services.Interfaces
{
    public interface ITokenProvider
    {
        /// <summary>
        /// Retrieves a token for a specified user.
        /// </summary>
        /// <param name="user">The user for which to retrieve a token.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous operation that returns a <see cref="LoginResponse"/> object containing the token information.</returns>
        Task<LoginResponse> GetToken(User user);
    }
}
