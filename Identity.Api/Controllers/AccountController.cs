﻿using Identity.Application.Common.Identity.Services;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Api.Controllers;

[ApiController]
[Route("api/controller")]
public class AccountController : ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }

    [HttpPut]
    public async ValueTask<IActionResult> VerificateAsync([FromRoute] string token)
    {
        var data = await _accountService.VerificateAsync(token);

        return Ok(data);
    }
}
