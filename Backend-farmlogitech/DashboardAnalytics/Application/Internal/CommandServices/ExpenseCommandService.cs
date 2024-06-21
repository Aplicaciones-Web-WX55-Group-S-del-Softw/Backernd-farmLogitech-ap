using backend_famLogitech_aw.Shared.Domain.Repositories;
using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Aggregates.Expenses;
using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Commands.Expenses;
using Backend_farmlogitech.DashboardAnalytics.Domain.Repositories.Expenses;
using Backend_farmlogitech.DashboardAnalytics.Domain.Services;
using Backend_farmlogitech.Farms.Domain.Repositories;
using Backend_farmlogitech.IAM.Domain.Model.Aggregates;
using Backend_farmlogitech.IAM.Domain.Model.ValueObjects;
using Backend_farmlogitech.IAM.Domain.Repositories;

namespace Backend_farmlogitech.DashboardAnalytics.Application.Internal.CommandServices;

public class ExpenseCommandService : IExpenseCommandService
{
    private readonly IExpenseRepository _expenseRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository _userRepository;
    private readonly IFarmRepository _farmRepository;

    public ExpenseCommandService(IExpenseRepository expenseRepository, IUnitOfWork unitOfWork, IUserRepository userRepository, IFarmRepository farmRepository)
    {
        _expenseRepository = expenseRepository;
        _unitOfWork = unitOfWork;
        _userRepository = userRepository;
        _farmRepository = farmRepository;
    }

    public async Task<Expense> Handle(CreateExpenseCommand command)
    {
        // Obtiene el ID del usuario autenticado globalmente
        var userGlobal = User.UserAuthenticate.UserId;

        // Obtiene el rol del usuario a partir del ID del usuario
        var userRole = await _userRepository.GetUserRole(userGlobal);

        // Verifica si el rol del usuario no es FARMER o FARMWORKER. Si no lo es, lanza una excepción
        if (userRole == null || (userRole.Role != Role.FARMER))
        {
            throw new Exception("Only users with role FARMER or FARMWORKER can create a Expense");
        }

        // Obtiene la granja a la que pertenece el usuario autenticado
        var farm = await _farmRepository.GetFarmByUserId(userGlobal);
        if (farm == null)
        {
            throw new Exception("User does not belong to any farm");
        }

        // Obtiene el ID de la granja
        var farmId = farm.GetId();

        // Verifica si un cultivo con el ID ya existe
        var existingExpense = await _expenseRepository.GetByCategoryAndDate(command.Category, command.Date);
        if (existingExpense != null)
        {
            throw new Exception("Expense with Category and Date already exists");
        }

        // Crea un nuevo cultivo con el comando proporcionado y asigna el FarmId 
        var ExpenseNew = new Expense(command)
        {
            FarmId = farmId,
        };

        // Agrega el nuevo cultivo al repositorio
        await _expenseRepository.AddAsync(ExpenseNew);

        // Completa la transacción de la unidad de trabajo
        await _unitOfWork.CompleteAsync();

        // Devuelve el nuevo cultivo
        return ExpenseNew;
    }

}