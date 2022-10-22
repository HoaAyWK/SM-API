namespace SM.Core.DTOs.Subject;

public class DeleteSubjectRequest
{
    public int SubjectId { get; init; }

    public DeleteSubjectRequest(int subjectId)
    {
        SubjectId = subjectId;
    }
}