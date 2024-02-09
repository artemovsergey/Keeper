using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Keeper.Domen.Data;
using Keeper.Domen.Models;
using Keeper.Domen.Services;
using Keeper.Domen.Interfaces;
using FluentValidation;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Bogus;

namespace Keeper.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    
    private readonly IUserService _userService;
    private readonly IValidator<User> _userValidator;
    public UsersController(IUserService userService, IValidator<User> userValidator)
    {
        _userService = userService;
        _userValidator = userValidator;
    }

    // GET: api/Users
    [HttpGet]
    public async Task<ActionResult<ApiResult<User>>> GetUsers(
                                                              string? sortColumn = null,
                                                              string? sortOrder = null,
                                                              int pageIndex = 0,
                                                              int pageSize = 10,
                                                              string? filterColumn = null,
                                                              string? filterQuery = null)
    {
        var users = await _userService.Users(pageIndex,
                                             pageSize,
                                             sortColumn,
                                             sortOrder,
                                             filterColumn,
                                             filterQuery);
        
        return new ApiResult<User>( (List<User>)users, 
                                    await _userService.Count(),
                                    pageIndex,
                                    pageSize,
                                    sortColumn,
                                    sortOrder,
                                    filterColumn,
                                    filterQuery);

    }

    // POST: api/Users
    [HttpPost]
    public async Task<ActionResult> SignUser(User user)
    {
        var validationResult = _userValidator.Validate(user);

        if (!validationResult.IsValid)
        {
            foreach (var failure in validationResult.Errors)
            {
                ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
            }

            return BadRequest(ModelState);
        }

        await _userService.Sign(user);
        return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
    }

    // GET: api/Users/5
    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUserById(int id)
    {
        var user = await _userService.GetUserById(id);

        if (user == null)
        {
            return NotFound();
        }

        return user;
    }

    // PUT: api/Users/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutUser(int id,User user)
    {
        if (id != user.Id)
        {
            return NotFound();
        }

        try
        {
          await _userService.EditUser(user);
        }
        catch
        {
            return NotFound();
        }

        return NoContent();
    }

    // DELETE: api/Users/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        try
        {
            await _userService.RemoveUser(id);
        }
        catch
        {
            return NotFound();
        }

        return NoContent();
    }

    [HttpGet("/generate")]
    public async Task<IActionResult> SeedUsers()
    {

        var faker = new Faker<User>()
        //.RuleFor(u => u.Id, f => f.UniqueIndex)
        .RuleFor(u => u.Email, f => f.Internet.Email())
        .RuleFor(u => u.Login, f => f.Person.UserName)
        .RuleFor(u => u.Password, f => f.Internet.Password());

        List<User> users = faker.Generate(100);

        using (var context = new KeeperContext())
        {
            context.Users.AddRangeAsync(users);
            await context.SaveChangesAsync();
        }

        return Ok();
    }

    [HttpPost]
    [Route("isUniqEmail")]
    public async Task<bool> isUniqEmail(User user)
    {
        return await _userService.IsUniqEmail(user);
    }

}
