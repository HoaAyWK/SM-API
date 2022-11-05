using System.ComponentModel.DataAnnotations;

namespace SM.Core.DTOs.Instructor;

public class CreateInstructorRequest
{
    [Required]
    public string FirstName { get; set; } = default!;

    [Required]
    public string LastName { get; set; } = default!;

    [Required]
    public string Email { get; set; } = default!;

    [Required]
    public string Phone { get; set; } = default!;

    public DateTime DateOfBirth { get; set; }
}
