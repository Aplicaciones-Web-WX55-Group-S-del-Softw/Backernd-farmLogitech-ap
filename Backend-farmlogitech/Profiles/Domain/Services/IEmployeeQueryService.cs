using Backend_farmlogitech.Profiles.Domain.Model.Aggregates;
using Backend_farmlogitech.Profiles.Domain.Model.Queries;

namespace Backend_farmlogitech.Profiles.Domain.Services;

public interface IEmployeeQueryService
{
    Task<Employee?> FindById(GetEmployeeByIdQuery query);
    Task<IEnumerable<Employee>> FindAllByFarmId(GetEmployeesByFarmId query);
}