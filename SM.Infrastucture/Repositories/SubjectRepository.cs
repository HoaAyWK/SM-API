using SM.Core.Entities;
using SM.Core.Interfaces.Repositories;
using SM.Infrastructure.Data;

namespace SM.Infrastructure.Repositories;

public class SubjectRepository : GenericRepository<Subject>, ISubjectRepository
{
    public SubjectRepository(StudentManagementContext context) : base(context)
    {
    }
}