using System.ComponentModel.DataAnnotations;

namespace SM.Core.DTOs.Student;

public class UpdateStudentRequest
{
    public int Id { get; set; }
    
    [Required]
    public string FirstName { get; set; } = default!;

    [Required]
    public string LastName { get; set; } = default!;

    [Required]
    public string Email { get; set; } = default!;

    [Required]
    public string Gender { get; set; } = default!;

    public DateTime DateOfBirth { get; set; }
}
