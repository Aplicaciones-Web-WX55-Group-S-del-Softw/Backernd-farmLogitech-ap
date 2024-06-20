using Backend_farmlogitech.Profiles.Domain.Model.Aggregates;
using Backend_farmlogitech.Profiles.Interfaces.REST.Resources;

namespace Backend_farmlogitech.Profiles.Interfaces.REST.Transform;

public class EmployeeResourceFromEntityAssembler
{
    public static EmployeeResource ToResource(Employee entity)
    {
        return new EmployeeResource(entity.Id, entity.Name, entity.Phone, entity.Username, entity.Password, entity.Position, entity.FarmId);
    }
}