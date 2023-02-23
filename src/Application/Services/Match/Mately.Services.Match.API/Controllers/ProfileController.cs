using AutoMapper;
using Mately.Services.Match.Business.Profile;
using Mately.Services.Match.Domain.Profile.Dtos;
using Mately.Services.Match.Domain.Profile.Request;
using Microsoft.AspNetCore.Mvc;

namespace Mately.Services.Match.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfileController : ControllerBase
{
    private readonly IProfileService _profileService;
    private readonly IMapper _mapper;

    public ProfileController(IProfileService profileService, IMapper mapper)
    {
        _profileService = profileService;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody]CreateProfileRequest request)
    {
        var response = await _profileService.Create(_mapper.Map<CreateProfileDto>(request));
        if (!response.IsSuccess)
            return BadRequest(response);
        return Ok(response);
    }
    
    [HttpPut]
    public async Task<IActionResult> Update([FromBody]UpdateProfileRequest request)
    {
        var response = await _profileService.Update(_mapper.Map<UpdateProfileDto>(request));
        if (!response.IsSuccess)
            return BadRequest(response);
        return Ok(response);
    }
    
    [HttpGet]
    public async Task<IActionResult> Get([FromRoute] GetProfileByDistanceRequest request)
    {
        var route = Request.Path.Value ?? "- "; 
        var response = await _profileService.GetByDistance(route , _mapper.Map<GetProfileByDistanceDto>(request));
        if (!response.IsSuccess)
            return BadRequest(response);
        return Ok(response);
    }
    
    [HttpGet("{id}")]
    public async Task<IActionResult> Get([FromRoute] string id)
    {
        var response = await _profileService.GetById(id);
        if (!response.IsSuccess)
            return BadRequest(response);
        return Ok(response);
    }
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] string id)
    {
        var response = await _profileService.Delete(id);
        if (!response.IsSuccess)
            return BadRequest(response);
        return Ok(response);
    }
}