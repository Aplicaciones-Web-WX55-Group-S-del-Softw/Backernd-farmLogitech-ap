using backend_famLogitech_aw.Shared.Domain.Repositories;
using Backend_farmlogitech.Farms.Domain.Repositories;
using Backend_farmlogitech.IAM.Domain.Model.Aggregates;
using Backend_farmlogitech.IAM.Domain.Model.ValueObjects;
using Backend_farmlogitech.IAM.Domain.Repositories;
using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Crops;
using Backend_farmlogitech.Monitoring.Domain.Repositories.Crops;
using Backend_farmlogitech.Monitoring.Domain.Services.Crops;

namespace Backend_farmlogitech.Monitoring.Application.Internal.Crops.CommandServices;

public class CropCommandService : ICropCommandService
{
    private readonly ICropRepository _cropRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IFarmRepository _farmRepository;
    
    public CropCommandService(ICropRepository cropRepository, IUnitOfWork unitOfWork, IUserRepository userRepository, IFarmRepository farmRepository)
    {
        _cropRepository = cropRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _farmRepository = farmRepository;
    }
    
    public async Task<Crop> Handle(CreateCropCommand command)
    {
        // Obtiene el ID del usuario autenticado globalmente
        var userGlobal = User.UserAuthenticate.UserId;

        // Obtiene el rol del usuario a partir del ID del usuario
        var userRole = await _userRepository.GetUserRole(userGlobal);

        // Verifica si el rol del usuario no es FARMER o FARMWORKER. Si no lo es, lanza una excepción
        if (userRole == null || (userRole.Role != Role.FARMER && userRole.Role != Role.FARMWORKER))
        {
            throw new Exception("Only users with role FARMER or FARMWORKER can create a crop");
        }

        // Obtiene la granja a la que pertenece el usuario autenticado
        var farm = await _farmRepository.GetFarmByUserId(userGlobal);
        if (farm == null)
        {
            throw new Exception("User does not belong to any farm");
        }

        // Obtiene el ID de la granja
        var farmId = farm.GetId();
        

        // Crea un nuevo cultivo con el comando proporcionado y asigna el FarmId y UserId
        var cropNew = new Crop(command)
        {
            FarmId = farmId,
            UserId = userGlobal
        };

        // Agrega el nuevo cultivo al repositorio
        await _cropRepository.AddAsync(cropNew);

        // Completa la transacción de la unidad de trabajo
        await _unitOfWork.CompleteAsync();

        // Devuelve el nuevo cultivo
        return cropNew;
    }


    public async Task<Crop> Handle(UpdateCropCommand command)
    {
        var cropUpdate = await _cropRepository.FindByIdx(command.Id);
        if (cropUpdate == null)
            throw new Exception("Crop with ID does not exist");
        cropUpdate.Update(command);
        await _unitOfWork.CompleteAsync();
        return cropUpdate;
    }

    public async Task<Crop> Handle(DeleteCropCommand command)
    {
        var cropToDelete = await _cropRepository.FindByIdx(command.Id);
        if (cropToDelete == null)
            throw new Exception("Crop with ID does not exist");
        await _cropRepository.DeleteAsync(cropToDelete);
        await _unitOfWork.CompleteAsync();
        return cropToDelete;
    }

    /*public async Task<Crop> Handle(ReadCropCommand command)
    {
        var cropToRead = await _cropRepository.FindByIdAsync(command.Id);
        if (cropToRead == null)
            throw new Exception("Crop with ID does not exist");
        cropToRead.Read(command);
        await _unitOfWork.CompleteAsync();
        return cropToRead;
    }*/
}