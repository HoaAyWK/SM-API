using AutoMapper;
using SM.Core.DTOs;
using SM.Core.DTOs.Grade;
using SM.Core.Entities;
using SM.Core.Interfaces.Services;
using SM.Core.Interfaces.UoW;

namespace SM.Core.Services;

public class GradeService : IGradeService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GradeService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GradeDto>> GetAsync()
    {
        var grades = await _unitOfWork.Grades.GetAllAsync();
        var gradesDto = _mapper.Map<IEnumerable<Grade>, IEnumerable<GradeDto>>(grades);

        return gradesDto;
    }

    public async Task<GradeDto?> GetByIdAsync(int gradeId)
    {
        var grade = await _unitOfWork.Grades.GetByIdAsync(gradeId);

        if (grade == null)
            return null;

        await _unitOfWork.SaveChangesAsync();

        var gradeDto = _mapper.Map<GradeDto>(grade);
        
        return gradeDto;
    }

    public async Task<Result<CreateGradeResponse>> CreateAsync(CreateGradeRequest request)
    {
        var response = new Result<CreateGradeResponse>();
        var existingEnrollment = await _unitOfWork.Enrollments
            .GetEnrollmentByCourseAndStudentAsync(request.CourseId, request.StudentId);

        if (existingEnrollment == null)
        {
            response.Code = 400;
            response.Message = "It is not possible to assign marks to subject that student has not studied yet";

            return response;
        }

        var existingGrade = await _unitOfWork.Grades.GetGradeByCourseAndStudentAsync(request.CourseId, request.StudentId);

        if (existingGrade != null)
        {
            existingGrade.UpdateScore(request.Score);
            await _unitOfWork.SaveChangesAsync();

            response.Data = _mapper.Map<CreateGradeResponse>(existingGrade);
            response.Success = true;

            return response;
        }

        var grade = new Grade(request.StudentId, request.CourseId, request.Score);
        var result = await _unitOfWork.Grades.AddAsync(grade);

        response.Data = _mapper.Map<CreateGradeResponse>(grade);
        response.Success = true;

        return response;
    }

    public async Task<DeleteGradeResponse?> DeleteAsync(DeleteGradeRequest request)
    {
        var gradeToDelete = await _unitOfWork.Grades.GetByIdAsync(request.GradeId);

        if (gradeToDelete == null)
            return null;
        
        _unitOfWork.Grades.Delete(gradeToDelete);
        await _unitOfWork.SaveChangesAsync();

        return new DeleteGradeResponse();
    }
}
