using LogixTask.Domain.Models;
using LogixTask.Entities.Context;
using LogixTask.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LogixTask.Services.Implementations;

public class AdminOperations : IAdminOperations
{
    private readonly LogixTaskDbContext _context;
    private readonly IAddressService _addressService;
    private readonly IPatternReplacementService _patternReplacementService;

    public AdminOperations(LogixTaskDbContext context, IAddressService addressService, IPatternReplacementService patternReplacementService)
    {
        _context = context;
        _addressService = addressService;
        _patternReplacementService = patternReplacementService;
    }

    public void AddUser(AddUser user)
    {
        var address = _patternReplacementService.ReplacePattern(user.Address);
        var completedAddress = _addressService.ProcessAddress(address);

        Entities.Entities.User addedUser = new Entities.Entities.User()
        {
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Password = user.Password,
            Address = completedAddress,
            UserTypeId = 2,
            DateOfBirth = user.DateOfBirth,
            FullName = user.FirstName + ' ' + user.LastName,
            PhoneNumber = user.PhoneNumber,
        };

        _context.Users.Add(addedUser);
        _context.SaveChanges();
    }

    public void DeleteUser(int id)
    {
        var user = _context.Users.FirstOrDefault(x => x.Id == id);

        if (user != null)
        {
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }

    public void EditUser(EditUser editUser, int userId)
    {
        var user = _context.Users.FirstOrDefault(u => u.Id == userId);
        var address = _patternReplacementService.ReplacePattern(user.Address);
        var completedAddress = _addressService.ProcessAddress(address);

        user.Address = completedAddress;
        user.DateOfBirth = editUser.DateOfBirth;
        user.FirstName = editUser.FirstName;
        user.LastName = editUser.LastName;
        user.PhoneNumber = editUser.PhoneNumber;
        user.Email = editUser.Email;
        user.FullName = editUser.FirstName + ' ' + editUser.LastName;
        user.Password = editUser.Password;

        _context.Users.Update(user);
        _context.SaveChanges();
    }

    public async Task<List<UserInfo>> GetUsers()
    {
        var users = await _context.Users
            .Include(u => u.UserClasses)
            .ToListAsync();

        List<UserInfo> result = new List<UserInfo>();

        foreach (var user in users)
        {
            result.Add(new UserInfo()
            {
                Address = user.Address,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                DateOfBirth = user.DateOfBirth,
                Id = user.Id,
                PhoneNumber = user.PhoneNumber,
                UserTypeId = user.UserTypeId
            });
        }

        return result;
    }
}