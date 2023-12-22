using LogixTask.Common.Exceptions;
using LogixTask.Domain.Enums;
using LogixTask.Domain.Login;
using LogixTask.Entities.Context;
using LogixTask.Entities.Entities;
using LogixTask.Services.Interfaces;

namespace LogixTask.Services.Implementations
{
    public class RegisterService : IRegisterService
    {
        private readonly LogixTaskDbContext _context;
        private readonly ITokenProvider _tokenProvider;

        public RegisterService(ITokenProvider tokenProvider, LogixTaskDbContext context)
        {
            _tokenProvider = tokenProvider ?? throw new RestApiResponseException(nameof(tokenProvider));
            _context = context;
        }

        public async Task<LoginResponse> RegisterAsync(RegisterRequest registerRequest)
        {
            User user = new User()
            {
                Address = registerRequest.Address,
                DateOfBirth = registerRequest.DateOfBirth,
                FirstName = registerRequest.FirstName,
                LastName = registerRequest.LastName,
                Email = registerRequest.Email,
                FullName = registerRequest.FirstName + ' ' + registerRequest.LastName,
                Password = registerRequest.Password,
                PhoneNumber = registerRequest.PhoneNumber,
                UserTypeId = (int)UserTypeEnum.User
            };

            await _context.AddAsync(user);
            await _context.SaveChangesAsync();
            var loginResponse = await _tokenProvider.GetToken(user);

            return loginResponse;
        }
    }
}
