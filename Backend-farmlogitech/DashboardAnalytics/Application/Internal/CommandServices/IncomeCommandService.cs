using backend_famLogitech_aw.Shared.Domain.Repositories;
using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Aggregates.Incomes;
using Backend_farmlogitech.DashboardAnalytics.Domain.Model.Commands.Incomes;
using Backend_farmlogitech.DashboardAnalytics.Domain.Repositories.Incomes;
using Backend_farmlogitech.DashboardAnalytics.Domain.Services;

namespace Backend_farmlogitech.DashboardAnalytics.Application.Internal.CommandServices;

public class IncomeCommandService : IIncomeCommandService
{
    private readonly IIncomeRepository _IncomeRepository;
    private readonly IUnitOfWork _unitOfWork;

    public IncomeCommandService(IIncomeRepository IncomeRepository, IUnitOfWork unitOfWork)
    {
        _IncomeRepository = IncomeRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Income> Handle(CreateIncomeCommand command)
    {
        var income1 = await _IncomeRepository.GetByCategoryAndPeriod(
            command.Category, command.Period);
        if(income1 != null)
            throw new Exception("Income already exists");
        income1 = new Income(command);
        await _IncomeRepository.AddAsync(income1);
        await _unitOfWork.CompleteAsync();
        return income1;
    }
}