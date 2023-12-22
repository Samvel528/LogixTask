using LogixTask.Domain.Models;
using LogixTask.Entities.Context;
using LogixTask.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace LogixTask.Services.Implementations
{
    internal class ClassService : IClassService
    {
        private readonly LogixTaskDbContext _context;

        public ClassService(LogixTaskDbContext context)
        {
            _context = context;
        }

        public async Task<List<ClassInfo>> GetClasses()
        {
            var classes = await _context.Classes.ToListAsync();
            List<ClassInfo> result = new List<ClassInfo>();

            foreach (var classItem in classes)
            {
                result.Add(new ClassInfo()
                {
                    Id = classItem.Id,
                    Name = classItem.Name
                });
            }

            return result;
        }
    }
}
