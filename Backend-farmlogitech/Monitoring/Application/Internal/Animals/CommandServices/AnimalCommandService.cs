using backend_famLogitech_aw.Shared.Domain.Repositories;
using Backend_farmlogitech.Farms.Domain.Repositories;
using Backend_farmlogitech.IAM.Domain.Model.Aggregates;
using Backend_farmlogitech.IAM.Domain.Model.ValueObjects;
using Backend_farmlogitech.IAM.Domain.Repositories;
using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Animals;
using Backend_farmlogitech.Monitoring.Domain.Repositories.Animals;
using Backend_farmlogitech.Monitoring.Domain.Services.Animals;

namespace Backend_farmlogitech.Monitoring.Application.Internal.Animals.CommandServices;

public class AnimalCommandService : IAnimalCommandService
{
    private readonly IAnimalRepository _animalRepository;
    private readonly IUserRepository _userRepository;
    private readonly IFarmRepository _farmRepository;
    private readonly IUnitOfWork _unitOfWork;

    public AnimalCommandService(IAnimalRepository animalRepository, IUnitOfWork unitOfWork, IFarmRepository farmRepository, IUserRepository userRepository)
    {
        this._animalRepository = animalRepository;
        this._unitOfWork = unitOfWork;
        _farmRepository = farmRepository;
        _userRepository = userRepository;
    }

    public async Task<Animal> Handle(CreateAnimalCommand command)
    {
        // Obtiene el ID del usuario autenticado globalmente
        var userGlobal = User.UserAuthenticate.UserId;

        // Obtiene el rol del usuario a partir del ID del usuario
        var userRole = await _userRepository.GetUserRole(userGlobal);

        // Verifica si el rol del usuario no es FARMER. Si no lo es, lanza una excepción
        if (userRole == null && (userRole.Role != Role.FARMER || userRole.Role != Role.FARMWORKER))
        {
            throw new Exception("Only users with role FARMER can create an animal");
        }
         

        // Obtiene la granja a la que pertenece el usuario autenticado
        var farm = await _farmRepository.GetFarmByUserId(userGlobal);
        

        // Obtiene el ID de la granja
        var farmId = farm.GetId();

        // Crea un nuevo animal con el comando proporcionado y asigna el FarmId
        var animalNew = new Animal(command)
        {
            FarmId = farmId,
            UserId = userGlobal
        };

        // Agrega el nuevo animal al repositorio
        await _animalRepository.AddAsync(animalNew);

        // Completa la transacción de la unidad de trabajo
        await _unitOfWork.CompleteAsync();

        // Devuelve el nuevo animal
        return animalNew; 
    }


    public async Task<Animal> Handle(UpdateAnimalCommand command)
    {
        // Obtiene el ID del usuario autenticado globalmente
        var userGlobal = User.UserAuthenticate.UserId;

        // Obtiene el rol del usuario a partir del ID del usuario
        var userRole = await _userRepository.GetUserRole(userGlobal);

        // Verifica si el rol del usuario no es FARMER o FARMWORKER. Si no lo es, lanza una excepción
        if (userRole == null || (userRole.Role != Role.FARMER && userRole.Role != Role.FARMWORKER))
        {
            throw new Exception("Only users with role FARMER or FARMWORKER can update an animal");
        }

        // Verifica si el animal existe
        var animal = await _animalRepository.FindByIdAsync(command.Id);
        if (animal == null)
        {
            throw new Exception($"Animal with ID {command.Id} does not exist");
        }

        // Verifica si el animal pertenece a la misma granja que el usuario
        var farm = await _farmRepository.GetFarmByUserId(userGlobal);
        if (farm == null || animal.FarmId != farm.Id)
        {
            throw new Exception("User does not have permission to update this animal");
        }

        // Actualiza el animal
        animal.Update(command);
        await _unitOfWork.CompleteAsync();
        return animal;
    }


    public async Task<Animal> Handle(DeleteAnimalCommand command)
    {
        // Obtiene el ID del usuario autenticado globalmente
        var userGlobal = User.UserAuthenticate.UserId;

        // Obtiene el rol del usuario a partir del ID del usuario
        var userRole = await _userRepository.GetUserRole(userGlobal);

        // Verifica si el rol del usuario no es FARMER o FARMWORKER. Si no lo es, lanza una excepción
        if (userRole == null || (userRole.Role != Role.FARMER && userRole.Role != Role.FARMWORKER))
        {
            throw new Exception("Only users with role FARMER or FARMWORKER can delete an animal");
        }

        // Verifica si el animal existe
        var animal = await _animalRepository.FindByIdAsync(command.Id);
        if (animal == null)
        {
            throw new Exception($"No animal found with id {command.Id}");
        }

        // Verifica si el animal pertenece a la misma granja que el usuario
        var farm = await _farmRepository.GetFarmByUserId(userGlobal);
        if (farm == null || animal.FarmId != farm.Id)
        {
            throw new Exception("User does not have permission to delete this animal");
        }

        // Elimina el animal
        await _animalRepository.DeleteAsync(animal);
        await _unitOfWork.CompleteAsync();
        return animal;
    }


    /*public async Task<Animal> Handle(ReadAnimalCommand command)
    {
        var animalToRead = await _animalRepository.FindByIdAsync(command.Id);
        if (animalToRead == null)
            throw new Exception("Animal with ID does not exist");
        animalToRead.Read(command);
        await _unitOfWork.CompleteAsync();
        return animalToRead;
    }*/
}