using csharp_ecommerce.DTOs;
using csharp_ecommerce.Examples;
using csharp_ecommerce.Models;
using csharp_ecommerce.Services.User;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
namespace csharp_ecommerce.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public readonly IUserInterface _userInterface;
        public UserController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        [HttpGet("find-all-users")]
        [SwaggerOperation(
            Summary = "Find All Users",
            Description = "Find all users in the database, requires admin privileges",
            Tags = new[] { "Admin" }
            )]
        public async Task<ActionResult<ResponseModel<List<UserModel>>>> FindAllUsers()
        {
            var users = await _userInterface.FindAllUsers();
            return Ok(users);
        }

       
        [HttpPost("create-user")]
        [SwaggerOperation(
            Summary = "Create User", 
            Description = "Create users with some validations.",
            OperationId = "CreateUser",
            Tags = new[] { "Admin", "User" }
        )]
        [SwaggerResponse(200, "User Created")]
        public async Task<ActionResult<ResponseModel<UserDTO>>> CreateUser(
            [FromBody, SwaggerRequestBody("User Creation Details", Required = true, Description = "User creation example")]
            UserDTO userDto)
        {
            var users = await _userInterface.CreateUser(userDto);
            return Ok(users);
        }


        [HttpGet("{userId}")]
        [SwaggerOperation(Summary = "Get user by ID", Description = "Returns a single User")]
        [SwaggerResponse(200, "Item Found", typeof(ResponseModel<UserModel>))]
        [SwaggerResponse(404, "Item Not Found", typeof(ResponseModel<UserModel>))]
        public async Task<ActionResult<ResponseModel<UserModel>>> FindUserById(int userId)
        { 
            var user = await _userInterface.FindUserById(userId);

            return Ok(user);
        }

        [HttpPut("{userId}")]
        public async Task<ActionResult<ResponseModel<UserDTO>>> UpdateUser(int userId, UserDTO userDTO)
        { 
            var user = await _userInterface.UpdateUser(userId, userDTO);

            return Ok(user);  
        }

        [HttpDelete("{userId}")]
        public async Task<ActionResult<ResponseModel<UserDTO>>> DeleteUser(int userId)
        {
            var deletedUser = await _userInterface.DeleteUser(userId);

            return Ok(deletedUser);
        }
    }
}
