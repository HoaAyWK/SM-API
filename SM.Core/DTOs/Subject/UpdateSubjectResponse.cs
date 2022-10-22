using System.ComponentModel.DataAnnotations;

namespace SM.Core.DTOs.Subject;

public class UpdateSubjectResponse
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int NumOfCredits { get; set; }
}