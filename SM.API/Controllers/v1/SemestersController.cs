using Microsoft.AspNetCore.Mvc;
using SM.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SM.Core.DTOs.Semester;
using Microsoft.AspNetCore.Authorization;

namespace SM.API.Controllers.v1;

public class SemestersController : BaseController
{
    private readonly ISemesterService _semesterService;

    public SemestersController(ISemesterService semesterService)
    {
        _semesterService = semesterService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _semesterService.GetAsync();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _semesterService.GetByIdAsync(id);

        if (result == null) {
            return BadRequest("Semester not found");
        }

        return Ok(result);
    }

    [HttpPost]
    [Route("create")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> Create([FromBody] CreateSemesterRequest request)
    {
        var result = await _semesterService.CreateAsync(request);

        if (result == null)
        {
            return BadRequest($"Semester with name '{request.Name}' already exists");
        }

        return Ok(result);
    }

    [HttpPut]
    [Route("update")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> Update([FromBody] UpdateSemesterRequest request)
    {
        var result = await _semesterService.UpdateAsync(request);

        if (result == null)
            return BadRequest("Semester not found");
        
        return Ok(result);
    }

    [HttpDelete]
    [Route("delete")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> Delete(DeleteSemesterRequest request)
    {
        var result = await _semesterService.DeleteAsync(request);

        if (result == null)
            return BadRequest("Semester not found");

        return Ok(result);
    }
}