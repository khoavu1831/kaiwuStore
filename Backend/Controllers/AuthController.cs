using Backend.DTOs;
using Backend.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
  private readonly IAuthService _authService;
  public AuthController(IAuthService authService)
  {
    _authService = authService;
  }

  [HttpPost("signup")]
  public async Task<IActionResult> SignUp([FromBody] SignUpRequest req)
  {
    try
    {
      if (!ModelState.IsValid)
        return BadRequest(new
        {
          success = false,
          message = "Dữ liệu không hợp lệ",
          error = ModelState
        });

      var res = await _authService.SignUpAsync(req);
      return Ok(new
      {
        success = true,
        message = "Đăng ký thành công",
        data = res
      });
    }
    catch (Exception ex)
    {
      return BadRequest(new
      {
        success = false,
        message = "Lỗi hệ thống: " + ex.Message
      });
    }
  }

  [HttpPost("signin")]
  public async Task<IActionResult> SignIn([FromBody] SignInRequest req)
  {
    try
    {
      if (!ModelState.IsValid)
        return BadRequest(new
        {
          success = false,
          message = "Dữ liệu không hợp lệ",
          errors = ModelState
        });

      var res = await _authService.SignInAsync(req);
      return Ok(new
      {
        success = true,
        message = "Đăng nhập thành công",
        data = res
      });
    }
    catch (Exception ex)
    {
      return Unauthorized(new
      {
        success = false,
        message = "Lỗi hệ thống: " + ex.Message
      });
    }
  }
  
  [HttpPost("logout")]
  public async Task<IActionResult> Logout([FromBody] LogoutRequest req)
  {
    try
    {
      await _authService.LogoutAsync(req.RefreshToken);
      return Ok(new
      {
        success = true,
        message = "Đăng xuất thành công"
      });
    }
    catch (Exception ex)
    {
      return BadRequest(new
      {
        success = false,
        message = "Lỗi hệ thống: " + ex.Message
      });
    }
  }
}