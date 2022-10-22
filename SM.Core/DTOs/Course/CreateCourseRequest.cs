namespace SM.Core.DTOs.Course;

public class CreateCourseRequest
{
    public int Id { get; set; }

    public int InstructorId { get; set; }

    public int SubjectId { get; set; }

    public int SemesterId { get; set; }
}
