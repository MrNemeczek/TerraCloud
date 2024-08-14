using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TerraCloud.Application.Animal.Commands;
using TerraCloud.Application.Animal.Queries;
using TerraCloud.Application.DTOs.Animal.Requests;
using TerraCloud.Application.DTOs.Animal.Responses;
using TerraCloud.Application.Interfaces.Animal;
using TerraCloud.Domain.Models.Animal;
using TerraCloud.Server.Common;

namespace TerraCloud.Server.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalController : ControllerBase
    {
        private readonly IGetAnimal _getAnimal;
        private readonly IGetAnimals _getAnimals;
        private readonly IAddAnimalUser _addAnimalUser;
        private readonly IAddAnimalToUserList _addAnimalToUserList;
        private readonly IDeleteUserAnimal _deleteUserAnimal;
        private readonly IGetUserAnimals _getUserAnimals;
        private readonly IUpdateAnimal _updateAnimal;
        private readonly IHttpContextAccessor _contextAccessor;

        public AnimalController(IGetAnimal getAnimal, IGetAnimals getAnimals, IAddAnimalUser addAnimalUser, IGetUserAnimals getUserAnimals, IHttpContextAccessor contextAccessor, IDeleteUserAnimal deleteUserAnimal, IUpdateAnimal updateAnimal, IAddAnimalToUserList addAnimalToUserList)
        {
            _addAnimalUser = addAnimalUser;
            _getAnimal = getAnimal;
            _getAnimals = getAnimals;
            _getUserAnimals = getUserAnimals;
            _contextAccessor = contextAccessor;
            _deleteUserAnimal = deleteUserAnimal;
            _updateAnimal = updateAnimal;
            _addAnimalToUserList = addAnimalToUserList;
        }

        [HttpGet]
        public async Task<IActionResult> GetAnimals()
        {
            var response = await _getAnimals.Execute();

            return Ok(response);
        }
        [HttpGet("UserAnimals")]
        public async Task<IActionResult> GetUserAnimals()
        {
            var userId = _contextAccessor.GetUserGuid();
            var response = await _getUserAnimals.Execute(userId);

            return Ok(response);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnimal([FromRoute] Guid id)
        {
            Guid userId = _contextAccessor.GetUserGuid();
            GetAnimalResponse response = await _getAnimal.Execute(id, userId);

            return Ok(response);
        }
        [HttpPost("AnimalUser")]
        public async Task<IActionResult> AddAnimalUser([FromBody] AddAnimalUserRequest request)
        {
            Guid userId = _contextAccessor.GetUserGuid();
            await _addAnimalUser.Execute(request, userId);

            return Ok();
        }
        [HttpPost("AddAnimalToUserList")]
        public async Task<IActionResult> AddAnimalToUserList([FromBody] AddAnimalToUserListRequest request)
        {
            Guid userId = _contextAccessor.GetUserGuid();
            await _addAnimalToUserList.Execute(request, userId);

            return Ok();
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateAnimal([FromBody] UpdateAnimalRequest request)
        {
            Guid userId = _contextAccessor.GetUserGuid();
            await _updateAnimal.Execute(request, userId);

            return Ok();
        }

        [HttpDelete("UserAnimal/{id}")]
        public async Task<IActionResult> DeleteUserAnimal([FromRoute] string id)
        {
            Guid userId = _contextAccessor.GetUserGuid();
            await _deleteUserAnimal.Execute(Guid.Parse(id), userId);

            return NoContent();
        }
    }
}
