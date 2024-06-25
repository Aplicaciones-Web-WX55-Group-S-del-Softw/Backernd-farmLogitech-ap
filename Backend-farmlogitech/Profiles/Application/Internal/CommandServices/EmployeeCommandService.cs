
using backend_famLogitech_aw.Shared.Infrastructure.Persistence.EFC.Configuration;
using Backend_farmlogitech.Farms.Domain.Repositories;
using Backend_farmlogitech.IAM.Domain.Model.Aggregates;
using Backend_farmlogitech.IAM.Domain.Model.Commands;
using Backend_farmlogitech.IAM.Domain.Model.ValueObjects;
using Backend_farmlogitech.IAM.Domain.Repositories;
using Backend_farmlogitech.IAM.Domain.Services;
using Backend_farmlogitech.IAM.Interfaces.REST;
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
        private readonly IFarmRepository _farmRepository;
        private readonly IUserCommandService _usercommandService; 

        public EmployeeCommandService(IEmployeeRepository employeeRepository, IHttpContextAccessor httpContextAccessor, AppDbContext dbContext, IUserRepository userRepository, IFarmRepository farmRepository, IUserCommandService usercommandService) // Use AppDbContext here
        {
            _employeeRepository = employeeRepository;
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
            _userRepository = userRepository;
            _farmRepository = farmRepository;
            _usercommandService = usercommandService;
        }

        public async Task<Employee> Handle(CreateEmployeeCommand command)
        {
            // Obtiene el ID del usuario autenticado globalmente
            var userGlobal = User.UserAuthenticate.UserId;
            
            
            //validaciones
            
            if (string.IsNullOrEmpty(command.Username) || string.IsNullOrEmpty(command.Password))
            {
                throw new Exception("Username or password is null or empty");
            }

           
            
            
            // Obtiene el rol del usuario a partir del ID del usuario
            var userRole = await _userRepository.GetUserRole(userGlobal);

            // Verifica si el rol del usuario no es FARMER. Si no lo es, lanza una excepción
            if (userRole != null && userRole.Role != Role.FARMER)
            {
                throw new Exception("Only users with role FARMER can create an Employee Profile");
            }
            

            // Obtiene la granja a la que pertenece el usuario autenticado
            var farm = await _farmRepository.GetFarmByUserId(userGlobal);
            if (farm == null)
            {
                throw new Exception("User does not belong to any farm");
            }

            // Obtiene el ID de la granja
            var farmId = farm.GetId();

            // Crea un nuevo empleado con el comando proporcionado
            var employeeNew = new Employee(command)
            {
                FarmId = farmId,
                
            };
            
            // como que sign up
            var signUpCommand = new SignUpCommand(command.Username, command.Password, Role.FARMWORKER);
            await _usercommandService.Handle(signUpCommand);

            // Agrega el nuevo empleado al repositorio
            await _employeeRepository.AddAsync(employeeNew);

            // Completa la transacción de la unidad de trabajo
            await _dbContext.SaveChangesAsync();

            return employeeNew;
        }

    }
}