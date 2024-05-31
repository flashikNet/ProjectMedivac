﻿using Application.Models.Requests;
using Application.Models.Responses;
using Domain.Entities;
using Domain.Extensions;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class UsersController : BaseApiController
{
    private readonly IUsersRepository _usersRepository;
    private readonly TokenService _tokenService;

    public UsersController(IUsersRepository usersRepository, TokenService tokenService)
    {
        _usersRepository = usersRepository;
        _tokenService = tokenService;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register([FromBody] User user)
    {
        if (!user.IsValid())
        {
            return BadRequest("no sign in info.");
        }

        if (await _usersRepository.UserExistsByEmailAsync(user.SignInInfo.Email))
        {
            return BadRequest("email already exists.");
        }

        if (await _usersRepository.UserExistsByUsernameAsync(user.Username))
        {
            return BadRequest("username already exists.");
        }
        
        await _usersRepository.CreateUserAsync(user);
        return Ok(user);
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] AuthRequest authRequest)
    {
        var user = await _usersRepository.GetUserByEmailAsync(authRequest.Email);

        if (user == null)
        {
            return Unauthorized("Invalid email.");
        }

        if (authRequest.Password != user.SignInInfo.Password)
        {
            return Unauthorized("Invalid password.");
        }

        var token = _tokenService.GenerateToken(user);

        var response = new AuthResponse
        {
            Token = token,
            Username = user.Username,
            Email = user.SignInInfo.Email
        };

        return Ok(response);
    }
}