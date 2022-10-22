using SM.Core.DTOs.Grade;

namespace SM.Core.Interfaces.Services;

public interface IGradeService
{
    Task<IEnumerable<GradeDto>> GetAsync();
    Task<GradeDto?> GetByIdAsync(int entrollmentId);
    Task<CreateGradeResponse?> CreateAsync(CreateGradeRequest request);
    Task<DeleteGradeResponse?> DeleteAsync(DeleteGradeRequest request);
}