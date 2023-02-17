using AutoMapper;
using Mately.Identity.API.Domain.Auth.Dtos;
using Mately.Identity.API.Domain.Auth.Request;
using Mately.Identity.API.Repository.User;
using Mately.Identity.API.Services.AuthService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mately.Identity.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public AuthController(IAuthService authService, IMapper mapper, IUserRepository userRepository)
    {
        _authService = authService;
        _mapper = mapper;
        _userRepository = userRepository;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var response = await _authService.Register(_mapper.Map<RegisterDto>(request));
        if (!response.IsSuccess)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
    [HttpPost("register-admin")]
    public async Task<IActionResult> AdminRegister([FromBody] AdminRegisterRequest request)
    {
        var response = await _authService.AdminRegister(_mapper.Map<AdminRegisterDto>(request));
        if (!response.IsSuccess)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody]LoginRequest request)
    {
        var response = await _authService.Login(_mapper.Map<LoginDto>(request));
        if (!response.IsSuccess)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }
    
    [HttpPost("refresh-token")]
    public async Task<IActionResult> RefreshToken([FromBody]RefreshTokenRequest request)
    {
        var response = await _authService.RefreshToken(_mapper.Map<RefreshTokenDto>(request));
        if (!response.IsSuccess)
        {
            return BadRequest(response);
        }

        return Ok(response);
    }

    [Authorize]
    [HttpGet("Get")]
    public async Task<IActionResult> GetTest()
    {
        var user = _userRepository.Get().ToList();
        return Ok(user);
    }
}