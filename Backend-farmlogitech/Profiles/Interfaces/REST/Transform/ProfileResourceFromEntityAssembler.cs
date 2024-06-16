using Backend_farmlogitech.Profiles.Domain.Model.Aggregates;
using Backend_farmlogitech.Profiles.Interfaces.REST.Resources;

namespace Backend_farmlogitech.Profiles.Interfaces.REST.Transform;

public class ProfileResourceFromEntityAssembler
{
    public static ProfileResource ToResource(Profile entity)
    {
        return new ProfileResource(entity.id, entity.name, entity.email, entity.direction, entity.documentNumber, entity.documentType, entity.userId);
    }
}