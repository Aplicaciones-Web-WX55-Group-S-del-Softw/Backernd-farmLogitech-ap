using Backend_farmlogitech.Profiles.Domain.Model.Commands;
using Backend_farmlogitech.Profiles.Interfaces.REST.Resources;

namespace Backend_farmlogitech.Profiles.Interfaces.REST.Transform;

public class CreateProfileCommandFromResourceAssembler
{
    public static CreateProfileCommand ToCommand(CreateProfileResource resource)
    {
        return new CreateProfileCommand(resource.Name, resource.Email, resource.Direction, resource.DocumentNumber, resource.DocumentType, resource.UserId);
    }
}