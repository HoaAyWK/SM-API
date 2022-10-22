namespace SM.Core.DTOs.Semester;

public class DeleteSemesterRequest
{
    public int SemesterId { get; init; }

    public DeleteSemesterRequest(int semesterId)
    {
        SemesterId = semesterId;
    }
}