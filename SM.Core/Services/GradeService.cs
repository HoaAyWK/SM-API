using AutoMapper;
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

        var gradeDto = _mapper.Map<GradeDto>(grade);
        
        return gradeDto;
    }

    public async Task<CreateGradeResponse?> CreateAsync(CreateGradeRequest request)
    {
        var grade = new Grade(request.StudentId, request.CourseId, request.Score);
        var result = await _unitOfWork.Grades.AddAsync(grade);

        if (result == null)
            return null;

        var response = _mapper.Map<CreateGradeResponse>(grade);

        return response;
    }

    public async Task<DeleteGradeResponse?> DeleteAsync(DeleteGradeRequest request)
    {
        var semesterToDelete = await _unitOfWork.Grades.GetByIdAsync(request.GradeId);

        if (semesterToDelete == null)
            return null;
        
        _unitOfWork.Grades.Delete(semesterToDelete);
        await _unitOfWork.SaveChangesAsync();

        return new DeleteGradeResponse();
    }
}
