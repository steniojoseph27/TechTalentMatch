using Microsoft.AspNetCore.Mvc;
using UserManagement.Domain.Exceptions;
using MediatR;
using UserManagement.API.Models;
using UserManagement.Application.Commands.CreateUser;
using UserManagement.Application.Queries.GetAllUsers;
using UserManagement.Application.Queries.GetUserById;
using UserManagement.Application.Queries.GetUserByUserName;
using UserManagement.Application.Commands.UpdateUser;
using UserManagement.Application.Commands.DeleteUser;

namespace UserManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserCommand command)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdUser = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> GetAllUsers()
        {
            var query = new GetAllUsersQuery();
            var users = await _mediator.Send(query);
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            try
            {
                var query = new GetUserByIdQuery { Id = id };
                var user = await _mediator.Send(query);
                return Ok(user);
            }
            catch (UserNotFoundException<int>)
            {
                return NotFound();
            }
        }

        [HttpGet("username/{username}")]
        public async Task<ActionResult<UserDto>> GetUserByUsername(string username)
        {
            try
            {
                var query = new GetUserByUserNameQuery { Username = username };
                var user = await _mediator.Send(query);
                return Ok(user);
            }
            catch (UserNotFoundException<string>)
            {
                return NotFound();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateUserCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest("User ID mismatch");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _mediator.Send(command);
                return NoContent();
            }
            catch (UserNotFoundException<int>)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                var command = new DeleteUserCommand { Id = id };
                await _mediator.Send(command);
                return NoContent();
            }
            catch (UserNotFoundException<int>)
            {
                return NotFound();
            }
        }
    }
}
