using Microsoft.EntityFrameworkCore;
using SM.Core.Entities;
using SM.Core.Interfaces.Repositories;
using SM.Infrastructure.Data;

namespace SM.Infrastructure.Repositories;

public class GradeRepository : GenericRepository<Grade>, IGradeRepository
{
    public GradeRepository(StudentManagementContext context) : base(context)
    {
    }

    public override async Task<IEnumerable<Grade>> GetAllAsync()
    {
        return await dbSet.Include(g => g.Course)
                .ThenInclude(c => c!.Subject)
            .Include(g => g.Student)
            .AsNoTracking()
            .ToListAsync();
    }

    public override async Task<Grade?> GetByIdAsync(int id)
    {
        return await dbSet.Where(g => g.Id == id)
            .Include(g => g.Course)
                .ThenInclude(c => c!.Subject)
            .Include(g => g.Student)
            .FirstOrDefaultAsync();
    }
}