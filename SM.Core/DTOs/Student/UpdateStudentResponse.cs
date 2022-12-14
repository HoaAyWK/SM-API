namespace SM.Core.DTOs.Student;

public class UpdateStudentResponse
{
    public int Id { get; set; }

    public string FirstName { get; set; } = default!;

    public string LastName { get; set; } = default!;

    public string Email { get; set; } = default!;

    public string Gender { get; set; } = default!;

    public DateTime DateOfBirth { get; set; }
}