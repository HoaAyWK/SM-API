using AutoMapper;
using SM.Core.DTOs;
using SM.Core.DTOs.Enrollment;
using SM.Core.Entities;
using SM.Core.Interfaces.Services;
using SM.Core.Interfaces.UoW;

namespace SM.Core.Services;

public class EnrollmentService : IEnrollmentService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public EnrollmentService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<EnrollmentDto>> GetAsync()
    {
        var enrollments = await _unitOfWork.Enrollments.GetAllAsync();
        var enrollmentsDto = _mapper.Map<IEnumerable<Enrollment>, IEnumerable<EnrollmentDto>>(enrollments);

        return enrollmentsDto;
    }

    public async Task<EnrollmentDto?> GetByIdAsync(int enrollmentId)
    {
        var enrollment = await _unitOfWork.Enrollments.GetByIdAsync(enrollmentId);

        if (enrollment == null)
            return null;

        var enrollmentDto = _mapper.Map<EnrollmentDto>(enrollment);
        
        return enrollmentDto;
    }

    public async Task<CreateEnrollmentResponse?> CreateAsync(CreateEnrollmentRequest request)
    {
        var existingEnrollment = await _unitOfWork.Enrollments
            .GetEnrollmentByCourseAndStudentAsync(request.CourseId, request.StudentId);
        
        if (existingEnrollment != null) {
            return null;
        }

        var newEnrollment = new Enrollment(request.CourseId, request.StudentId);
        var result = await _unitOfWork.Enrollments.AddAsync(newEnrollment);

        await _unitOfWork.SaveChangesAsync();

        var enrollment = await _unitOfWork.Enrollments.GetByIdAsync(result.Id);
        var response = _mapper.Map<CreateEnrollmentResponse>(enrollment);

        return response;
    }

    public async Task<Result<DeleteEnrollmentResponse>> DeleteAsync(DeleteEnrollmentRequest request)
    {
        var response = new Result<DeleteEnrollmentResponse>();
        var enrollmentToDelete = await _unitOfWork.Enrollments.GetByIdAsync(request.EnrollmentId);

        if (enrollmentToDelete == null)
        {
            response.Code = 404;
            response.Message = "Enrollment not found";
            
            return response;
        }

        var existingGrade = await _unitOfWork.Grades.GetGradeByCourseAndStudentAsync(enrollmentToDelete.CourseId, enrollmentToDelete.StudentId);

        if (existingGrade != null)
        {
            response.Code = 400;
            response.Message = $"Please delete Grade with courseId '{enrollmentToDelete.CourseId}' and studentId '{enrollmentToDelete.StudentId}' first!";

            return response;
        } 
        
        _unitOfWork.Enrollments.Delete(enrollmentToDelete);
        await _unitOfWork.SaveChangesAsync();

        response.Success = true;
        response.Data = new DeleteEnrollmentResponse();
        
        return response;
    }
}
