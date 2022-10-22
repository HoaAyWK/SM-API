namespace SM.Core.DTOs.Enrollment;

public class DeleteEnrollmentRequest
{
    public int EnrollmentId { get; init; }

    public DeleteEnrollmentRequest(int enrollmentId)
    {
        EnrollmentId = enrollmentId;
    }
}