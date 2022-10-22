using SM.Core.DTOs.Semester;

namespace SM.Core.Interfaces.Services;

public interface ISemesterService
{
    Task<IEnumerable<SemesterDto>> GetAsync();
    Task<SemesterDto?> GetByIdAsync(int semesterId);
    Task<CreateSemesterResponse?> CreateAsync(CreateSemesterRequest request);
    Task<UpdateSemesterResponse?> UpdateAsync(UpdateSemesterRequest request);
    Task<DeleteSemesterResponse?> DeleteAsync(DeleteSemesterRequest request);
}