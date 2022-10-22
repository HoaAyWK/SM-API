using System.ComponentModel.DataAnnotations;

namespace SM.Core.DTOs.Semester;

public class CreateSemesterRequest
{
    [Required]
    public string Name { get; set; } = string.Empty;
}