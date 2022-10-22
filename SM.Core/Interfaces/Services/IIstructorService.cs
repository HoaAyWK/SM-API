using SM.Core.DTOs.Instructor;

namespace SM.Core.Interfaces.Services;

public interface IInstructorService
{
    Task<IEnumerable<InstructorDto>> GetAsync();
    Task<InstructorDto?> GetByIdAsync(int InstructorId);
    Task<CreateInstructorResponse?> CreateAsync(CreateInstructorRequest request);
    Task<UpdateInstructorResponse?> UpdateAsync(UpdateInstructorRequest request);
    Task<DeleteInstructorResponse?> DeleteAsync(DeleteInstructorRequest request);
}