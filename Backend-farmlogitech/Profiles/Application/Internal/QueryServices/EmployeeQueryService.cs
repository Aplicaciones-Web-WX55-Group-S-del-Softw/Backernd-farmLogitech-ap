
using System.Runtime.InteropServices;
using Backend_farmlogitech.Profiles.Domain.Model.Aggregates;
using Backend_farmlogitech.Profiles.Domain.Model.Queries;
using Backend_farmlogitech.Profiles.Domain.Repositories;
using Backend_farmlogitech.Profiles.Domain.Services;

namespace Backend_farmlogitech.Employees.Application.Internal.QueryServices
{
    public class EmployeeQueryService : IEmployeeQueryService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeQueryService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        
        public async Task<Employee?> FindById(GetEmployeeByIdQuery query)
        {
            return await _employeeRepository.FindById(query.Id);
        }

        public async Task<IEnumerable<Employee>> FindAllByFarmId(GetEmployeesByFarmId query)
        {
            return await _employeeRepository.FindEmployeesByFarmId(query.FarmId);
        }
        
        
    }
}