using SM.Core.Entities;
using SM.Core.Interfaces.Repositories;
using SM.Infrastructure.Data;

namespace SM.Infrastructure.Repositories;

public class SemesterRepository : GenericRepository<Semester>, ISemesterRepository
{
    public SemesterRepository(StudentManagementContext context) : base(context)
    {
    }
}