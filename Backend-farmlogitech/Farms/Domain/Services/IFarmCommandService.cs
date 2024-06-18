using Backend_farmlogitech.Farms.Domain.Model.Aggregates;
using Backend_farmlogitech.Farms.Domain.Model.Commands.Farm;

namespace Backend_farmlogitech.Farms.Domain.Services;

public interface IFarmCommandService
{
 Task<Farm> Handle(CreateFarmCommand command);

 Task<Farm> Handle(UpdateFarmCommand command); 

 int GetAuthenticatedUserId();
}