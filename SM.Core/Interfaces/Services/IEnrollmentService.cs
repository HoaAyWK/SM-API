using SM.Core.DTOs.Enrollment;

namespace SM.Core.Interfaces.Services;

public interface IEnrollmentService
{
    Task<IEnumerable<EnrollmentDto>> GetAsync();
    Task<EnrollmentDto?> GetByIdAsync(int entrollmentId);
    Task<CreateEnrollmentResponse?> CreateAsync(CreateEnrollmentRequest request);
    Task<DeleteEnrollmentResponse?> DeleteAsync(DeleteEnrollmentRequest request);
}