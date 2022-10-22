using Microsoft.AspNetCore.Mvc;
using SM.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using SM.Core.DTOs.Student;

namespace SM.API.Controllers.v1;

public class StudentsController : BaseController
{
    private readonly IStudentService _studentService;

    public StudentsController(IStudentService studentService)
    {
        _studentService = studentService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _studentService.GetAsync();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _studentService.GetByIdAsync(id);

        if (result == null) {
            return BadRequest("Student not found");
        }

        return Ok(result);
    }

    [HttpPost]
    [Route("create")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> Create([FromBody] CreateStudentRequest request)
    {
        var result = await _studentService.CreateAsync(request);

        return Ok(result);
    }

    [HttpPut]
    [Route("update")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> Update([FromBody] UpdateStudentRequest request)
    {
        var result = await _studentService.UpdateAsync(request);

        if (result == null)
            return BadRequest("Student not found");
        
        return Ok(result);
    }

    [HttpDelete]
    [Route("delete")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> Delete(DeleteStudentRequest request)
    {
        var result = await _studentService.DeleteAsync(request);

        if (result == null)
            return BadRequest("Student not found");

        return Ok(result);
    }
}