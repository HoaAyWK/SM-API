using AutoMapper;
using SM.Core.DTOs.Semester;
using SM.Core.Entities;
using SM.Core.Interfaces.Services;
using SM.Core.Interfaces.UoW;

namespace SM.Core.Services;

public class SemesterService : ISemesterService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SemesterService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SemesterDto>> GetAsync()
    {
        var semesters = await _unitOfWork.Semesters.GetAllAsync();
        var semesterDtos = _mapper.Map<IEnumerable<Semester>, IEnumerable<SemesterDto>>(semesters);

        return semesterDtos;
    }

    public async Task<SemesterDto?> GetByIdAsync(int semesterId)
    {
        var semester = await _unitOfWork.Semesters.GetByIdAsync(semesterId);

        if (semester == null)
            return null;

        var semesterDto = _mapper.Map<SemesterDto>(semester);
        
        return semesterDto;
    }

    public async Task<CreateSemesterResponse?> CreateAsync(CreateSemesterRequest request)
    {
        var semester = new Semester(request.Name);
        var result = await _unitOfWork.Semesters.AddAsync(semester);

        if (result == null)
            return null;

        var response = _mapper.Map<CreateSemesterResponse>(semester);

        return response;
    }

    public async Task<UpdateSemesterResponse?> UpdateAsync(UpdateSemesterRequest request)
    {
        var existingSemester = await _unitOfWork.Semesters.GetByIdAsync(request.Id);

        if (existingSemester == null)
            return null;

        existingSemester.Update(request.Name);
        await _unitOfWork.SaveChangesAsync();

        var response = _mapper.Map<UpdateSemesterResponse>(existingSemester);

        return response;
    }

    public async Task<DeleteSemesterResponse?> DeleteAsync(DeleteSemesterRequest request)
    {
        var semesterToDelete = await _unitOfWork.Semesters.GetByIdAsync(request.SemesterId);

        if (semesterToDelete == null)
            return null;
        
        _unitOfWork.Semesters.Delete(semesterToDelete);
        await _unitOfWork.SaveChangesAsync();

        return new DeleteSemesterResponse();
    }
}
