using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Domain.Model.Queries.Animals;
using Backend_farmlogitech.Monitoring.Domain.Repositories.Animals;
using Backend_farmlogitech.Monitoring.Domain.Services.Animals;

namespace Backend_farmlogitech.Monitoring.Application.Internal.Animals.QueryServices;

public class AnimalQueryService : IAnimalQueryService
{
    private IAnimalRepository _animalRepository;

    public AnimalQueryService(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    public async Task<Animal> Handle(GetAnimalByIdQuery query)
    {
        if (query == null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        var animal = await _animalRepository.FindByIdAsync(query.Id);

        if (animal == null)
        {
            throw new Exception($"No animal found with id {query.Id}");
        }

        return animal;
    }

    public async Task<IEnumerable<Animal>> Handle(GetAllAnimalsQuery query)
    {
        return await _animalRepository.FindByAllAnimalsAsync();
    }

    public async Task<Animal> Handle(GetAnimalByShedIdQuery query)
    {
        if (query == null)
        {
            throw new ArgumentNullException(nameof(query));
        }

        var animal = await _animalRepository.FindByShedId(query.ShedId);

        if (animal == null)
        {
            throw new Exception($"No animal found with shed id {query.ShedId}");
        }

        return animal;
    }
}