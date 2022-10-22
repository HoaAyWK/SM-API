using SM.Core.DTOs.Course;

namespace SM.Core.Interfaces.Services;

public interface ICourseService
{
    Task<IEnumerable<CourseDto>> GetAsync();
    Task<CourseDto?> GetByIdAsync(int courseId);
    Task<CreateCourseResponse?> CreateAsync(CreateCourseRequest request);
    Task<UpdateCourseResponse?> UpdateAsync(UpdateCourseRequest request);
    Task<DeleteCourseResponse?> DeleteAsync(DeleteCourseRequest request);
}