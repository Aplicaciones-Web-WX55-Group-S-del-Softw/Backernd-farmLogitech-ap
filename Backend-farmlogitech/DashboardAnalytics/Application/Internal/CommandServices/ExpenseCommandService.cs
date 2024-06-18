using backend_famLogitech_aw.Shared.Domain.Repositories;
using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Aggregates.Expenses;
using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Commands.Expenses;
using Backend_farmlogitech.DashboardAnalytics.Domain.Repositories.Expenses;
using Backend_farmlogitech.DashboardAnalytics.Domain.Services;

namespace Backend_farmlogitech.DashboardAnalytics.Application.Internal.CommandServices;

public class ExpenseCommandService : IExpenseCommandService
{
    private readonly IExpenseRepository _expenseRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ExpenseCommandService(IExpenseRepository expenseRepository, IUnitOfWork unitOfWork)
    {
        _expenseRepository = expenseRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Expense> Handle(CreateExpenseCommand command)
    {
        var expense1 = await _expenseRepository.GetByCategoryAndPeriod(
            command.Category, command.Period);
        if(expense1 != null)
            throw new Exception("Expense already exists");
        expense1 = new Expense(command);
        await _expenseRepository.AddAsync(expense1);
        await _unitOfWork.CompleteAsync();
        return expense1;
    }
}