using Backend_farmlogitech.Farms.Interfaces.REST.Resources.Farm;

namespace Backend_farmlogitech.Farms.Interfaces.REST.Transform.Farm;

public static class FarmResourceFromEntityAssembler
{
    public static FarmResource ToResourceFromEntity(Backend_farmlogitech.Farms.Domain.Model.Aggregates.Farm entity)
    {
        return new FarmResource(entity.Id, entity.FarmName, entity.Location, entity.Type, entity.Infrastructure,
            entity.Certificate, entity.Product, entity.Services,entity.Status, entity.Image, entity.Price, entity.Surface,
            entity.Highlights, entity.UserId
            );
    }
}