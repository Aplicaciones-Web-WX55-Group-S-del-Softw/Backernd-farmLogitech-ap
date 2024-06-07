using backend_famLogitech_aw.Shared.Domain.Repositories;
using Backend_farmlogitech.Monitoring.Domain.Model.Aggregates;
using Backend_farmlogitech.Monitoring.Domain.Model.Commands.Sheds;
using Backend_farmlogitech.Monitoring.Domain.Repositories.Sheds;
using Backend_farmlogitech.Monitoring.Domain.Services.Sheds;

namespace Backend_farmlogitech.Monitoring.Application.Internal.Sheds.CommandServices;

public class ShedCommandService(IUnitOfWork unitOfWork,IShedRepository shedRepository):IShedCommandService
{
    public async Task<Shed> Handle(CreateShedCommand command)
    {
        var shedNew = await shedRepository.FindShedById(command.Id);
        if (shedNew != null)
            throw new Exception("Farm with ID already exists");
        shedNew = new Shed(command);
        await shedRepository.AddAsync(shedNew);
        await unitOfWork.CompleteAsync();
        return shedNew;
    }
}