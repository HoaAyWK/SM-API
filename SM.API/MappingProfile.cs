using AutoMapper;
using SM.Core.DTOs.Course;
using SM.Core.DTOs.Enrollment;
using SM.Core.DTOs.Grade;
using SM.Core.DTOs.Instructor;
using SM.Core.DTOs.Semester;
using SM.Core.DTOs.Student;
using SM.Core.DTOs.Subject;
using SM.Core.Entities;

namespace SM.API;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Subject, SubjectDto>();
        CreateMap<Subject, CreateSubjectResponse>();
        CreateMap<Subject, UpdateSubjectResponse>();

        CreateMap<Student, StudentDto>();
        CreateMap<Student, CreateStudentResponse>();
        CreateMap<Student, UpdateStudentResponse>();

        CreateMap<Instructor, InstructorDto>();
        CreateMap<Instructor, CreateInstructorResponse>();
        CreateMap<Instructor, UpdateInstructorResponse>();

        CreateMap<Semester, SemesterDto>();
        CreateMap<Semester, CreateSemesterResponse>();
        CreateMap<Semester, UpdateSemesterResponse>();

        CreateMap<Course, CourseDto>();
        CreateMap<Course, CreateCourseResponse>();
        CreateMap<Course, UpdateCourseResponse>();

        CreateMap<Enrollment, EnrollmentDto>();
        CreateMap<Enrollment, CreateEnrollmentResponse>();

        CreateMap<Grade, GradeDto>();
        CreateMap<Grade, CreateGradeResponse>();
    }
}