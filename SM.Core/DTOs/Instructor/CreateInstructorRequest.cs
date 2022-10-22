using System.ComponentModel.DataAnnotations;

namespace SM.Core.DTOs.Instructor;

public class CreateInstructorRequest
{
    [Required]
    public string FirstName { get; private set; } = default!;

    [Required]
    public string LastName { get; private set; } = default!;

    [Required]
    public string Email { get; private set; } = default!;

    [Required]
    public string Phone { get; private set; } = default!;

    public DateTime DateOfBirth { get; private set; }
}
