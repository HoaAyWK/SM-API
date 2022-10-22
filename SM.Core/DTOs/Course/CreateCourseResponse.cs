using SM.Core.DTOs.Instructor;
using SM.Core.DTOs.Semester;
using SM.Core.DTOs.Subject;

namespace SM.Core.DTOs.Course;

public class CreateCourseResponse
{
    public int Id { get; set; }

    public InstructorDto Instructor { get; set; } = default!;

    public SubjectDto Subject { get; set; } = default!;

    public SemesterDto Semester { get; set; } = default!;
}