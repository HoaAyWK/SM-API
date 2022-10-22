using Microsoft.AspNetCore.Mvc;
using SM.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SM.Core.DTOs.Subject;
using Microsoft.AspNetCore.Authorization;

namespace SM.API.Controllers.v1;

public class SubjectsController : BaseController
{
    private readonly ISubjectService _subjectService;

    public SubjectsController(ISubjectService subjectService)
    {
        _subjectService = subjectService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _subjectService.GetAsync();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _subjectService.GetByIdAsync(id);

        if (result == null) {
            return BadRequest("Subject not found");
        }

        return Ok(result);
    }

    [HttpPost]
    [Route("create")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> Create([FromBody] CreateSubjectRequest request)
    {
        var result = await _subjectService.CreateAsync(request);

        return Ok(result);
    }

    [HttpPut]
    [Route("update")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> Update([FromBody] UpdateSubjectRequest request)
    {
        var result = await _subjectService.UpdateAsync(request);

        if (result == null)
            return BadRequest("Subject not found");
        
        return Ok(result);
    }

    [HttpDelete]
    [Route("delete")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> Delete(DeleteSubjectRequest request)
    {
        var result = await _subjectService.DeleteAsync(request);

        if (result == null)
            return BadRequest("Subject not found");

        return Ok(result);
    }
}