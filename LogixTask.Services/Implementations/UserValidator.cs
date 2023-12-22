using LogixTask.Common.Constants;
using LogixTask.Common.Exceptions;
using LogixTask.Domain.Login;
using LogixTask.Entities.Context;
using LogixTask.Entities.Entities;
using LogixTask.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace LogixTask.Services.Implementations
{
    public class UserValidator : IUserValidator
    {
        private readonly LogixTaskDbContext _context;

        public UserValidator(LogixTaskDbContext context)
        {
            _context = context;
        }

        public async Task<User> ValidateAsync(ValidatorRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.ToUpper() == request.Email.ToUpper());
            if (user == null)
            {
                throw new RestApiResponseException((int)HttpStatusCode.NotFound, ExceptionMessages.InvalidCredentials);
            }

            return user;
        }
    }
}
