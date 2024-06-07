using Backend_farmlogitech.Farms.Domain.Model.Commands.Farm;
using Backend_farmlogitech.Farms.Interfaces.REST.Resources.Farm;

namespace Backend_farmlogitech.Farms.Interfaces.REST.Transform.Farm;

public static class UpdateFarmCommandFromResourceAssembler
{
    public static UpdateFarmCommand ToCommandFromResource(UpdateFarmResource resource)
    {
        return new UpdateFarmCommand(resource.Id, resource.FarmName, resource.Location, resource.Type,
            resource.Infrastructure, resource.Certificate, resource.Product);
    }
}