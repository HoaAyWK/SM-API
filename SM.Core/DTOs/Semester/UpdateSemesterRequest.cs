using System.ComponentModel.DataAnnotations;

namespace SM.Core.DTOs.Semester;

public class UpdateSemesterRequest
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;
}