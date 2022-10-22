using System.ComponentModel.DataAnnotations;

namespace SM.Core.DTOs.Semester;

public class UpdateSemesterResponse
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;
}