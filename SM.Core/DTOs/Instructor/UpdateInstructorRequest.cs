using System.ComponentModel.DataAnnotations;

namespace SM.Core.DTOs.Instructor;

public class UpdateInstructorRequest
{
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; } = default!;

    [Required]
    public string LastName { get; set; } = default!;

    [Required]
    public string Email { get; set; } = default!;

    [Required]
    public string Phone { get; set; } = default!;

    public DateTime DateOfBirth { get; set; }

    [Required]
    public string Status { get; set; } = string.Empty;
}
