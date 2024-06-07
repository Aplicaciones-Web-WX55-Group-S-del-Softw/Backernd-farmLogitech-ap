using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Domain.Model.Queries.Animals;
using Backend_farmlogitech.Monitoring.Domain.Repositories.Animals;
using Backend_farmlogitech.Monitoring.Domain.Services.Animals;

namespace Backend_farmlogitech.Monitoring.Application.Internal.Animals.QueryServices;

public class AnimalQueryService : IAnimalQueryService
{
    private IAnimalRepository _animalRepository;
    
    public async Task<Animal> Handle(GetAnimalByIdQuery query)
    {
        return await _animalRepository.FindByIdAsync(query.Id);
    }

    public async Task<IEnumerable<Animal>> Handle(GetAllAnimalsQuery query)
    {
        return await _animalRepository.FindByAllAnimalsAsync();
    }

    public async Task<Animal> Handle(GetAnimalByShedIdQuery query)
    {
        return await _animalRepository.FindByIdAsync(query.ShedId); 
    }
}