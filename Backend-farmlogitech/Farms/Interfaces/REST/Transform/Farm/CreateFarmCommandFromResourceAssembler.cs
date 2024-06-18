using Backend_farmlogitech.Farms.Domain.Model.Commands.Farm;
using Backend_farmlogitech.Farms.Interfaces.REST.Resources.Farm;

namespace Backend_farmlogitech.Farms.Interfaces.REST.Transform.Farm;

public static class CreateFarmCommandFromResourceAssembler
{
    public static CreateFarmCommand ToCommandFromResource(CreateFarmResource resource)
    {
        return new CreateFarmCommand( resource.FarmName, resource.Location, resource.Type,
            resource.Infrastructure, resource.Certificate, resource.Product, resource.Services, resource.Status,
            resource.Image, resource.Price, resource.Surface, resource.Highlights );
    }
    
}