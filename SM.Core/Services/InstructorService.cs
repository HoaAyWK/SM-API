using AutoMapper;
using SM.Core.DTOs.Instructor;
using SM.Core.Entities;
using SM.Core.Interfaces.Services;
using SM.Core.Interfaces.UoW;

namespace SM.Core.Services;

public class InstructorService : IInstructorService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public InstructorService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<InstructorDto>> GetAsync()
    {
        var instructors = await _unitOfWork.Instructors.GetAllAsync();
        var InstructorDtos = _mapper.Map<IEnumerable<Instructor>, IEnumerable<InstructorDto>>(instructors);

        return InstructorDtos;
    }

    public async Task<InstructorDto?> GetByIdAsync(int instructorId)
    {
        var instructor = await _unitOfWork.Instructors.GetByIdAsync(instructorId);

        if (instructor == null)
            return null;

        var instructorDto = _mapper.Map<InstructorDto>(instructor);
        
        return instructorDto;
    }

    public async Task<CreateInstructorResponse?> CreateAsync(CreateInstructorRequest request)
    {
        var instructor = new Instructor(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Phone,
            request.DateOfBirth
        );

        var result = await _unitOfWork.Instructors.AddAsync(instructor);

        if (result == null)
            return null;

        await _unitOfWork.SaveChangesAsync();
        
        var response = _mapper.Map<CreateInstructorResponse>(result);

        return response;
    }

    public async Task<UpdateInstructorResponse?> UpdateAsync(UpdateInstructorRequest request)
    {
        var existringInstructor = await _unitOfWork.Instructors.GetByIdAsync(request.Id);

        if (existringInstructor == null)
            return null;

        existringInstructor.Update(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Phone,
            request.DateOfBirth,
            request.Status
        );

        await _unitOfWork.SaveChangesAsync();

        var response = _mapper.Map<UpdateInstructorResponse>(existringInstructor);

        return response;
    }

    public async Task<DeleteInstructorResponse?> DeleteAsync(DeleteInstructorRequest request)
    {
        var instructorToDelete = await _unitOfWork.Instructors.GetByIdAsync(request.InstructorId);

        if (instructorToDelete == null)
            return null;
        
        _unitOfWork.Instructors.Delete(instructorToDelete);
        await _unitOfWork.SaveChangesAsync();

        return new DeleteInstructorResponse();
    }
}
