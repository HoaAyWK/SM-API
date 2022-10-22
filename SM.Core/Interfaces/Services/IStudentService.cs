using SM.Core.DTOs.Student;

namespace SM.Core.Interfaces.Services;

public interface IStudentService
{
    Task<IEnumerable<StudentDto>> GetAsync();
    Task<StudentDto?> GetByIdAsync(int studentId);
    Task<CreateStudentResponse?> CreateAsync(CreateStudentRequest request);
    Task<UpdateStudentResponse?> UpdateAsync(UpdateStudentRequest request);
    Task<DeleteStudentResponse?> DeleteAsync(DeleteStudentRequest request);
}