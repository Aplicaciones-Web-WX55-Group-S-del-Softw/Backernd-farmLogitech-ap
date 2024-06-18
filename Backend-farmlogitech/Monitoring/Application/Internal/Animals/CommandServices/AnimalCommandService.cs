using backend_famLogitech_aw.Shared.Domain.Repositories;
using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Animals;
using Backend_farmlogitech.Monitoring.Domain.Repositories.Animals;
using Backend_farmlogitech.Monitoring.Domain.Services.Animals;

namespace Backend_farmlogitech.Monitoring.Application.Internal.Animals.CommandServices;

public class AnimalCommandService : IAnimalCommandService
{
    private readonly IAnimalRepository _animalRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AnimalCommandService(IAnimalRepository animalRepository, IUnitOfWork unitOfWork)
    {
        this._animalRepository = animalRepository;
        this._unitOfWork = unitOfWork;
    }

    public async Task<Animal> Handle(CreateAnimalCommand command)
    {
        var animalnew = await _animalRepository.FindByIdAsync(command.Id); 
        if (animalnew != null)
            throw new Exception("Animal with ID already exists");
        animalnew = new Animal(command);
        await _animalRepository.AddAsync(animalnew);
        await _unitOfWork.CompleteAsync();
        return animalnew; 

    }

    public async Task<Animal> Handle(UpdateAnimalCommand command)
    {
        var animalupdate = await _animalRepository.FindByIdAsync(command.Id);
        if (animalupdate == null)
            throw new Exception("Animal with ID does not exist");
        animalupdate.Update(command);
        await _unitOfWork.CompleteAsync();
        return animalupdate;
    }

    public async Task<Animal> Handle(DeleteAnimalCommand command)
    {
        var animal = await _animalRepository.FindByIdAsync(command.Id);
        if (animal == null)
        {
            throw new Exception($"No animal found with id {command.Id}");
        }

        animal.Delete(command);
        await _animalRepository.DeleteAsync(animal);
        await _unitOfWork.CompleteAsync();
        return animal;
    }

    public async Task<Animal> Handle(ReadAnimalCommand command)
    {
        var animalToRead = await _animalRepository.FindByIdAsync(command.Id);
        if (animalToRead == null)
            throw new Exception("Animal with ID does not exist");
        animalToRead.Read(command);
        await _unitOfWork.CompleteAsync();
        return animalToRead;
    }
}