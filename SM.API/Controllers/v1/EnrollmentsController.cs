using Microsoft.AspNetCore.Mvc;
using SM.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using SM.Core.DTOs.Enrollment;

namespace SM.API.Controllers.v1;

public class EnrollmentsController : BaseController
{
    private readonly IEnrollmentService _enrollmentService;

    public EnrollmentsController(IEnrollmentService enrollmentService)
    {
        _enrollmentService = enrollmentService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _enrollmentService.GetAsync();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _enrollmentService.GetByIdAsync(id);

        if (result == null) {
            return BadRequest("Enrollment not found");
        }

        return Ok(result);
    }

    [HttpPost]
    [Route("create")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> Create([FromBody] CreateEnrollmentRequest request)
    {
        var result = await _enrollmentService.CreateAsync(request);

        return Ok(result);
    }

    [HttpDelete]
    [Route("delete")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> Delete(DeleteEnrollmentRequest request)
    {
        var result = await _enrollmentService.DeleteAsync(request);

        if (result == null)
            return BadRequest("Enrollment not found");

        return Ok(result);
    }
}