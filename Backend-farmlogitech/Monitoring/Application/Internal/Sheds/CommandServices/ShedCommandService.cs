using backend_famLogitech_aw.Shared.Domain.Repositories;
using Backend_farmlogitech.Farms.Domain.Repositories;
using Backend_farmlogitech.IAM.Domain.Model.Aggregates;
using Backend_farmlogitech.IAM.Domain.Model.ValueObjects;
using Backend_farmlogitech.IAM.Domain.Repositories;
using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Sheds;
using Backend_farmlogitech.Monitoring.Domain.Repositories.Sheds;
using Backend_farmlogitech.Monitoring.Domain.Services.Sheds;

namespace Backend_farmlogitech.Monitoring.Application.Internal.Sheds.CommandServices;

public class ShedCommandService :IShedCommandService
{
    private readonly IUserRepository _userRepository;
    private readonly IFarmRepository _farmRepository; 
    private readonly IShedRepository _shedRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ShedCommandService(IUserRepository userRepository, IFarmRepository farmRepository, IShedRepository shedRepository, IUnitOfWork unitOfWork)
    {
        _userRepository = userRepository;
        _farmRepository = farmRepository;
        _shedRepository = shedRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Shed> Handle(CreateShedCommand command)
    {
        // Obtiene el ID del usuario autenticado globalmente
        var userGlobal = User.UserAuthenticate.UserId;

        // Obtiene el rol del usuario a partir del ID del usuario
        var userRole = await _userRepository.GetUserRole(userGlobal);

        // Verifica si el rol del usuario no es FARMER o FARMWORKER. Si no lo es, lanza una excepción
        if (userRole == null || (userRole.Role != Role.FARMER && userRole.Role != Role.FARMWORKER))
        {
            throw new Exception("Only users with role FARMER or FARMWORKER can create a Shed");
        }

        // Obtiene la granja a la que pertenece el usuario autenticado
        var farm = await _farmRepository.GetFarmByUserId(userGlobal);
        if (farm == null)
        {
            throw new Exception("User does not belong to any farm");
        }

        // Obtiene el ID de la granja
        var farmId = farm.GetId();
        if (farmId == 0)
        {
            throw new Exception("farm id is null");
        } ;
    
        

        // Crea un nuevo cultivo con el comando proporcionado y asigna el FarmId y UserId
        var shedNew = new Shed(command)
        {
            FarmId = farmId,
        };

        // Agrega el nuevo cultivo al repositorio
        await _shedRepository.AddAsync(shedNew);

        // Completa la transacción de la unidad de trabajo
        await _unitOfWork.CompleteAsync();

        // Devuelve el nuevo cultivo
        return shedNew;
    }
}