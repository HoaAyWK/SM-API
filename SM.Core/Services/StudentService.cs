using AutoMapper;
using SM.Core.DTOs.Student;
using SM.Core.Entities;
using SM.Core.Interfaces.Services;
using SM.Core.Interfaces.UoW;

namespace SM.Core.Services;

public class StudentService : IStudentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public StudentService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<StudentDto>> GetAsync()
    {
        var students = await _unitOfWork.Students.GetAllAsync();
        var studentDtos = _mapper.Map<IEnumerable<Student>, IEnumerable<StudentDto>>(students);

        return studentDtos;
    }

    public async Task<StudentDto?> GetByIdAsync(int studentId)
    {
        var student = await _unitOfWork.Students.GetByIdAsync(studentId);

        if (student == null)
            return null;

        var studentDto = _mapper.Map<StudentDto>(student);

        return studentDto;
    }

    public async Task<CreateStudentResponse?> CreateAsync(CreateStudentRequest request)
    {
        var student = new Student(
            request.FirstName,
            request.LastName,
            request.Email,
            request.DateOfBirth,
            request.Gender
        );

        var result = await _unitOfWork.Students.AddAsync(student);

        if (result == null)
        {
            return null;
        }

        await _unitOfWork.SaveChangesAsync();
        
        var response = _mapper.Map<CreateStudentResponse>(result);

        return response;
    }

    public async Task<UpdateStudentResponse?> UpdateAsync(UpdateStudentRequest request)
    {
        var existingStudent = await _unitOfWork.Students.GetByIdAsync(request.Id);

        if (existingStudent == null)
        {
            return null;
        }

        existingStudent.Update(
            request.FirstName,
            request.LastName,
            request.Email,
            request.DateOfBirth,
            request.Gender
        );

        await _unitOfWork.SaveChangesAsync();

        var response = _mapper.Map<UpdateStudentResponse>(existingStudent);

        return response;
    }
    public async Task<DeleteStudentResponse?> DeleteAsync(DeleteStudentRequest request)
    {
        var response = new DeleteStudentResponse();
        var studentToDelete = await _unitOfWork.Students.GetByIdAsync(request.StudentId);

        if (studentToDelete == null)
        {
            return null;
        }

        _unitOfWork.Students.Delete(studentToDelete);
        await _unitOfWork.SaveChangesAsync();

        return response;
    }

}