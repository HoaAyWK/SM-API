using Microsoft.AspNetCore.Mvc;
using SM.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using SM.Core.DTOs.Grade;

namespace SM.API.Controllers.v1;

public class GradesController : BaseController
{
    private readonly IGradeService _gradeService;

    public GradesController(IGradeService gradeService)
    {
        _gradeService = gradeService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _gradeService.GetAsync();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _gradeService.GetByIdAsync(id);

        if (result == null) {
            return BadRequest("Grade not found");
        }

        return Ok(result);
    }

    [HttpPost]
    [Route("create")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> Create([FromBody] CreateGradeRequest request)
    {
        var result = await _gradeService.CreateAsync(request);

        if (!result.Success) {
            return BadRequest(result.Message);
        }

        return Ok(result.Data);
    }

    [HttpDelete]
    [Route("delete")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> Delete(DeleteGradeRequest request)
    {
        var result = await _gradeService.DeleteAsync(request);

        if (result == null)
            return BadRequest("Grade not found");

        return Ok(result);
    }
}