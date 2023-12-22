using LogixTask.Domain.Models;

namespace LogixTask.Services.Interfaces
{
    public interface IAdminOperations
    {
        Task<List<UserInfo>> GetUsers();

        void AddUser(AddUser user);

        void DeleteUser(int id);

        void EditUser(EditUser editUser, int userId);
    }
}
