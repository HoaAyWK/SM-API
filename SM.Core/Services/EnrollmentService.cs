using AutoMapper;
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
        var enrollment = new Enrollment(request.StudentId, request.CourseId);
        var result = await _unitOfWork.Enrollments.AddAsync(enrollment);

        if (result == null)
            return null;

        var response = _mapper.Map<CreateEnrollmentResponse>(enrollment);

        return response;
    }

    public async Task<DeleteEnrollmentResponse?> DeleteAsync(DeleteEnrollmentRequest request)
    {
        var semesterToDelete = await _unitOfWork.Enrollments.GetByIdAsync(request.EnrollmentId);

        if (semesterToDelete == null)
            return null;
        
        _unitOfWork.Enrollments.Delete(semesterToDelete);
        await _unitOfWork.SaveChangesAsync();

        return new DeleteEnrollmentResponse();
    }
}
