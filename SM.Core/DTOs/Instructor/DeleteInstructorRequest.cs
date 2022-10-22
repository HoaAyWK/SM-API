namespace SM.Core.DTOs.Instructor;

public class DeleteInstructorRequest
{
    public int InstructorId { get; init; }

    public DeleteInstructorRequest(int instructorId)
    {
        InstructorId = instructorId;
    }
}