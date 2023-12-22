using LogixTask.Domain.Models;

namespace LogixTask.Services.Interfaces
{
    public interface IClassService
    {
        Task<List<ClassInfo>> GetClasses();
    }
}
