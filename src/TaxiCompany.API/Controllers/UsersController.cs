using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaxiCompany.Application.Models.Users;
using TaxiCompany.Application.Services.Interfaces;

namespace TaxiCompany.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IClientService _clientService;
        private readonly IEmployeeService _employeeService;
        private readonly IDriverService _driverService;

        public UsersController(
            IUserService userService, 
            IClientService clientService, 
            IEmployeeService employeeService, 
            IDriverService driverService)
        {
            _userService = userService;
            _clientService = clientService;
            _employeeService = employeeService;
            _driverService = driverService;
        }

        [HttpPost]
        public async ValueTask<ActionResult<UserDto>> PostUserAsync(
            UserForCreationDto userForCreationDto)
        {
            var createdUser = await _userService
                .CreateUserAsync(userForCreationDto);

            await _userService.CreateByRole(createdUser);

            return Created("", createdUser);
        }

        [AllowAnonymous]
        [HttpGet]
        public IActionResult GetUsers()
        {
            var users = _userService.RetrieveUsers();

            return Ok(users);
        }

        [HttpGet("{userId:guid}")]
        public async ValueTask<ActionResult<UserDto>> GetUserByIdAsync(
            Guid userId)
        {
            var user = await _userService
                .RetrieveUserByIdAsync(userId);

            return Ok(user);
        }

        [HttpPut]
        public async ValueTask<ActionResult<UserDto>> PutUserAsync(
            UserForModificationDto userForModificationDto)
        {
            var modifiedUser = await _userService
                .ModifyUserAsync(userForModificationDto);

            return Ok(modifiedUser);
        }

        [HttpDelete("{userId:guid}")]
        public async ValueTask<ActionResult<UserDto>> DeleteUserAsync(
            Guid userId)
        {
            var removed = await _userService
                .RemoveUserAsync(userId);

            return Ok(removed);
        }
    }
}