using Mately.Common.Domain.Dtos.Transaction;
using Mately.Indentity.API.Domain.Auth.Dtos;
using Mately.Indentity.API.Domain.User.Dtos;
using Mately.Indentity.API.Services.Account;
using Mately.Indentity.API.Services.Auth;
using Microsoft.AspNetCore.Mvc;

namespace Mately.Indentity.API.Controllers;

public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;


    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("register")]
    public async Task<ApiTransactionResult<RegisterResultDto>> Register([FromBody]RegisterDto dto)
    {
        var response = await _authService.Register(dto);
        return response;
    }
}