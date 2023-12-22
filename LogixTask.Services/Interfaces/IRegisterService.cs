using LogixTask.Domain.Login;

namespace LogixTask.Services.Interfaces
{
    public interface IRegisterService
    {
        /// <param name="registerRequest">The user's register request.</param>
        /// <returns>A <see cref="Task"/> representing the asynchronous register operation.</returns>
        Task<LoginResponse> RegisterAsync(RegisterRequest registerRequest);
    }
}
