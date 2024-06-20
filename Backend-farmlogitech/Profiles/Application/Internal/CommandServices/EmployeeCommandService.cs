
using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend_farmlogitech.IAM.Domain.Model.Aggregates;
using Backend_farmlogitech.IAM.Domain.Model.ValueObjects;
using Backend_farmlogitech.IAM.Domain.Repositories;
using Backend_farmlogitech.Profiles.Domain.Model.Aggregates;
using Backend_farmlogitech.Profiles.Domain.Model.Commands;
using Backend_farmlogitech.Profiles.Domain.Repositories;
using Backend_farmlogitech.Profiles.Domain.Services;

namespace Backend_farmlogitech.Employees.Application.Internal.CommandServices
{
    public class EmployeeCommandService : IEmployeeCommandService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly AppDbContext _dbContext; // Use AppDbContext here
        private readonly IUserRepository _userRepository;

        public EmployeeCommandService(IEmployeeRepository employeeRepository, IHttpContextAccessor httpContextAccessor, AppDbContext dbContext, IUserRepository userRepository) // Use AppDbContext here
        {
            _employeeRepository = employeeRepository;
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
            this._userRepository = userRepository;
        }

        public async Task<Employee> Handle(CreateEmployeeCommand command)
        {
            var userId = User.GlobalVariables.UserId;

            // Get the role of the user
            var userRole = await _userRepository.GetUserRole(userId);

            // Check if the user role is allowed to create a Employee
            if (userRole != null && userRole.Role != Role.FARMWORKER && userRole.Role != Role.OWNER)
            {
                throw new Exception("Only users with allowed role can create a Employee Profile");
            }

            // Check if the user has already created a Employee
            var existingEmployee = await _employeeRepository.FindById(command.FarmId);
            if (existingEmployee != null)
            {
                throw new Exception("User has already created a Employee");
            }

            var employee = new Employee(command)
            {
                Id = userId
            };

            employee.Id= userId;
            await _employeeRepository.AddAsync(employee);
            await _dbContext.SaveChangesAsync(); // Add this line

            return employee;
        }
    }
}