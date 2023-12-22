using LogixTask.Domain.Login;
using LogixTask.Entities.Entities;

namespace LogixTask.Services.Interfaces
{
    public interface IUserValidator
    {
        /// <summary>
        /// Validates the user asynchronously.
        /// </summary>
        /// <param name="user">The request containing the user credentials to validate.</param>
        /// <returns>A task containing the validated user.</returns>
        Task<User> ValidateAsync(ValidatorRequest user);
    }
}
