using Backend_farmlogitech.Profiles.Domain.Model.Aggregates;
using Backend_farmlogitech.Profiles.Domain.Model.Commands;

namespace Backend_farmlogitech.Profiles.Domain.Services;

public interface IEmployeeCommandService
{
    Task<Employee> Handle(CreateEmployeeCommand command);
}