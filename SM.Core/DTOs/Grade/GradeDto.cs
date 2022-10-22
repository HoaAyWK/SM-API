using SM.Core.DTOs.Course;
using SM.Core.DTOs.Student;

namespace SM.Core.DTOs.Grade;

public class GradeDto
{
    public int Id { get; set; }

    public StudentDto Student { get; set; } = default!;

    public CourseDto Course { get; set; } = default!;

    public double Grade { get; set; }
}