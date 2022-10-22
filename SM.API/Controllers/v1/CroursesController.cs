using Microsoft.AspNetCore.Mvc;
using SM.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using SM.Core.DTOs.Course;

namespace SM.API.Controllers.v1;

public class CoursesController : BaseController
{
    private readonly ICourseService _courseService;

    public CoursesController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _courseService.GetAsync();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _courseService.GetByIdAsync(id);

        if (result == null) {
            return BadRequest("Course not found");
        }

        return Ok(result);
    }

    [HttpPost]
    [Route("create")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> Create([FromBody] CreateCourseRequest request)
    {
        var result = await _courseService.CreateAsync(request);

        return Ok(result);
    }

    [HttpPut]
    [Route("update")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> Update([FromBody] UpdateCourseRequest request)
    {
        var result = await _courseService.UpdateAsync(request);

        if (result == null)
            return BadRequest("Course not found");
        
        return Ok(result);
    }

    [HttpDelete]
    [Route("delete")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> Delete(DeleteCourseRequest request)
    {
        var result = await _courseService.DeleteAsync(request);

        if (result == null)
            return BadRequest("Course not found");

        return Ok(result);
    }
}