using LogixTask.Common.Exceptions;
using LogixTask.Domain.Login;
using LogixTask.Services.Interfaces;

namespace LogixTask.Services.Implementations
{
    internal class AuthManager : IAuthManager
    {
        private readonly ITokenProvider _tokenProvider;
        private readonly IUserValidator _userValidator;

        public AuthManager(IUserValidator userValidator, ITokenProvider tokenProvider)
        {
            _userValidator = userValidator ?? throw new RestApiResponseException(nameof(userValidator));
            _tokenProvider = tokenProvider ?? throw new RestApiResponseException(nameof(tokenProvider));
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
        {
            var user = await _userValidator.ValidateAsync(new ValidatorRequest
            {
                Email = loginRequest.Email,
                Password = loginRequest.Password
            });

            var loginResponse = await _tokenProvider.GetToken(user);

            return loginResponse;
        }
    }
}
