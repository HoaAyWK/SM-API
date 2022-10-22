using SM.Core.Interfaces.Services;
using SM.Core.Interfaces.UoW;
using SM.Core.Services;
using SM.Infrastructure.Data;
using SM.Infrastructure.Indentity;

namespace SM.API.Configurations;

public static class ConfigureCoreServices
{
    public static IServiceCollection AddCoreServices(
        this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<ISubjectService, SubjectService>();
        services.AddScoped<IStudentService, StudentService>();
        services.AddScoped<IInstructorService, InstructorService>();
        services.AddScoped<ITokenClaimsService, IdentityTokenClaimService>();
        services.AddScoped<ISemesterService, SemesterService>();
        services.AddScoped<ICourseService, CourseService>();
        services.AddScoped<IEnrollmentService, EnrollmentService>();
        services.AddScoped<IGradeService, GradeService>();

        return services;
    }
}