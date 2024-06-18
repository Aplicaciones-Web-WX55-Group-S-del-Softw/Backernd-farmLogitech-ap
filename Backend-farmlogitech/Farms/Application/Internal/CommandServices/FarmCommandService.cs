using System.Security.Claims;
using backend_famLogitech_aw.Shared.Domain.Repositories;
using Backend_farmlogitech.Farms.Domain.Model.Aggregates;
using Backend_farmlogitech.Farms.Domain.Model.Commands.Farm;
using Backend_farmlogitech.Farms.Domain.Repositories;
using Backend_farmlogitech.Farms.Domain.Services;
using Backend_farmlogitech.IAM.Domain.Model.Aggregates;
using static Backend_farmlogitech.IAM.Domain.Model.Aggregates.User;

namespace Backend_farmlogitech.Farms.Application.Internal.CommandServices;

public class FarmCommandService : IFarmCommandService
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IFarmRepository farmRepository;
    private readonly IHttpContextAccessor httpContextAccessor;
    public FarmCommandService(IUnitOfWork unitOfWork, IFarmRepository farmRepository, IHttpContextAccessor httpContextAccessor)
    {
        this.unitOfWork = unitOfWork;
        this.farmRepository = farmRepository;
        this.httpContextAccessor = httpContextAccessor;
    }

    public int GetAuthenticatedUserId()
    {
        var userClaims = httpContextAccessor.HttpContext?.User;
        if (userClaims == null || !userClaims.Identity.IsAuthenticated)
        {
            throw new Exception("User is not authenticated");
        }

        var userIdClaim = userClaims.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userIdClaim == null)
        {
            throw new Exception("User ID claim is missing");
        }

        if (!int.TryParse(userIdClaim, out int userId))
        {
            throw new Exception("User ID claim is not a valid integer");
        }

        return userId;
    }

    public async Task<Farm> Handle(CreateFarmCommand command)
    {
        var userId= GetAuthenticatedUserId();
        
        var farmNew = new Farm(command);
        farmNew.UserId = userId;
        await farmRepository.AddAsync(farmNew);
        await unitOfWork.CompleteAsync();
        return farmNew;
    }

    public async Task<Farm> Handle(UpdateFarmCommand command)
    {
        /*
        var farmToUpdate = await farmRepository.FindByIdx(command.Id);
        if (farmToUpdate == null)
            throw new Exception("Farm with ID does not exist");
        farmToUpdate.Update(command);
        await unitOfWork.CompleteAsync();
        return farmToUpdate;
        */
        return null;
    }
}