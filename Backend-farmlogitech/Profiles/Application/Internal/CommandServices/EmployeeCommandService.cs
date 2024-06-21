
using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend_farmlogitech.Farms.Domain.Repositories;
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
        private readonly IFarmRepository farmRepository;

        public EmployeeCommandService(IEmployeeRepository employeeRepository, IHttpContextAccessor httpContextAccessor, AppDbContext dbContext, IUserRepository userRepository) // Use AppDbContext here
        {
            _employeeRepository = employeeRepository;
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
            this._userRepository = userRepository;
        }

        public async Task<Employee> Handle(CreateEmployeeCommand command)
        {
            // Obtiene el ID del usuario autenticado globalmente
            var userGlobal = User.UserAuthenticate.UserId;

            // Obtiene el rol del usuario a partir del ID del usuario
            var userRole = await _userRepository.GetUserRole(userGlobal);

            // Verifica si el rol del usuario no es FARMER. Si no lo es, lanza una excepción
            if (userRole.Role != Role.FARMER)
            {
                throw new Exception("Only users with role FARMER can create an Employee Profile");
            }

            // Obtiene la granja a la que pertenece el usuario autenticado
            var farm = await farmRepository.GetFarmByUserId(userGlobal);
            if (farm == null)
            {
                throw new Exception("User does not belong to any farm");
            }

            // Obtiene el ID de la granja
            var farmId = farm.GetId();

            // Crea un nuevo empleado con el comando proporcionado
            var employeeNew = new Employee(command)
            {
                Id = userGlobal,
                FarmId = farmId
            };

            // como que sign up
           //todo como que sign up

            // Agrega el nuevo empleado al repositorio
            await _employeeRepository.AddAsync(employeeNew);

            // Completa la transacción de la unidad de trabajo
            await _dbContext.SaveChangesAsync();

            return employeeNew;
        }

    }
}