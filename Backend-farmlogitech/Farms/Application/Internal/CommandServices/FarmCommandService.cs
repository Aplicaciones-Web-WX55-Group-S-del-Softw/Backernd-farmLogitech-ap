using System.Security.Claims;
using backend_famLogitech_aw.Shared.Domain.Repositories;
using Backend_farmlogitech.Farms.Domain.Model.Aggregates;
using Backend_farmlogitech.Farms.Domain.Model.Commands.Farm;
using Backend_farmlogitech.Farms.Domain.Repositories;
using Backend_farmlogitech.Farms.Domain.Services;
using Backend_farmlogitech.IAM.Domain.Model.Aggregates;
using Backend_farmlogitech.IAM.Domain.Model.ValueObjects;
using Backend_farmlogitech.IAM.Domain.Repositories;
using static Backend_farmlogitech.IAM.Domain.Model.Aggregates.User;

namespace Backend_farmlogitech.Farms.Application.Internal.CommandServices;

public class FarmCommandService : IFarmCommandService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IFarmRepository farmRepository;
    private readonly IUserRepository userRepository;
    public FarmCommandService(IUnitOfWork unitOfWork, IFarmRepository farmRepository, IUserRepository userRepository)
    {
        this.unitOfWork = unitOfWork;
        this.farmRepository = farmRepository;
        this.userRepository= userRepository;
    }
    
    public async Task<Farm> Handle(CreateFarmCommand command)
    {
        // Obtiene el ID del usuario autenticado globalmente
        var userGlobal = User.UserAuthenticate.UserId;

        // Obtiene el rol del usuario a partir del ID del usuario
        var userRole = await userRepository.GetUserRole(userGlobal);

        // Verifica si el rol del usuario no es FARMER. Si no lo es, lanza una excepción
        if (userRole.Role != Role.FARMER)
        {
            throw new Exception("Only users with role FARMER can create a farm");
        }

        // Verifica si el usuario ya ha creado una granja. Si ya ha creado una, lanza una excepción
        var existingFarm = await farmRepository.GetFarmByUserId(userGlobal);
        if (existingFarm != null)
        {
            throw new Exception("User has already created a farm");
        }

        // Crea una nueva granja con el comando proporcionado
        var farmNew = new Farm(command);

        // Asigna el ID del usuario a la nueva granja
        farmNew.UserId = userGlobal;

        // Agrega la nueva granja al repositorio
        await farmRepository.AddAsync(farmNew);

        // Completa la transacción de la unidad de trabajo
        await unitOfWork.CompleteAsync();

        // Devuelve la nueva granja
        return farmNew;
    }
    
    public async Task<Farm> Handle(UpdateFarmCommand command)
    {
        
        var userGlobal = User.UserAuthenticate.UserId; //valid my farm
        var farmToUpdate = await farmRepository.FindByIdAsync(userGlobal);
        if (farmToUpdate == null)
            throw new Exception("Farm with ID does not exist");
        farmToUpdate.Update(command);
        await unitOfWork.CompleteAsync();
        return farmToUpdate;
        
    }
    
    
    
}