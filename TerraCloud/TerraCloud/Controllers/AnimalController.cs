using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TerraCloud.Application.Animal.Queries;
using TerraCloud.Application.DTOs.Animal.Requests;
using TerraCloud.Application.DTOs.Animal.Responses;
using TerraCloud.Application.Interfaces.Animal;
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
        private readonly IAddAnimal _addAnimal;
        private readonly IDeleteAnimal _deleteAnimal;
        private readonly IGetUserAnimals _getUserAnimals;
        private readonly IHttpContextAccessor _contextAccessor;

        public AnimalController(IGetAnimal getAnimal, IGetAnimals getAnimals, IAddAnimal addAnimal, IDeleteAnimal deleteAnimal, IGetUserAnimals getUserAnimals, IHttpContextAccessor contextAccessor)
        {
            _addAnimal = addAnimal;
            _getAnimal = getAnimal;
            _getAnimals = getAnimals;
            _deleteAnimal = deleteAnimal;
            _getUserAnimals = getUserAnimals;
            _contextAccessor = contextAccessor;
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
            GetAnimalResponse response = await _getAnimal.Execute(id);

            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> AddAnimal([FromBody] AddAnimalRequest request)
        {
            await _addAnimal.Execute(request);

            return Ok();
        }
        [HttpPatch]
        public async Task<IActionResult> UpdateAnimal()
        {
            return Ok();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnimal([FromRoute] string id)
        {
            await _deleteAnimal.Execute(id);

            return NoContent();
        }
    }
}
