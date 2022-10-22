namespace SM.Core.DTOs.Enrollment;

public class CreateEnrollmentRequest
{
    public int Id { get; set; }
    
    public int StudentId { get; set; }

    public int CourseId { get; set; }
}
