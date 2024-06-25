using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Aggregates.Expenses;
using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Queries.Expenses;
using Backend_farmlogitech.DashboardAnalytics.Domain.Repositories.Expenses;
using Backend_farmlogitech.DashboardAnalytics.Domain.Services;
using Backend_farmlogitech.IAM.Domain.Model.Aggregates;
using Backend_farmlogitech.IAM.Domain.Model.ValueObjects;
using Backend_farmlogitech.IAM.Domain.Repositories;

namespace Backend_farmlogitech.DashboardAnalytics.Application.Internal.QueryServices;

public class ExpenseQueryService : IExpenseQueryService
{
    private readonly IExpenseRepository _expenseRepository;
    private readonly IUserRepository userRepository;

    public ExpenseQueryService(IExpenseRepository expenseRepository, IUserRepository userRepository)
    {
        _expenseRepository = expenseRepository;
        this.userRepository = userRepository;
    }

    public async Task<Expense> Handle(GetExpenseByIdQuery query)
    {
        var expense = await _expenseRepository.GetExpenseById(query.Id);

        var userGlobal = User.GlobalVariables.UserId;
        var userRole = await userRepository.GetUserRole(userGlobal);
        if (userRole.Role != Role.FARMER || expense.FarmId != userGlobal)
        {
            throw new Exception("You can only view expenses that you have created");
        }

        return expense;
    }

    public async Task<Expense?> Handle(GetExpenseByCategoryAndDateQuery query)
    {
        var expense = await _expenseRepository.GetByCategoryAndDate(query.Category, query.Date);

        var userGlobal = User.GlobalVariables.UserId;
        var userRole = await userRepository.GetUserRole(userGlobal);
        if (userRole.Role != Role.FARMER || expense.FarmId != userGlobal)
        {
            throw new Exception("You can only view expenses that you have created");
        }

        return expense;
    }

    public async Task<IEnumerable<Expense>> Handle(GetAllByFarmIdQuery query)
    {
        var expenses = await _expenseRepository.GetAllByFarmId(query.Farmid);

        var userGlobal = User.GlobalVariables.UserId;
        var userRole = await userRepository.GetUserRole(userGlobal);
        if (userRole.Role != Role.FARMER || expenses.Any(expense => expense.FarmId != userGlobal))
        {
            throw new Exception("You can only view expenses that you have created");
        }

        return expenses;
    }
}