using SM.Core.DTOs.Course;
using SM.Core.DTOs.Student;

namespace SM.Core.DTOs.Grade;

public class CreateGradeRequest
{
    public int Id { get; set; }

    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public double Score { get; set; }
}
