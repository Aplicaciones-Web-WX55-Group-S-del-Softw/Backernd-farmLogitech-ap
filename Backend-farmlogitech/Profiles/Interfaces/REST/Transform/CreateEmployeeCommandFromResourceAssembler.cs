using Backend_farmlogitech.Profiles.Domain.Model.Commands;
using Backend_farmlogitech.Profiles.Interfaces.REST.Resources;

namespace Backend_farmlogitech.Profiles.Interfaces.REST.Transform;

public class CreateEmployeeCommandFromResourceAssembler
{
    public static CreateEmployeeCommand ToCommand(CreateEmployeeResource resource)
    {
        return new CreateEmployeeCommand(resource.Name, resource.Phone, resource.Username, resource.Password, resource.Position, resource.FarmId);
    }
}