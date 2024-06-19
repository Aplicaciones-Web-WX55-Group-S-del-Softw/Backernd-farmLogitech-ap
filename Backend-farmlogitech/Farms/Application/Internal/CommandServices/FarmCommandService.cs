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
        var userGlobal = User.GlobalVariables.UserId;
        var userRole = await userRepository.GetUserRole(userGlobal);
        if (userRole.Role != Role.FARMER)
        {
            throw new Exception("Only users with role FARMER can create a farm");
        }

        // Check if the user has already created a farm
        var existingFarm = await farmRepository.GetFarmByUserId(userGlobal);
        if (existingFarm != null)
        {
            throw new Exception("User has already created a farm");
        }

        var farmNew = new Farm(command);
        farmNew.UserId = userGlobal;
        await farmRepository.AddAsync(farmNew);
        await unitOfWork.CompleteAsync();
        return farmNew;
    }


    public async Task<Farm> Handle(UpdateFarmCommand command)
    {
        
        var farmToUpdate = await farmRepository.FindByIdAsync(command.Id);
        if (farmToUpdate == null)
            throw new Exception("Farm with ID does not exist");
        farmToUpdate.Update(command);
        await unitOfWork.CompleteAsync();
        return farmToUpdate;
        
        return null;
    }
}