namespace SM.Core.DTOs.Grade;

public class DeleteGradeRequest
{
    public int GradeId { get; init; }

    public DeleteGradeRequest(int gradeId)
    {
        GradeId = gradeId;
    }
}