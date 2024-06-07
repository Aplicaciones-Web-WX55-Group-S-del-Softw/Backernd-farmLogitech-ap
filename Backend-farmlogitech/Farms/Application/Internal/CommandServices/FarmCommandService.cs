using backend_famLogitech_aw.Shared.Domain.Repositories;
using Backend_farmlogitech.Farms.Domain.Model.Aggregates;
using Backend_farmlogitech.Farms.Domain.Model.Commands.Farm;
using Backend_farmlogitech.Farms.Domain.Repositories;
using Backend_farmlogitech.Farms.Domain.Services;

namespace Backend_farmlogitech.Farms.Application.Internal.CommandServices;

public class FarmCommandService(IUnitOfWork unitOfWork, IFarmRepository farmRepository) : IFarmCommandService
{
    public async Task<Farm> Handle(CreateFarmCommand command)
    {
        var farmNew = await farmRepository.FindByIdx(command.Id);
        if (farmNew != null)
            throw new Exception("Farm with ID already exists");
        farmNew = new Farm(command);
        await farmRepository.AddAsync(farmNew);
        await unitOfWork.CompleteAsync();
        return farmNew;
    }

    public async Task<Farm> Handle(UpdateFarmCommand command)
    {
        var farmToUpdate = await farmRepository.FindByIdx(command.Id);
        if (farmToUpdate == null)
            throw new Exception("Farm with ID does not exist");
        farmToUpdate.Update(command);
        await unitOfWork.CompleteAsync();
        return farmToUpdate;
    }
}