using System.ComponentModel.DataAnnotations;

namespace SM.Core.DTOs.Subject;

public class UpdateSubjectRequest
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = null!;

    public int NumOfCredits { get; set; }
}