using Microsoft.EntityFrameworkCore;
using TerraCloud.Domain.Models.Animal;
using TerraCloud.Persistence.Contexts;
using TerraCloud.Persistence.Interfaces.Repository.Animal;

namespace TerraCloud.Persistence.Repositories.Animal
{
    internal class AnimalRepository : IAnimalRepository
    {
        private readonly TerraCloudContext _context;

        public AnimalRepository(TerraCloudContext context)
        {
            _context = context;
        }

        public async Task AddAnimal(Domain.Models.Animal.Animal animal)
        {
            await _context.Animals.AddAsync(animal);
        }

        public async Task DeleteAnimal(Guid animalId)
        {
            await _context.Animals.Where(a => a.Id == animalId).ExecuteDeleteAsync();
        }

        public async Task<Domain.Models.Animal.Animal> GetAnimal(Guid animalId)
        {
            return await _context.Animals.SingleOrDefaultAsync(d => d.Id == animalId);
        }
        public async Task<IEnumerable<AnimalUser>> GetUserAnimals(Guid userId)
        {
            return await _context.AnimalUsers.Where(au => au.UserId == userId).ToListAsync();
        }

        public async Task<IEnumerable<Domain.Models.Animal.Animal>> GetAnimals()
        {
            return await _context.Animals.ToListAsync();
        }
    }
}
