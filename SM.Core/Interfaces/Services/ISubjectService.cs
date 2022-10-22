using SM.Core.DTOs.Subject;

namespace SM.Core.Interfaces.Services;

public interface ISubjectService
{
    Task<IEnumerable<SubjectDto>> GetAsync();
    Task<SubjectDto?> GetByIdAsync(int subjectId);
    Task<CreateSubjectResponse?> CreateAsync(CreateSubjectRequest request);
    Task<UpdateSubjectResponse?> UpdateAsync(UpdateSubjectRequest request);
    Task<DeleteSubjectResponse?> DeleteAsync(DeleteSubjectRequest request);
}