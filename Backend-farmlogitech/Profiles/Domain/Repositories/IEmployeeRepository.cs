using backend_famLogitech_aw.Shared.Domain.Repositories;
using Backend_farmlogitech.Profiles.Domain.Model.Aggregates;

namespace Backend_farmlogitech.Profiles.Domain.Repositories;

public interface IEmployeeRepository :IBaseRepository<Employee>
{
    Task<IEnumerable<Employee>> FindAllEmployee();
     Task<Employee?> FindById(int id);
    
    Task<IEnumerable<Employee>> FindEmployeesByFarmId(int farmId);
}