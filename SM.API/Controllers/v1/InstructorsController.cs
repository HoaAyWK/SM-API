using Microsoft.AspNetCore.Mvc;
using SM.Core.Interfaces.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using SM.Core.DTOs.Instructor;
using Microsoft.AspNetCore.Authorization;

namespace SM.API.Controllers.v1;

public class InstructorsController : BaseController
{
    private readonly IInstructorService _instructorService;

    public InstructorsController(IInstructorService instructorService)
    {
        _instructorService = instructorService;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var result = await _instructorService.GetAsync();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(int id)
    {
        var result = await _instructorService.GetByIdAsync(id);

        if (result == null) {
            return BadRequest("Instructor not found");
        }

        return Ok(result);
    }

    [HttpPost]
    [Route("create")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> Create([FromBody] CreateInstructorRequest request)
    {
        var result = await _instructorService.CreateAsync(request);

        return Ok(result);
    }

    [HttpPut]
    [Route("update")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> Update([FromBody] UpdateInstructorRequest request)
    {
        var result = await _instructorService.UpdateAsync(request);

        if (result == null)
            return BadRequest("Instructor not found");
        
        return Ok(result);
    }

    [HttpDelete]
    [Route("delete")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<IActionResult> Delete(DeleteInstructorRequest request)
    {
        var result = await _instructorService.DeleteAsync(request);

        if (result == null)
            return BadRequest("Instructor not found");

        return Ok(result);
    }
}