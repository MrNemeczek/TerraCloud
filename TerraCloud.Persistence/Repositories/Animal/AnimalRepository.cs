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

        public async Task AddAnimal(Domain.Models.Animal.Animal animal, AnimalUser animalUser)
        {
            await _context.Animals.AddAsync(animal);
            
            animalUser.AnimalId = animal.Id;
            await _context.AnimalUsers.AddAsync(animalUser);
        }

        public async Task AddAnimalUser(Guid animalId, Guid userId)
        {
            AnimalUser animalUser = new AnimalUser()
            {
                AnimalId = animalId,
                UserId = userId
            };

            await _context.AnimalUsers.AddAsync(animalUser);
        }

        public async Task DeleteAnimal(Guid userAnimalId, Guid? animalId = null)
        {
            await _context.AnimalUsers.Where(au => au.Id == userAnimalId).ExecuteDeleteAsync();
            
            if(animalId is not null)
            {
                await _context.Animals.Where(a => a.Id == animalId).ExecuteDeleteAsync();
            }
        }

        public async Task<Domain.Models.Animal.Animal> GetAnimal(Guid animalId)
        {
            return await _context.Animals.SingleOrDefaultAsync(d => d.Id == animalId);
        }
        public async Task<AnimalUser> GetAnimalUser(Guid animalUserId, Guid userId)
        {
            return await _context.AnimalUsers.SingleOrDefaultAsync(au => au.UserId == userId && au.Id == animalUserId);
        }
        public async Task<AnimalUser> GetAnimalUserByAnimalId(Guid animalId, Guid userId)
        {
            return await _context.AnimalUsers.SingleOrDefaultAsync(au => au.UserId == userId && au.AnimalId == animalId);
        }
        public async Task<IEnumerable<AnimalUser>> GetUserAnimals(Guid userId)
        {
            return await _context.AnimalUsers.Where(au => au.UserId == userId)
                .Include(au => au.Animal)
                .ToListAsync();
        }

        public async Task<IEnumerable<Domain.Models.Animal.Animal>> GetAnimals()
        {
            return await _context.Animals.Where(a => a.IsPublic).ToListAsync();
        }

        public void UpdateAnimal(Domain.Models.Animal.Animal animal)
        {
            _context.Animals.Update(animal);
        }
    }
}
