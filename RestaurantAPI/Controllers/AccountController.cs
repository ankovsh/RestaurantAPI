using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Models;
using RestaurantAPI.Services;

namespace RestaurantAPI.Controllers;

[Route("api/account")]
[ApiController]
public class AccountController: ControllerBase
{
    private readonly IAccountService _accountService;

    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }
    
    [HttpPost("register")]
    public ActionResult RegisterUser([FromBody]RegisterUserDto dto)
    {
        _accountService.RegisterUser(dto);
        return Ok();
    }

    [HttpPost("login")]
    public ActionResult Login([FromBody] LoginUserDto userDto)
    {
        var token = _accountService.GenerateJwt(userDto);
        return Ok(token);
    }
}