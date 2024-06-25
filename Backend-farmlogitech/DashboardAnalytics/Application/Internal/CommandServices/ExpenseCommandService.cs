using backend_famLogitech_aw.Shared.Domain.Repositories;
using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Aggregates.Expenses;
using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Commands.Expenses;
using Backend_farmlogitech.DashboardAnalytics.Domain.Repositories.Expenses;
using Backend_farmlogitech.DashboardAnalytics.Domain.Services;
using Backend_farmlogitech.IAM.Domain.Model.Aggregates;
using Backend_farmlogitech.IAM.Domain.Model.ValueObjects;
using Backend_farmlogitech.IAM.Domain.Repositories;

namespace Backend_farmlogitech.DashboardAnalytics.Application.Internal.CommandServices;

public class ExpenseCommandService : IExpenseCommandService
{
    private readonly IExpenseRepository _expenseRepository;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserRepository userRepository;

    public ExpenseCommandService(IExpenseRepository expenseRepository, IUnitOfWork unitOfWork, IUserRepository userRepository)
    {
        _expenseRepository = expenseRepository;
        _unitOfWork = unitOfWork;
        this.userRepository = userRepository;
    }

    public async Task<Expense> Handle(CreateExpenseCommand command)
    {
        var userGlobal = User.GlobalVariables.UserId;
        var userRole = await userRepository.GetUserRole(userGlobal);
        if (userRole.Role != Role.FARMER)
        {
            throw new Exception("Only users with role FARMER can create an expense");
        }

        // Check if the user has already created an expense
        var existingExpense = await _expenseRepository.GetByCategoryAndDate(command.Category, command.Date);
        if(existingExpense != null)
        {
            throw new Exception("Expense already exists");
        }

        var expense1 = new Expense(command);
        await _expenseRepository.AddAsync(expense1);
        await _unitOfWork.CompleteAsync();
        return expense1;
    }
}