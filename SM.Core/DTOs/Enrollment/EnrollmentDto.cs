using SM.Core.DTOs.Course;
using SM.Core.DTOs.Student;

namespace SM.Core.DTOs.Enrollment;

public class EnrollmentDto
{
    public int Id { get; set; }
    
    public StudentDto Student { get; set; } = default!;

    public CourseDto Course { get; set; } = default!;
}