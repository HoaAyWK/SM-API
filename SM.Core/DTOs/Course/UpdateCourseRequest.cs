namespace SM.Core.DTOs.Course;

public class UpdateCourseRequest
{
    public int Id { get; set; }

    public int InstructorId { get; set; }

    public int SubjectId { get; set; }

    public int SemesterId { get; set; }
}
