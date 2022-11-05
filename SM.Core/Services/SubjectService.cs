using AutoMapper;
using SM.Core.DTOs.Subject;
using SM.Core.Entities;
using SM.Core.Interfaces.Services;
using SM.Core.Interfaces.UoW;

namespace SM.Core.Services;

public class SubjectService : ISubjectService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SubjectService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<SubjectDto>> GetAsync()
    {
        var subjects = await _unitOfWork.Subjects.GetAllAsync();
        var subjectDtos = _mapper.Map<IEnumerable<Subject>, IEnumerable<SubjectDto>>(subjects);

        return subjectDtos;
    }

    public async Task<SubjectDto?> GetByIdAsync(int subjectId)
    {
        var subject = await _unitOfWork.Subjects.GetByIdAsync(subjectId);

        if (subject == null)
            return null;

        var subjectDto = _mapper.Map<SubjectDto>(subject);

        return subjectDto;
    }

    public async Task<CreateSubjectResponse?> CreateAsync(CreateSubjectRequest request)
    {
        var existingSubject = await _unitOfWork.Subjects.GetSubjectByNameAsync(request.Name);

        if (existingSubject != null) {
            return null;
        }

        var subject = new Subject(request.Name, request.NumOfCredits);
        var result = await _unitOfWork.Subjects.AddAsync(subject);

        await _unitOfWork.SaveChangesAsync();
        
        var response = _mapper.Map<CreateSubjectResponse>(result);

        return response;
    }

    public async Task<UpdateSubjectResponse?> UpdateAsync(UpdateSubjectRequest request)
    {
        var existingSubject = await _unitOfWork.Subjects.GetByIdAsync(request.Id);

        if (existingSubject == null)
        {
            return null;
        }

        existingSubject.Update(request.Name, request.NumOfCredits);
        await _unitOfWork.SaveChangesAsync();

        var response = _mapper.Map<UpdateSubjectResponse>(existingSubject);

        return response;
    }
    public async Task<DeleteSubjectResponse?> DeleteAsync(DeleteSubjectRequest request)
    {
        var response = new DeleteSubjectResponse();
        var subjectToDelete = await _unitOfWork.Subjects.GetByIdAsync(request.SubjectId);

        if (subjectToDelete == null)
        {
            return null;
        }

        _unitOfWork.Subjects.Delete(subjectToDelete);
        await _unitOfWork.SaveChangesAsync();

        return response;
    }

}