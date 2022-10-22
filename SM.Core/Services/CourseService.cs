using AutoMapper;
using SM.Core.DTOs.Course;
using SM.Core.Entities;
using SM.Core.Interfaces.Services;
using SM.Core.Interfaces.UoW;

namespace SM.Core.Services;

public class CourseService : ICourseService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CourseService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<CourseDto>> GetAsync()
    {
        var courses = await _unitOfWork.Courses.GetAllAsync();
        var courseDtos = _mapper.Map<IEnumerable<Course>, IEnumerable<CourseDto>>(courses);

        return courseDtos;
    }

    public async Task<CourseDto?> GetByIdAsync(int courseId)
    {
        var course = await _unitOfWork.Courses.GetByIdAsync(courseId);

        if (course == null)
            return null;

        var courseDto = _mapper.Map<CourseDto>(course);

        return courseDto;
    }

    public async Task<CreateCourseResponse?> CreateAsync(CreateCourseRequest request)
    {
        var course = new Course(
            request.SubjectId,
            request.InstructorId,
            request.SemesterId
        );

        var result = await _unitOfWork.Courses.AddAsync(course);

        if (result == null)
        {
            return null;
        }

        await _unitOfWork.SaveChangesAsync();
        
        var response = _mapper.Map<CreateCourseResponse>(course);

        return response;
    }

    public async Task<UpdateCourseResponse?> UpdateAsync(UpdateCourseRequest request)
    {
        var existingCourse = await _unitOfWork.Courses.GetByIdAsync(request.Id);

        if (existingCourse == null)
        {
            return null;
        }

        existingCourse.UpdateSubject(request.SubjectId);
        existingCourse.UpdateInstructor(request.InstructorId);
        existingCourse.UpdateSemsester(request.SemesterId);

        await _unitOfWork.SaveChangesAsync();

        var response = _mapper.Map<UpdateCourseResponse>(existingCourse);

        return response;
    }
    public async Task<DeleteCourseResponse?> DeleteAsync(DeleteCourseRequest request)
    {
        var response = new DeleteCourseResponse();
        var courseToDelete = await _unitOfWork.Courses.GetByIdAsync(request.CourseId);

        if (courseToDelete == null)
        {
            return null;
        }

        _unitOfWork.Courses.Delete(courseToDelete);
        await _unitOfWork.SaveChangesAsync();

        return response;
    }

}